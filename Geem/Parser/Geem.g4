grammar Geem;

program: (
		globalVarDecl
		| functionDecl
		| operationDecl
		| commandStat
	)+;

globalVarDecl:
	dataType ID inititalization FASLA_MANQUOTA;

inititalization: (ASSIGN_SYM expression);

functionDecl:
	FUNC_KEYWORD ID RP paramList LP COLON dataType RCB statementList LCB;

operationDecl:
	OP_KEYWORD ID RP paramList LP RCB statementList LCB;

parameter: dataType ID;
paramList: (parameter (FASLA parameter)*)?;

argument: expression;
argumentList: (argument (FASLA argument)*)?;

expression:
	
	ID RP argumentList LP											# fun_call_expr
	// | expression RSB expression LSB									# arr_subscrip_expr
	| MINUS expression												# minus_expr
	| LNOT expression												# lnot_expr
	// | RP dataType LP expression										# casting_expr
	// | ADDRESS_OF_OPERATOR expression								# address_expr
	// | VALUE_INSIDE_OPERATOR expression								# indirection_expr
	// | SIZE_OF expression											# size_expr
	| expression DIVIDE expression									# divide_expr
	| expression MULTIPLY expression								# multiply_expr
	| expression MINUS expression									# subtraction_expr
	| expression PLUS expression									# add_expr
	// | expression SL_SYM expression									# shift_left_expr
	// | expression SR_SYM expression									# shift_right_expr
	| expression comparison_op expression							# comparison_expr
	| expression equality_op expression								# equality_expr
	// | expression BAND_SYM expression								# band_expr
	// | expression (BXOR_SYM) expression								# bxor_expr
	// | expression (BOR_SYM) expression								# bor_expr
	| expression (LAND) expression									# land_expr
	| expression (LOR) expression									# lor_expr
	| RP expression LP												# parenthesis_expr
	| Int_literal													# int_literal_expr
	| ID															# variable_expr;

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

comparison_op: (GTE_SYM | LTE_SYM | GT_SYM | LT_SYM);
equality_op : (EQUAL_SYM | NOTEQ_SYM);

statement:
	assignmentStat # assignment_Stat       
	| returnStat # return_Stat	    
	| resultStat # result_Stat		    
	| ifStat	# if_Stat	    
	| whileStat	# while_Stat       
	| varDecl	# var_Decl_Stat
	// | expressionStat #expression_Stat
	| operationStat #operation_Stat
	| commandStat #command_Stat;


statementList : statement*;

// expressionStat: expression FASLA_MANQUOTA;

operationStat: ID RP argumentList LP FASLA_MANQUOTA;

assignmentStat: ID ASSIGN_SYM expression FASLA_MANQUOTA;

ifStat: IF_KEYWORD RP expression LP RCB statementList LCB;

whileStat:
	WHILE_KEYWORD RP expression LP RCB statementList LCB;

returnStat: RET_KEYWORD FASLA_MANQUOTA;

resultStat: RES_KEYWORD expression FASLA_MANQUOTA;

varDecl:
	dataType ID inititalization FASLA_MANQUOTA;

commandStat: command FASLA_MANQUOTA;
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
ASSIGN_SYM: ':=';

// keywords
FUNC_KEYWORD: 'دالة';
OP_KEYWORD: 'عملية';

RET_KEYWORD: 'رجوع';
RES_KEYWORD: 'الناتج';

IF_KEYWORD: 'إذا' | 'اذا';
WHILE_KEYWORD: 'طالما';

BREAK_KEYWORD: 'قطع';
CONTINUE_KEYWORRD: 'تخظى' | 'تخطي';

INT_DATA_TYPE: 'صحيح';
UINT_DATA_TYPE: 'طبيعي';

// BYTE_DATA_TYPE: 'صحيح_١';
// UBYTE_DATA_TYPE: 'طبيعي_١';

// SHORT_DATA_TYPE: 'صحيح_٢';
// USHORT_DATA_TYPE: 'طبيعي_٢';

// LONG_DATA_TYPE: 'صحيح_٨';
// ULONG_DATA_TYPE: 'طبيعي_٨';

BOOL_DATA_TYPE: 'منطقي';

// literal values.
// STRING_LITERAL:
// 	'"' (ESCAPED_CHARACTERS | ~('\u0022' | '\u0000'))* '"';

// fragment ESCAPED_CHARACTERS: ('//' | '/"' | '/0');

// CHARACTER_LITERAL:
	// '\'' (ESCAPED_CHARACTERS | ~('\u0027' | '\u0000')) '\'';

WHITE_SPACE: [\u0020\u0009\u000A\u000B\u000C\u000D] -> skip;

// arabicInt: IntLit arabicIntSize;
// arabicIntSize: COLON PLUS? NUMBER_OF_BYTES;
// NUMBER_OF_BYTES: (ONE | TWO | FOUR | EIGHT);
// IntLit: '٠' .. '٩';
// ONE: '١';
// TWO: '٢';
// FOUR: '٤';
// EIGHT: '٨';

// ENGLISH_INT_LITERAL: [0-9]+;

// Identifier regular expression.
ID: [a-zA-Zء-ي] [a-zA-Zء-ي0-9٠-٩_]*;

dataType:
	INT_DATA_TYPE
	| UINT_DATA_TYPE;
	// | BYTE_DATA_TYPE
	// | UBYTE_DATA_TYPE
	// | SHORT_DATA_TYPE
	// | USHORT_DATA_TYPE
	// | LONG_DATA_TYPE
	// | ULONG_DATA_TYPE;

command: (COLON ('إطبع' | 'اطبع')) expression;