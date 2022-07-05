grammar Geem;
@lexer::header {using Geem.Infrastructure;}
@parser::header {using Geem.Infrastructure;}
@parser::members {
	string get_expr_type(string type1, string type2)
	{
		if(type1 == "int") { return "int";};
		if(type2 == "int") {return "int";};
		return "uint";
	}
}
program[SymbolTable st]
: (
		globalVarDecl[st]
		| functionDecl[st]
		| operationDecl[st]
		| commandStat[st]
	)+;

globalVarDecl[SymbolTable st]:
	datatype ID inititalization[st] FASLA_MANQUOTA{
		st.addSymbol($ID.text, new SymbolInfo(SymbolType.SymbolOfGlobalVariable, new VarInfo($datatype.text, null)));
	};

inititalization[SymbolTable st]: (ASSIGN_SYM expression[st]);

functionDecl[SymbolTable st]:
	FUNC_KEYWORD ID RP paramList LP COLON datatype RCB statementList[st] LCB {
		st.addSymbol($ID.text, new SymbolInfo(SymbolType.SymbolOfFunction, new FunctionInfo($paramList.parameter_datatypes_list.ToArray(), $datatype.text)));
	};

operationDecl[SymbolTable st]:
	OP_KEYWORD ID RP paramList LP RCB statementList[st] LCB{
		st.addSymbol($ID.text, new SymbolInfo(SymbolType.SymbolOfOperation, new OperationInfo($paramList.parameter_datatypes_list.ToArray())));
	};

parameter returns [string dt]: datatype ID{$dt = $datatype.text;};
paramList returns[List<string> parameter_datatypes_list] @init{
	$parameter_datatypes_list = new List<string>();
} : (parameter{$parameter_datatypes_list.Add($parameter.dt);} (FASLA parameter {$parameter_datatypes_list.Add($parameter.dt);})*)?;

argument[SymbolTable st]: expression[st];
argumentList[SymbolTable st] returns[int length, string[] datatypes] locals[List<string> datatypes_list] @init {$length = 0; $datatypes_list = new List<string>();}:
(argument[st] {$length++;}(FASLA argument[st]{$length++;})*)?;




expression[SymbolTable st] returns [string expr_type, string expr_datatype]: 
ID RP argumentList[st] LP sub_expression[st, ((FunctionInfo)st.getSymbolInfo($ID.text).specificInfo).return_type] 
{
	SymbolInfo symbol_info_of_id = st.getSymbolInfo($ID.text);
	// check if the symbol is for a function.
	if(symbol_info_of_id.type != SymbolType.SymbolOfFunction) 
	{
		throw new Exception("ID is not of a function");
	}
	var symbolSpecificInfo = (FunctionInfo) symbol_info_of_id.specificInfo;
	// check the number of arguments match the number of parameters.
	
	if($argumentList.length != symbolSpecificInfo.parameter_datatypes.Length)
	{
		throw new Exception("Number of arguments is not equal to number of parameters");
	}
	// set the type of expr to function call.
	$expr_type = $sub_expression.expr_type == "" ? "function_call_expr": $sub_expression.expr_type;
	// set the datatype of expr to the return type of the function.
	$expr_datatype = symbolSpecificInfo.return_type;
}
|
MINUS expression[st] sub_expression[st, "int"] 
{
	// set the expression type to minus datatype of the datatype of sub_expression.
	$expr_type = $sub_expression.expr_type == "" ? "minus_expr":$sub_expression.expr_type ;

	// set the expression datatype to int.
	$expr_datatype = "int";
}
|
LNOT expression[st] sub_expression[st, "int"]
{
	// set the expression type to lnot_expr or sub_expression type.
	$expr_type = $sub_expression.expr_type == "" ? "lnot_expr": $sub_expression.expr_type;
	// set the expression datatype to int.
	$expr_datatype = "int";
}
|
RP expression[st] LP sub_expression[st, $expression.expr_type]
{
	// set the expression type to paren_expr or sub_expression type.
	$expr_type = $sub_expression.expr_type == "" ? "paren_expr" :$sub_expression.expr_type ;
}
|
Int_literal	sub_expression[st, "uint"] {$expr_type = $sub_expression.expr_type == "" ? "int_lit_expr": $sub_expression.expr_type;}|
ID
{
	var symbolInfo = $st.getSymbolInfo($ID.text);
	if(symbolInfo.type != SymbolType.SymbolOfGlobalVariable || 
	symbolInfo.type != SymbolType.SymbolOfLocalVariable || 
	symbolInfo.type != SymbolType.SymbolOfParameter ) {
		throw new Exception("Identifier is not for variable");
	}
} 
sub_expression[st,((VarInfo)($st.getSymbolInfo($ID.text).specificInfo)).datatype] {
	$expr_type = $sub_expression.expr_type == "" ? "variable_expr": $sub_expression.expr_type;
}
;



