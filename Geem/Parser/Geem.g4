grammar Geem;
@lexer::header {
 using Geem.Infrastructure;	
}
@parser::header {
 using Geem.Infrastructure;	
}

program locals[SymbolTable st]: (
		globalVarDecl
		| functionDecl
		| operationDecl
		| commandStat
	)+;

globalVarDecl: datatype ID inititalization FASLA_MANQUOTA;

inititalization: (ASSIGN_SYM expression);

functionDecl locals[SymbolTable st]:
	FUNC_KEYWORD ID RP paramList LP COLON datatype RCB statementList LCB;

operationDecl locals[SymbolTable st]:
	OP_KEYWORD ID RP paramList LP RCB statementList LCB;

parameter locals[SymbolTable st]: datatype ID;
paramList: (parameter (FASLA parameter)*)?;

argument locals[SymbolTable st]: expression;
argumentList: (argument (FASLA argument)*)?;

expression locals[SymbolTable st, string expression_datatype]:
	ID RP argumentList LP # fun_call_expr
	// | expression RSB expression LSB									# arr_subscrip_expr
	| MINUS RP expression LP	# minus_expr
	| LNOT expression	# lnot_expr
	// | RP dataType LP expression # casting_expr | ADDRESS_OF_OPERATOR expression # address_expr |
	// VALUE_INSIDE_OPERATOR expression # indirection_expr | SIZE_OF expression # size_expr
	| expression DIVIDE expression		# divide_expr
	| expression MULTIPLY expression	# multiply_expr
	| expression MINUS expression		# subtraction_expr
	| expression PLUS expression		# add_expr
	// | expression SL_SYM expression # shift_left_expr | expression SR_SYM expression #
	// shift_right_expr
	| expression comparison_op expression	# comparison_expr
	// | expression equality_op expression		# equality_expr
	// | expression BAND_SYM expression # band_expr | expression (BXOR_SYM) expression # bxor_expr |
	// expression (BOR_SYM) expression # bor_expr
	| expression LAND expression	# land_expr
	| expression LOR expression		# lor_expr
	| RP expression LP				# parenthesis_expr
	| int_literal					# int_literal_expr
	| boolean_literal 				# boolean_literal_expr
	| ID							# variable_expr;


boolean_literal locals[bool value]: TRUE_KEYWORD | FALSE_KEYWORD;

comparison_op: (GTE_SYM | LTE_SYM | GT_SYM | LT_SYM | EQUAL_SYM | NOTEQ_SYM);

statement locals[SymbolTable st]:
	assignmentStat	# assignment_Stat
	| returnStat	# return_Stat
	| resultStat	# result_Stat
	| breakStat 	# break_Stat
	| continueStat 	# continue_Stat
	| ifStat		# if_Stat
	| whileStat		# while_Stat
	| varDecl		# var_Decl_Stat
	| operationStat	# operation_Stat
	| commandStat	# command_Stat
	;

statementList: statement*;


operationStat: ID RP argumentList LP FASLA_MANQUOTA;

assignmentStat: ID ASSIGN_SYM expression FASLA_MANQUOTA;

ifStat: IF_KEYWORD RP expression LP RCB statementList LCB;

whileStat: WHILE_KEYWORD RP expression LP RCB statementList LCB;

returnStat: RET_KEYWORD FASLA_MANQUOTA;

resultStat: RES_KEYWORD expression FASLA_MANQUOTA;

breakStat: BREAK_KEYWORD FASLA_MANQUOTA;

continueStat: CONTINUE_KEYWORRD FASLA_MANQUOTA;

varDecl locals [SymbolTable st]: datatype ID inititalization FASLA_MANQUOTA;

commandStat: command FASLA_MANQUOTA;

command: (COLON ('????????' | '????????')) expression;

LP: '(';
RP: ')';
LSB: '[';
RSB: ']';
LCB: '{';
RCB: '}';

// memory address operators
ADDRESS_OF_OPERATOR: '&:';
VALUE_INSIDE_OPERATOR: '*:';
SIZE_OF: '??????:';

// punctuation symbols. DOT: '.';
FASLA: '??';
FASLA_MANQUOTA: '??';
COLON: ':';

// mathimatical symbols.
PLUS: '+';
MINUS: '-';
MULTIPLY: '??';
DIVIDE: '??';
ARABIC_MODULS: '??';
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
FUNC_KEYWORD: '????????';
OP_KEYWORD: '??????????';

RET_KEYWORD: '????????';
RES_KEYWORD: '????????????';

IF_KEYWORD: '??????' | '??????';
WHILE_KEYWORD: '??????????';

TRUE_KEYWORD: '????????';
FALSE_KEYWORD: '??????' | '??????';
BREAK_KEYWORD: '??????';
CONTINUE_KEYWORRD: '????????' | '????????';

INT_DATA_TYPE: '??_??';
UINT_DATA_TYPE: '??_??';

BYTE_DATA_TYPE: '??_??';
UBYTE_DATA_TYPE: '??_??';

SHORT_DATA_TYPE: '??_??';
USHORT_DATA_TYPE: '??_??';

LONG_DATA_TYPE: '??_??';
ULONG_DATA_TYPE: '??_??';

BOOL_DATA_TYPE: '??????????';

// literal values. STRING_LITERAL: '"' (ESCAPED_CHARACTERS | ~('\u0022' | '\u0000'))* '"';

// fragment ESCAPED_CHARACTERS: ('//' | '/"' | '/0');

// CHARACTER_LITERAL: '\'' (ESCAPED_CHARACTERS | ~('\u0027' | '\u0000')) '\'';

WHITE_SPACE: [\u0020\u0009\u000A\u000B\u000C\u000D] -> skip;

datatype:
	INT_DATA_TYPE
	| UINT_DATA_TYPE
	| BYTE_DATA_TYPE
	| UBYTE_DATA_TYPE
	| SHORT_DATA_TYPE
	| USHORT_DATA_TYPE
	| LONG_DATA_TYPE
	| ULONG_DATA_TYPE
	| BOOL_DATA_TYPE;

int_literal locals[Object value]: '-'? (
		'??'
		| '??'
		| '??'
		| '??'
		| '??'
		| '??'
		| '??'
		| '??'
		| '??'
		| '??'
	)+ (':' ('+' | '-')? ('??'| '??'| '??' | '??'))?;


// Identifier regular expression.
ID: [a-zA-Z??-??] [a-zA-Z??-??0-9??-??_]*;