sub_expression[SymbolTable st, string pre_expr_datatype] returns[string expr_type, string sub_expression_datatype]:
DIVIDE expression[st] sub_expression[st,get_expr_type($expression.expr_datatype, $pre_expr_datatype)] {$expr_type = "divide_expr";}|
MULTIPLY expression[st] sub_expression[st,get_expr_type($expression.expr_datatype, $pre_expr_datatype)] {$expr_type = "multiply_expr";}| 
MINUS expression[st] sub_expression[st,get_expr_type($expression.expr_datatype, $pre_expr_datatype)] {$expr_type = "subtract_expr";}|
PLUS expression[st] sub_expression[st,get_expr_type($expression.expr_datatype, $pre_expr_datatype)] {$expr_type = "addition_expr";} |
comparison_op expression[st] sub_expression[st, "int"] {$expr_type = "comparison_expr";}|
equality_op expression[st] sub_expression[st,"int"] {$expr_type = "equality_expr";}|
LAND expression[st] sub_expression[st, "int"] {$expr_type = "land_expr";}|
LOR expression[st] sub_expression[st, "int"] {$expr_type = "lor_expr";}|{$expr_type = "";};


Int_literal: (
	'٠' |
	'١' |
	'٢' |
	'٣' |
	'٤' |
	'٥' |
	'٦' |
	'٧' |
	'٨' |
	'٩' 
)+;


comparison_op: (GTE_SYM | LTE_SYM | GT_SYM | LT_SYM);
equality_op : (EQUAL_SYM | NOTEQ_SYM);

statement[SymbolTable st]:
	assignmentStat[st] # assignment_Stat       
	| returnStat[st] # return_Stat	    
	| resultStat[st] # result_Stat		    
	| ifStat[st]	# if_Stat	    
	| whileStat[st]	# while_Stat       
	| varDecl[st]	# var_Decl_Stat
	// | expressionStat #expression_Stat
	| operationStat[st] #operation_Stat
	| commandStat[st] #command_Stat;


statementList[SymbolTable st] : statement[st]*;

// expressionStat: expression FASLA_MANQUOTA;

operationStat[SymbolTable st]: ID RP argumentList[st] LP FASLA_MANQUOTA;

assignmentStat[SymbolTable st]: ID ASSIGN_SYM expression[st] FASLA_MANQUOTA;

ifStat[SymbolTable st]: IF_KEYWORD RP expression[st] LP RCB statementList[st] LCB;

whileStat[SymbolTable st]:
	WHILE_KEYWORD RP expression[st] LP RCB statementList[st] LCB;

returnStat[SymbolTable st]: RET_KEYWORD FASLA_MANQUOTA;

resultStat[SymbolTable st]: RES_KEYWORD expression[st] FASLA_MANQUOTA;

varDecl[SymbolTable st]:
	datatype ID inititalization[st] FASLA_MANQUOTA;

commandStat[SymbolTable st]: command[st] FASLA_MANQUOTA;
	// | ENGLISH_INT_LITERAL;

LP: '(';
RP: ')';
LSB: '[';
RSB: ']';
LCB: '{';
RCB: '}';

// memory address operators
ADDRESS_OF_OPERATOR: '&:';
VALUE_INSIDE_OPERATOR: '*:';
SIZE_OF: 'حجم:';

// punctuation symbols.
// DOT: '.';
FASLA: '،';
FASLA_MANQUOTA: '؛';
// ARROW: '->';
COLON: ':';

// mathimatical symbols.
PLUS: '+';
MINUS: '-';
MULTIPLY: '×';
DIVIDE: '÷';
ARABIC_MODULS: '٪';
MODULUS: '%';

// logical operations
LAND: '&&';
LOR: '||';
LNOT: '!';

// Bitwise symbols.
SL_SYM: '<<';
SRA_SYM: '>>>';
SR_SYM: '>>';
BAND_SYM: '&';
BOR_SYM: '|';
BXOR_SYM: '^';
BNOT_SYM: '~';

// Relational symbols.
LTE_SYM: '<=';
GTE_SYM: '>=';
LT_SYM: '<';
GT_SYM: '>';
EQUAL_SYM: '==';
NOTEQ_SYM: '!=';

// operative symbols.
ASSIGN_SYM: '=';

// keywords
FUNC_KEYWORD: 'دالة';
OP_KEYWORD: 'عملية';

RET_KEYWORD: 'رجوع';
RES_KEYWORD: 'الناتج';

IF_KEYWORD: 'إذا' | 'اذا';
WHILE_KEYWORD: 'طالما';

BREAK_KEYWORD: 'قطع';
CONTINUE_KEYWORRD: 'تخظى' | 'تخطي';

INT_DATA_TYPE: 'ص_٤';
UINT_DATA_TYPE: 'ط_٤';

BYTE_DATA_TYPE: 'ص_١';
UBYTE_DATA_TYPE: 'ط_١';

SHORT_DATA_TYPE: 'ص_٢';
USHORT_DATA_TYPE: 'ط_٢';

LONG_DATA_TYPE: 'ص_٨';
ULONG_DATA_TYPE: 'ط_٨';

BOOL_DATA_TYPE: 'منطقي';

// literal values.
// STRING_LITERAL:
// 	'"' (ESCAPED_CHARACTERS | ~('\u0022' | '\u0000'))* '"';

// fragment ESCAPED_CHARACTERS: ('//' | '/"' | '/0');

// CHARACTER_LITERAL:
	// '\'' (ESCAPED_CHARACTERS | ~('\u0027' | '\u0000')) '\'';

WHITE_SPACE: [\u0020\u0009\u000A\u000B\u000C\u000D] -> skip;


// Identifier regular expression.
ID: [a-zA-Zء-ي] [a-zA-Zء-ي0-9٠-٩_]*;

datatype:
	INT_DATA_TYPE
	| UINT_DATA_TYPE
	| BYTE_DATA_TYPE
	| UBYTE_DATA_TYPE
	| SHORT_DATA_TYPE
	| USHORT_DATA_TYPE
	| LONG_DATA_TYPE
	| ULONG_DATA_TYPE;

command[SymbolTable st]: (COLON ('إطبع' | 'اطبع')) expression[st];





// sub_expression:
// DIVIDE expression sub_exppression
// MULTIPLY expression sub_exppression
// MINUS expression sub_exppression
// PLUS expression sub_exppression
// comparison_op expression sub_exppression
// equality_op expression sub_exppression

// LAND expression sub_exppression
// LOR expression sub_exppression

// DIVIDE expression 
// MULTIPLY expression 
// MINUS expression 
// PLUS expression 
// comparison_op expression 
// equality_op expression 

// LAND expression 
// LOR expression;

// expression: 
// ID RP argumentList LP sub_exppression |
// MINUS expression sub_exppression |
// LNOT expression sub_exppression |
// RP expression LP sub_exppression |
// Int_literal	sub_exppression |
// ID sub_exppression |
// ID RP argumentList LP |
// MINUS expression | 
// LNOT expression |
// RP expression |
// Int_literal |
// ID
// ;
// expression
// :
	
// 	ID RP argumentList LP											# fun_call_expr
// 	// | expression RSB expression LSB									# arr_subscrip_expr
// 	| MINUS expression												# minus_expr
// 	| LNOT expression												# lnot_expr
// 	// | RP dataType LP expression										# casting_expr
// 	// | ADDRESS_OF_OPERATOR expression								# address_expr
// 	// | VALUE_INSIDE_OPERATOR expression								# indirection_expr
// 	// | SIZE_OF expression											# size_expr
// 	| expression DIVIDE expression									# divide_expr
// 	| expression MULTIPLY expression								# multiply_expr
// 	| expression MINUS expression									# subtraction_expr
// 	| expression PLUS expression									# add_expr
// 	// | expression SL_SYM expression									# shift_left_expr
// 	// | expression SR_SYM expression									# shift_right_expr
// 	| expression comparison_op expression							# comparison_expr
// 	| expression equality_op expression							# equality_expr
// 	// | expression BAND_SYM expression								# band_expr
// 	// | expression (BXOR_SYM) expression								# bxor_expr
// 	// | expression (BOR_SYM) expression								# bor_expr
// 	| expression LAND expression									# land_expr
// 	| expression LOR expression									# lor_expr
// 	| RP expression LP												# parenthesis_expr
// 	| Int_literal													# int_literal_expr
// 	| ID															# variable_expr;

// int_literal: (
// 	'٠' |
// 	'١' |
// 	'٢' |
// 	'٣' |
// 	'٤' |
// 	'٥' |
// 	'٦' |
// 	'٧' |
// 	'٨' |
// 	'٩' )+ COLON PLUS? ('١' | '٢' | '٤' | '٨');

// arabicInt: IntLit arabicIntSize;
// arabicIntSize: COLON PLUS? NUMBER_OF_BYTES;
// NUMBER_OF_BYTES: (ONE | TWO | FOUR | EIGHT);
// IntLit: '٠' .. '٩';
// ONE: '١';
// TWO: '٢';
// FOUR: '٤';
// EIGHT: '٨';

// ENGLISH_INT_LITERAL: [0-9]+;
