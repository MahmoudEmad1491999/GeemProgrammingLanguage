// Generated from /home/mahmoud/Documents/GeemProgrammingLanguage/Geem/Parser/Geem.g4 by ANTLR 4.9.2

 using Geem.Infrastructure;	

import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class GeemParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, LP=13, RP=14, LSB=15, RSB=16, LCB=17, RCB=18, 
		ADDRESS_OF_OPERATOR=19, VALUE_INSIDE_OPERATOR=20, SIZE_OF=21, FASLA=22, 
		FASLA_MANQUOTA=23, COLON=24, PLUS=25, MINUS=26, MULTIPLY=27, DIVIDE=28, 
		ARABIC_MODULS=29, MODULUS=30, LAND=31, LOR=32, LNOT=33, SL_SYM=34, SRA_SYM=35, 
		SR_SYM=36, BAND_SYM=37, BOR_SYM=38, BXOR_SYM=39, BNOT_SYM=40, LTE_SYM=41, 
		GTE_SYM=42, LT_SYM=43, GT_SYM=44, EQUAL_SYM=45, NOTEQ_SYM=46, ASSIGN_SYM=47, 
		FUNC_KEYWORD=48, OP_KEYWORD=49, RET_KEYWORD=50, RES_KEYWORD=51, IF_KEYWORD=52, 
		WHILE_KEYWORD=53, TRUE_KEYWORD=54, FALSE_KEYWORD=55, BREAK_KEYWORD=56, 
		CONTINUE_KEYWORRD=57, INT_DATA_TYPE=58, UINT_DATA_TYPE=59, BYTE_DATA_TYPE=60, 
		UBYTE_DATA_TYPE=61, SHORT_DATA_TYPE=62, USHORT_DATA_TYPE=63, LONG_DATA_TYPE=64, 
		ULONG_DATA_TYPE=65, BOOL_DATA_TYPE=66, WHITE_SPACE=67, ID=68;
	public static final int
		RULE_program = 0, RULE_globalVarDecl = 1, RULE_inititalization = 2, RULE_functionDecl = 3, 
		RULE_operationDecl = 4, RULE_parameter = 5, RULE_paramList = 6, RULE_argument = 7, 
		RULE_argumentList = 8, RULE_expression = 9, RULE_boolean_literal = 10, 
		RULE_comparison_op = 11, RULE_statement = 12, RULE_statementList = 13, 
		RULE_operationStat = 14, RULE_assignmentStat = 15, RULE_ifStat = 16, RULE_whileStat = 17, 
		RULE_returnStat = 18, RULE_resultStat = 19, RULE_breakStat = 20, RULE_continueStat = 21, 
		RULE_varDecl = 22, RULE_commandStat = 23, RULE_command = 24, RULE_datatype = 25, 
		RULE_int_literal = 26;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "globalVarDecl", "inititalization", "functionDecl", "operationDecl", 
			"parameter", "paramList", "argument", "argumentList", "expression", "boolean_literal", 
			"comparison_op", "statement", "statementList", "operationStat", "assignmentStat", 
			"ifStat", "whileStat", "returnStat", "resultStat", "breakStat", "continueStat", 
			"varDecl", "commandStat", "command", "datatype", "int_literal"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'\u0625\u0637\u0628\u0639'", "'\u0627\u0637\u0628\u0639'", "'\u0660'", 
			"'\u0661'", "'\u0662'", "'\u0663'", "'\u0664'", "'\u0665'", "'\u0666'", 
			"'\u0667'", "'\u0668'", "'\u0669'", "'('", "')'", "'['", "']'", "'{'", 
			"'}'", "'&:'", "'*:'", "'\u062D\u062C\u0645:'", "'\u060C'", "'\u061B'", 
			"':'", "'+'", "'-'", "'\u00D7'", "'\u00F7'", "'\u066A'", "'%'", "'&&'", 
			"'||'", "'!'", "'<<'", "'>>>'", "'>>'", "'&'", "'|'", "'^'", "'~'", "'<='", 
			"'>='", "'<'", "'>'", "'=='", "'!='", "'='", "'\u062F\u0627\u0644\u0629'", 
			"'\u0639\u0645\u0644\u064A\u0629'", "'\u0631\u062C\u0648\u0639'", "'\u0627\u0644\u0646\u0627\u062A\u062C'", 
			null, "'\u0637\u0627\u0644\u0645\u0627'", "'\u0635\u0648\u0627\u0628'", 
			null, "'\u0642\u0637\u0639'", null, "'\u0635_\u0664'", "'\u0637_\u0664'", 
			"'\u0635_\u0661'", "'\u0637_\u0661'", "'\u0635_\u0662'", "'\u0637_\u0662'", 
			"'\u0635_\u0668'", "'\u0637_\u0668'", "'\u0645\u0646\u0637\u0642\u064A'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, "LP", "RP", "LSB", "RSB", "LCB", "RCB", "ADDRESS_OF_OPERATOR", 
			"VALUE_INSIDE_OPERATOR", "SIZE_OF", "FASLA", "FASLA_MANQUOTA", "COLON", 
			"PLUS", "MINUS", "MULTIPLY", "DIVIDE", "ARABIC_MODULS", "MODULUS", "LAND", 
			"LOR", "LNOT", "SL_SYM", "SRA_SYM", "SR_SYM", "BAND_SYM", "BOR_SYM", 
			"BXOR_SYM", "BNOT_SYM", "LTE_SYM", "GTE_SYM", "LT_SYM", "GT_SYM", "EQUAL_SYM", 
			"NOTEQ_SYM", "ASSIGN_SYM", "FUNC_KEYWORD", "OP_KEYWORD", "RET_KEYWORD", 
			"RES_KEYWORD", "IF_KEYWORD", "WHILE_KEYWORD", "TRUE_KEYWORD", "FALSE_KEYWORD", 
			"BREAK_KEYWORD", "CONTINUE_KEYWORRD", "INT_DATA_TYPE", "UINT_DATA_TYPE", 
			"BYTE_DATA_TYPE", "UBYTE_DATA_TYPE", "SHORT_DATA_TYPE", "USHORT_DATA_TYPE", 
			"LONG_DATA_TYPE", "ULONG_DATA_TYPE", "BOOL_DATA_TYPE", "WHITE_SPACE", 
			"ID"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "Geem.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public GeemParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public SymbolTable st;
		public List<GlobalVarDeclContext> globalVarDecl() {
			return getRuleContexts(GlobalVarDeclContext.class);
		}
		public GlobalVarDeclContext globalVarDecl(int i) {
			return getRuleContext(GlobalVarDeclContext.class,i);
		}
		public List<FunctionDeclContext> functionDecl() {
			return getRuleContexts(FunctionDeclContext.class);
		}
		public FunctionDeclContext functionDecl(int i) {
			return getRuleContext(FunctionDeclContext.class,i);
		}
		public List<OperationDeclContext> operationDecl() {
			return getRuleContexts(OperationDeclContext.class);
		}
		public OperationDeclContext operationDecl(int i) {
			return getRuleContext(OperationDeclContext.class,i);
		}
		public List<CommandStatContext> commandStat() {
			return getRuleContexts(CommandStatContext.class);
		}
		public CommandStatContext commandStat(int i) {
			return getRuleContext(CommandStatContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(58); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				setState(58);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case INT_DATA_TYPE:
				case UINT_DATA_TYPE:
				case BYTE_DATA_TYPE:
				case UBYTE_DATA_TYPE:
				case SHORT_DATA_TYPE:
				case USHORT_DATA_TYPE:
				case LONG_DATA_TYPE:
				case ULONG_DATA_TYPE:
				case BOOL_DATA_TYPE:
					{
					setState(54);
					globalVarDecl();
					}
					break;
				case FUNC_KEYWORD:
					{
					setState(55);
					functionDecl();
					}
					break;
				case OP_KEYWORD:
					{
					setState(56);
					operationDecl();
					}
					break;
				case COLON:
					{
					setState(57);
					commandStat();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(60); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( ((((_la - 24)) & ~0x3f) == 0 && ((1L << (_la - 24)) & ((1L << (COLON - 24)) | (1L << (FUNC_KEYWORD - 24)) | (1L << (OP_KEYWORD - 24)) | (1L << (INT_DATA_TYPE - 24)) | (1L << (UINT_DATA_TYPE - 24)) | (1L << (BYTE_DATA_TYPE - 24)) | (1L << (UBYTE_DATA_TYPE - 24)) | (1L << (SHORT_DATA_TYPE - 24)) | (1L << (USHORT_DATA_TYPE - 24)) | (1L << (LONG_DATA_TYPE - 24)) | (1L << (ULONG_DATA_TYPE - 24)) | (1L << (BOOL_DATA_TYPE - 24)))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class GlobalVarDeclContext extends ParserRuleContext {
		public DatatypeContext datatype() {
			return getRuleContext(DatatypeContext.class,0);
		}
		public TerminalNode ID() { return getToken(GeemParser.ID, 0); }
		public InititalizationContext inititalization() {
			return getRuleContext(InititalizationContext.class,0);
		}
		public TerminalNode FASLA_MANQUOTA() { return getToken(GeemParser.FASLA_MANQUOTA, 0); }
		public GlobalVarDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_globalVarDecl; }
	}

	public final GlobalVarDeclContext globalVarDecl() throws RecognitionException {
		GlobalVarDeclContext _localctx = new GlobalVarDeclContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_globalVarDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(62);
			datatype();
			setState(63);
			match(ID);
			setState(64);
			inititalization();
			setState(65);
			match(FASLA_MANQUOTA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class InititalizationContext extends ParserRuleContext {
		public TerminalNode ASSIGN_SYM() { return getToken(GeemParser.ASSIGN_SYM, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public InititalizationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_inititalization; }
	}

	public final InititalizationContext inititalization() throws RecognitionException {
		InititalizationContext _localctx = new InititalizationContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_inititalization);
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(67);
			match(ASSIGN_SYM);
			setState(68);
			expression(0);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionDeclContext extends ParserRuleContext {
		public SymbolTable st;
		public TerminalNode FUNC_KEYWORD() { return getToken(GeemParser.FUNC_KEYWORD, 0); }
		public TerminalNode ID() { return getToken(GeemParser.ID, 0); }
		public TerminalNode RP() { return getToken(GeemParser.RP, 0); }
		public ParamListContext paramList() {
			return getRuleContext(ParamListContext.class,0);
		}
		public TerminalNode LP() { return getToken(GeemParser.LP, 0); }
		public TerminalNode COLON() { return getToken(GeemParser.COLON, 0); }
		public DatatypeContext datatype() {
			return getRuleContext(DatatypeContext.class,0);
		}
		public TerminalNode RCB() { return getToken(GeemParser.RCB, 0); }
		public StatementListContext statementList() {
			return getRuleContext(StatementListContext.class,0);
		}
		public TerminalNode LCB() { return getToken(GeemParser.LCB, 0); }
		public FunctionDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionDecl; }
	}

	public final FunctionDeclContext functionDecl() throws RecognitionException {
		FunctionDeclContext _localctx = new FunctionDeclContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_functionDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(70);
			match(FUNC_KEYWORD);
			setState(71);
			match(ID);
			setState(72);
			match(RP);
			setState(73);
			paramList();
			setState(74);
			match(LP);
			setState(75);
			match(COLON);
			setState(76);
			datatype();
			setState(77);
			match(RCB);
			setState(78);
			statementList();
			setState(79);
			match(LCB);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OperationDeclContext extends ParserRuleContext {
		public SymbolTable st;
		public TerminalNode OP_KEYWORD() { return getToken(GeemParser.OP_KEYWORD, 0); }
		public TerminalNode ID() { return getToken(GeemParser.ID, 0); }
		public TerminalNode RP() { return getToken(GeemParser.RP, 0); }
		public ParamListContext paramList() {
			return getRuleContext(ParamListContext.class,0);
		}
		public TerminalNode LP() { return getToken(GeemParser.LP, 0); }
		public TerminalNode RCB() { return getToken(GeemParser.RCB, 0); }
		public StatementListContext statementList() {
			return getRuleContext(StatementListContext.class,0);
		}
		public TerminalNode LCB() { return getToken(GeemParser.LCB, 0); }
		public OperationDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_operationDecl; }
	}

	public final OperationDeclContext operationDecl() throws RecognitionException {
		OperationDeclContext _localctx = new OperationDeclContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_operationDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(81);
			match(OP_KEYWORD);
			setState(82);
			match(ID);
			setState(83);
			match(RP);
			setState(84);
			paramList();
			setState(85);
			match(LP);
			setState(86);
			match(RCB);
			setState(87);
			statementList();
			setState(88);
			match(LCB);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterContext extends ParserRuleContext {
		public SymbolTable st;
		public DatatypeContext datatype() {
			return getRuleContext(DatatypeContext.class,0);
		}
		public TerminalNode ID() { return getToken(GeemParser.ID, 0); }
		public ParameterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameter; }
	}

	public final ParameterContext parameter() throws RecognitionException {
		ParameterContext _localctx = new ParameterContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_parameter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(90);
			datatype();
			setState(91);
			match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParamListContext extends ParserRuleContext {
		public List<ParameterContext> parameter() {
			return getRuleContexts(ParameterContext.class);
		}
		public ParameterContext parameter(int i) {
			return getRuleContext(ParameterContext.class,i);
		}
		public List<TerminalNode> FASLA() { return getTokens(GeemParser.FASLA); }
		public TerminalNode FASLA(int i) {
			return getToken(GeemParser.FASLA, i);
		}
		public ParamListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_paramList; }
	}

	public final ParamListContext paramList() throws RecognitionException {
		ParamListContext _localctx = new ParamListContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_paramList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(101);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (((((_la - 58)) & ~0x3f) == 0 && ((1L << (_la - 58)) & ((1L << (INT_DATA_TYPE - 58)) | (1L << (UINT_DATA_TYPE - 58)) | (1L << (BYTE_DATA_TYPE - 58)) | (1L << (UBYTE_DATA_TYPE - 58)) | (1L << (SHORT_DATA_TYPE - 58)) | (1L << (USHORT_DATA_TYPE - 58)) | (1L << (LONG_DATA_TYPE - 58)) | (1L << (ULONG_DATA_TYPE - 58)) | (1L << (BOOL_DATA_TYPE - 58)))) != 0)) {
				{
				setState(93);
				parameter();
				setState(98);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==FASLA) {
					{
					{
					setState(94);
					match(FASLA);
					setState(95);
					parameter();
					}
					}
					setState(100);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArgumentContext extends ParserRuleContext {
		public SymbolTable st;
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ArgumentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_argument; }
	}

	public final ArgumentContext argument() throws RecognitionException {
		ArgumentContext _localctx = new ArgumentContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_argument);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(103);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArgumentListContext extends ParserRuleContext {
		public List<ArgumentContext> argument() {
			return getRuleContexts(ArgumentContext.class);
		}
		public ArgumentContext argument(int i) {
			return getRuleContext(ArgumentContext.class,i);
		}
		public List<TerminalNode> FASLA() { return getTokens(GeemParser.FASLA); }
		public TerminalNode FASLA(int i) {
			return getToken(GeemParser.FASLA, i);
		}
		public ArgumentListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_argumentList; }
	}

	public final ArgumentListContext argumentList() throws RecognitionException {
		ArgumentListContext _localctx = new ArgumentListContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_argumentList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(113);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__2) | (1L << T__3) | (1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << T__8) | (1L << T__9) | (1L << T__10) | (1L << T__11) | (1L << RP) | (1L << MINUS) | (1L << LNOT) | (1L << TRUE_KEYWORD) | (1L << FALSE_KEYWORD))) != 0) || _la==ID) {
				{
				setState(105);
				argument();
				setState(110);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==FASLA) {
					{
					{
					setState(106);
					match(FASLA);
					setState(107);
					argument();
					}
					}
					setState(112);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public SymbolTable st;
		public string expression_datatype;
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
			this.st = ctx.st;
			this.expression_datatype = ctx.expression_datatype;
		}
	}
	public static class Lor_exprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode LOR() { return getToken(GeemParser.LOR, 0); }
		public Lor_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Add_exprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode PLUS() { return getToken(GeemParser.PLUS, 0); }
		public Add_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Land_exprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode LAND() { return getToken(GeemParser.LAND, 0); }
		public Land_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Boolean_literal_exprContext extends ExpressionContext {
		public Boolean_literalContext boolean_literal() {
			return getRuleContext(Boolean_literalContext.class,0);
		}
		public Boolean_literal_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Comparison_exprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public Comparison_opContext comparison_op() {
			return getRuleContext(Comparison_opContext.class,0);
		}
		public Comparison_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Multiply_exprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode MULTIPLY() { return getToken(GeemParser.MULTIPLY, 0); }
		public Multiply_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Variable_exprContext extends ExpressionContext {
		public TerminalNode ID() { return getToken(GeemParser.ID, 0); }
		public Variable_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Parenthesis_exprContext extends ExpressionContext {
		public TerminalNode RP() { return getToken(GeemParser.RP, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode LP() { return getToken(GeemParser.LP, 0); }
		public Parenthesis_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Int_literal_exprContext extends ExpressionContext {
		public Int_literalContext int_literal() {
			return getRuleContext(Int_literalContext.class,0);
		}
		public Int_literal_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Subtraction_exprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode MINUS() { return getToken(GeemParser.MINUS, 0); }
		public Subtraction_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Divide_exprContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode DIVIDE() { return getToken(GeemParser.DIVIDE, 0); }
		public Divide_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Fun_call_exprContext extends ExpressionContext {
		public TerminalNode ID() { return getToken(GeemParser.ID, 0); }
		public TerminalNode RP() { return getToken(GeemParser.RP, 0); }
		public ArgumentListContext argumentList() {
			return getRuleContext(ArgumentListContext.class,0);
		}
		public TerminalNode LP() { return getToken(GeemParser.LP, 0); }
		public Fun_call_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Minus_exprContext extends ExpressionContext {
		public TerminalNode MINUS() { return getToken(GeemParser.MINUS, 0); }
		public TerminalNode RP() { return getToken(GeemParser.RP, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode LP() { return getToken(GeemParser.LP, 0); }
		public Minus_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class Lnot_exprContext extends ExpressionContext {
		public TerminalNode LNOT() { return getToken(GeemParser.LNOT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Lnot_exprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 18;
		enterRecursionRule(_localctx, 18, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				{
				_localctx = new Fun_call_exprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(116);
				match(ID);
				setState(117);
				match(RP);
				setState(118);
				argumentList();
				setState(119);
				match(LP);
				}
				break;
			case 2:
				{
				_localctx = new Minus_exprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(121);
				match(MINUS);
				setState(122);
				match(RP);
				setState(123);
				expression(0);
				setState(124);
				match(LP);
				}
				break;
			case 3:
				{
				_localctx = new Lnot_exprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(126);
				match(LNOT);
				setState(127);
				expression(12);
				}
				break;
			case 4:
				{
				_localctx = new Parenthesis_exprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(128);
				match(RP);
				setState(129);
				expression(0);
				setState(130);
				match(LP);
				}
				break;
			case 5:
				{
				_localctx = new Int_literal_exprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(132);
				int_literal();
				}
				break;
			case 6:
				{
				_localctx = new Boolean_literal_exprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(133);
				boolean_literal();
				}
				break;
			case 7:
				{
				_localctx = new Variable_exprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(134);
				match(ID);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(161);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(159);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
					case 1:
						{
						_localctx = new Divide_exprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(137);
						if (!(precpred(_ctx, 11))) throw new FailedPredicateException(this, "precpred(_ctx, 11)");
						setState(138);
						match(DIVIDE);
						setState(139);
						expression(12);
						}
						break;
					case 2:
						{
						_localctx = new Multiply_exprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(140);
						if (!(precpred(_ctx, 10))) throw new FailedPredicateException(this, "precpred(_ctx, 10)");
						setState(141);
						match(MULTIPLY);
						setState(142);
						expression(11);
						}
						break;
					case 3:
						{
						_localctx = new Subtraction_exprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(143);
						if (!(precpred(_ctx, 9))) throw new FailedPredicateException(this, "precpred(_ctx, 9)");
						setState(144);
						match(MINUS);
						setState(145);
						expression(10);
						}
						break;
					case 4:
						{
						_localctx = new Add_exprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(146);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(147);
						match(PLUS);
						setState(148);
						expression(9);
						}
						break;
					case 5:
						{
						_localctx = new Comparison_exprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(149);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(150);
						comparison_op();
						setState(151);
						expression(8);
						}
						break;
					case 6:
						{
						_localctx = new Land_exprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(153);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(154);
						match(LAND);
						setState(155);
						expression(7);
						}
						break;
					case 7:
						{
						_localctx = new Lor_exprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(156);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(157);
						match(LOR);
						setState(158);
						expression(6);
						}
						break;
					}
					} 
				}
				setState(163);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class Boolean_literalContext extends ParserRuleContext {
		public bool value;
		public TerminalNode TRUE_KEYWORD() { return getToken(GeemParser.TRUE_KEYWORD, 0); }
		public TerminalNode FALSE_KEYWORD() { return getToken(GeemParser.FALSE_KEYWORD, 0); }
		public Boolean_literalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolean_literal; }
	}

	public final Boolean_literalContext boolean_literal() throws RecognitionException {
		Boolean_literalContext _localctx = new Boolean_literalContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_boolean_literal);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(164);
			_la = _input.LA(1);
			if ( !(_la==TRUE_KEYWORD || _la==FALSE_KEYWORD) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Comparison_opContext extends ParserRuleContext {
		public TerminalNode GTE_SYM() { return getToken(GeemParser.GTE_SYM, 0); }
		public TerminalNode LTE_SYM() { return getToken(GeemParser.LTE_SYM, 0); }
		public TerminalNode GT_SYM() { return getToken(GeemParser.GT_SYM, 0); }
		public TerminalNode LT_SYM() { return getToken(GeemParser.LT_SYM, 0); }
		public TerminalNode EQUAL_SYM() { return getToken(GeemParser.EQUAL_SYM, 0); }
		public TerminalNode NOTEQ_SYM() { return getToken(GeemParser.NOTEQ_SYM, 0); }
		public Comparison_opContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_comparison_op; }
	}

	public final Comparison_opContext comparison_op() throws RecognitionException {
		Comparison_opContext _localctx = new Comparison_opContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_comparison_op);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(166);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LTE_SYM) | (1L << GTE_SYM) | (1L << LT_SYM) | (1L << GT_SYM) | (1L << EQUAL_SYM) | (1L << NOTEQ_SYM))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public SymbolTable st;
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	 
		public StatementContext() { }
		public void copyFrom(StatementContext ctx) {
			super.copyFrom(ctx);
			this.st = ctx.st;
		}
	}
	public static class Command_StatContext extends StatementContext {
		public CommandStatContext commandStat() {
			return getRuleContext(CommandStatContext.class,0);
		}
		public Command_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class Break_StatContext extends StatementContext {
		public BreakStatContext breakStat() {
			return getRuleContext(BreakStatContext.class,0);
		}
		public Break_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class Var_Decl_StatContext extends StatementContext {
		public VarDeclContext varDecl() {
			return getRuleContext(VarDeclContext.class,0);
		}
		public Var_Decl_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class If_StatContext extends StatementContext {
		public IfStatContext ifStat() {
			return getRuleContext(IfStatContext.class,0);
		}
		public If_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class Return_StatContext extends StatementContext {
		public ReturnStatContext returnStat() {
			return getRuleContext(ReturnStatContext.class,0);
		}
		public Return_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class Continue_StatContext extends StatementContext {
		public ContinueStatContext continueStat() {
			return getRuleContext(ContinueStatContext.class,0);
		}
		public Continue_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class While_StatContext extends StatementContext {
		public WhileStatContext whileStat() {
			return getRuleContext(WhileStatContext.class,0);
		}
		public While_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class Result_StatContext extends StatementContext {
		public ResultStatContext resultStat() {
			return getRuleContext(ResultStatContext.class,0);
		}
		public Result_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class Operation_StatContext extends StatementContext {
		public OperationStatContext operationStat() {
			return getRuleContext(OperationStatContext.class,0);
		}
		public Operation_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}
	public static class Assignment_StatContext extends StatementContext {
		public AssignmentStatContext assignmentStat() {
			return getRuleContext(AssignmentStatContext.class,0);
		}
		public Assignment_StatContext(StatementContext ctx) { copyFrom(ctx); }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_statement);
		try {
			setState(178);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				_localctx = new Assignment_StatContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(168);
				assignmentStat();
				}
				break;
			case 2:
				_localctx = new Return_StatContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(169);
				returnStat();
				}
				break;
			case 3:
				_localctx = new Result_StatContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(170);
				resultStat();
				}
				break;
			case 4:
				_localctx = new Break_StatContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(171);
				breakStat();
				}
				break;
			case 5:
				_localctx = new Continue_StatContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(172);
				continueStat();
				}
				break;
			case 6:
				_localctx = new If_StatContext(_localctx);
				enterOuterAlt(_localctx, 6);
				{
				setState(173);
				ifStat();
				}
				break;
			case 7:
				_localctx = new While_StatContext(_localctx);
				enterOuterAlt(_localctx, 7);
				{
				setState(174);
				whileStat();
				}
				break;
			case 8:
				_localctx = new Var_Decl_StatContext(_localctx);
				enterOuterAlt(_localctx, 8);
				{
				setState(175);
				varDecl();
				}
				break;
			case 9:
				_localctx = new Operation_StatContext(_localctx);
				enterOuterAlt(_localctx, 9);
				{
				setState(176);
				operationStat();
				}
				break;
			case 10:
				_localctx = new Command_StatContext(_localctx);
				enterOuterAlt(_localctx, 10);
				{
				setState(177);
				commandStat();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementListContext extends ParserRuleContext {
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public StatementListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statementList; }
	}

	public final StatementListContext statementList() throws RecognitionException {
		StatementListContext _localctx = new StatementListContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_statementList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(183);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (((((_la - 24)) & ~0x3f) == 0 && ((1L << (_la - 24)) & ((1L << (COLON - 24)) | (1L << (RET_KEYWORD - 24)) | (1L << (RES_KEYWORD - 24)) | (1L << (IF_KEYWORD - 24)) | (1L << (WHILE_KEYWORD - 24)) | (1L << (BREAK_KEYWORD - 24)) | (1L << (CONTINUE_KEYWORRD - 24)) | (1L << (INT_DATA_TYPE - 24)) | (1L << (UINT_DATA_TYPE - 24)) | (1L << (BYTE_DATA_TYPE - 24)) | (1L << (UBYTE_DATA_TYPE - 24)) | (1L << (SHORT_DATA_TYPE - 24)) | (1L << (USHORT_DATA_TYPE - 24)) | (1L << (LONG_DATA_TYPE - 24)) | (1L << (ULONG_DATA_TYPE - 24)) | (1L << (BOOL_DATA_TYPE - 24)) | (1L << (ID - 24)))) != 0)) {
				{
				{
				setState(180);
				statement();
				}
				}
				setState(185);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OperationStatContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(GeemParser.ID, 0); }
		public TerminalNode RP() { return getToken(GeemParser.RP, 0); }
		public ArgumentListContext argumentList() {
			return getRuleContext(ArgumentListContext.class,0);
		}
		public TerminalNode LP() { return getToken(GeemParser.LP, 0); }
		public TerminalNode FASLA_MANQUOTA() { return getToken(GeemParser.FASLA_MANQUOTA, 0); }
		public OperationStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_operationStat; }
	}

	public final OperationStatContext operationStat() throws RecognitionException {
		OperationStatContext _localctx = new OperationStatContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_operationStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(186);
			match(ID);
			setState(187);
			match(RP);
			setState(188);
			argumentList();
			setState(189);
			match(LP);
			setState(190);
			match(FASLA_MANQUOTA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentStatContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(GeemParser.ID, 0); }
		public TerminalNode ASSIGN_SYM() { return getToken(GeemParser.ASSIGN_SYM, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode FASLA_MANQUOTA() { return getToken(GeemParser.FASLA_MANQUOTA, 0); }
		public AssignmentStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignmentStat; }
	}

	public final AssignmentStatContext assignmentStat() throws RecognitionException {
		AssignmentStatContext _localctx = new AssignmentStatContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_assignmentStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(192);
			match(ID);
			setState(193);
			match(ASSIGN_SYM);
			setState(194);
			expression(0);
			setState(195);
			match(FASLA_MANQUOTA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IfStatContext extends ParserRuleContext {
		public TerminalNode IF_KEYWORD() { return getToken(GeemParser.IF_KEYWORD, 0); }
		public TerminalNode RP() { return getToken(GeemParser.RP, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode LP() { return getToken(GeemParser.LP, 0); }
		public TerminalNode RCB() { return getToken(GeemParser.RCB, 0); }
		public StatementListContext statementList() {
			return getRuleContext(StatementListContext.class,0);
		}
		public TerminalNode LCB() { return getToken(GeemParser.LCB, 0); }
		public IfStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifStat; }
	}

	public final IfStatContext ifStat() throws RecognitionException {
		IfStatContext _localctx = new IfStatContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_ifStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(197);
			match(IF_KEYWORD);
			setState(198);
			match(RP);
			setState(199);
			expression(0);
			setState(200);
			match(LP);
			setState(201);
			match(RCB);
			setState(202);
			statementList();
			setState(203);
			match(LCB);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class WhileStatContext extends ParserRuleContext {
		public TerminalNode WHILE_KEYWORD() { return getToken(GeemParser.WHILE_KEYWORD, 0); }
		public TerminalNode RP() { return getToken(GeemParser.RP, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode LP() { return getToken(GeemParser.LP, 0); }
		public TerminalNode RCB() { return getToken(GeemParser.RCB, 0); }
		public StatementListContext statementList() {
			return getRuleContext(StatementListContext.class,0);
		}
		public TerminalNode LCB() { return getToken(GeemParser.LCB, 0); }
		public WhileStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileStat; }
	}

	public final WhileStatContext whileStat() throws RecognitionException {
		WhileStatContext _localctx = new WhileStatContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_whileStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(205);
			match(WHILE_KEYWORD);
			setState(206);
			match(RP);
			setState(207);
			expression(0);
			setState(208);
			match(LP);
			setState(209);
			match(RCB);
			setState(210);
			statementList();
			setState(211);
			match(LCB);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReturnStatContext extends ParserRuleContext {
		public TerminalNode RET_KEYWORD() { return getToken(GeemParser.RET_KEYWORD, 0); }
		public TerminalNode FASLA_MANQUOTA() { return getToken(GeemParser.FASLA_MANQUOTA, 0); }
		public ReturnStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnStat; }
	}

	public final ReturnStatContext returnStat() throws RecognitionException {
		ReturnStatContext _localctx = new ReturnStatContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_returnStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(213);
			match(RET_KEYWORD);
			setState(214);
			match(FASLA_MANQUOTA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ResultStatContext extends ParserRuleContext {
		public TerminalNode RES_KEYWORD() { return getToken(GeemParser.RES_KEYWORD, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode FASLA_MANQUOTA() { return getToken(GeemParser.FASLA_MANQUOTA, 0); }
		public ResultStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_resultStat; }
	}

	public final ResultStatContext resultStat() throws RecognitionException {
		ResultStatContext _localctx = new ResultStatContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_resultStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(216);
			match(RES_KEYWORD);
			setState(217);
			expression(0);
			setState(218);
			match(FASLA_MANQUOTA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BreakStatContext extends ParserRuleContext {
		public TerminalNode BREAK_KEYWORD() { return getToken(GeemParser.BREAK_KEYWORD, 0); }
		public TerminalNode FASLA_MANQUOTA() { return getToken(GeemParser.FASLA_MANQUOTA, 0); }
		public BreakStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_breakStat; }
	}

	public final BreakStatContext breakStat() throws RecognitionException {
		BreakStatContext _localctx = new BreakStatContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_breakStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(220);
			match(BREAK_KEYWORD);
			setState(221);
			match(FASLA_MANQUOTA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ContinueStatContext extends ParserRuleContext {
		public TerminalNode CONTINUE_KEYWORRD() { return getToken(GeemParser.CONTINUE_KEYWORRD, 0); }
		public TerminalNode FASLA_MANQUOTA() { return getToken(GeemParser.FASLA_MANQUOTA, 0); }
		public ContinueStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_continueStat; }
	}

	public final ContinueStatContext continueStat() throws RecognitionException {
		ContinueStatContext _localctx = new ContinueStatContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_continueStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(223);
			match(CONTINUE_KEYWORRD);
			setState(224);
			match(FASLA_MANQUOTA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VarDeclContext extends ParserRuleContext {
		public SymbolTable st;
		public DatatypeContext datatype() {
			return getRuleContext(DatatypeContext.class,0);
		}
		public TerminalNode ID() { return getToken(GeemParser.ID, 0); }
		public InititalizationContext inititalization() {
			return getRuleContext(InititalizationContext.class,0);
		}
		public TerminalNode FASLA_MANQUOTA() { return getToken(GeemParser.FASLA_MANQUOTA, 0); }
		public VarDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_varDecl; }
	}

	public final VarDeclContext varDecl() throws RecognitionException {
		VarDeclContext _localctx = new VarDeclContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_varDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(226);
			datatype();
			setState(227);
			match(ID);
			setState(228);
			inititalization();
			setState(229);
			match(FASLA_MANQUOTA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CommandStatContext extends ParserRuleContext {
		public CommandContext command() {
			return getRuleContext(CommandContext.class,0);
		}
		public TerminalNode FASLA_MANQUOTA() { return getToken(GeemParser.FASLA_MANQUOTA, 0); }
		public CommandStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_commandStat; }
	}

	public final CommandStatContext commandStat() throws RecognitionException {
		CommandStatContext _localctx = new CommandStatContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_commandStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(231);
			command();
			setState(232);
			match(FASLA_MANQUOTA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CommandContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode COLON() { return getToken(GeemParser.COLON, 0); }
		public CommandContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_command; }
	}

	public final CommandContext command() throws RecognitionException {
		CommandContext _localctx = new CommandContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_command);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(234);
			match(COLON);
			setState(235);
			_la = _input.LA(1);
			if ( !(_la==T__0 || _la==T__1) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
			setState(237);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DatatypeContext extends ParserRuleContext {
		public TerminalNode INT_DATA_TYPE() { return getToken(GeemParser.INT_DATA_TYPE, 0); }
		public TerminalNode UINT_DATA_TYPE() { return getToken(GeemParser.UINT_DATA_TYPE, 0); }
		public TerminalNode BYTE_DATA_TYPE() { return getToken(GeemParser.BYTE_DATA_TYPE, 0); }
		public TerminalNode UBYTE_DATA_TYPE() { return getToken(GeemParser.UBYTE_DATA_TYPE, 0); }
		public TerminalNode SHORT_DATA_TYPE() { return getToken(GeemParser.SHORT_DATA_TYPE, 0); }
		public TerminalNode USHORT_DATA_TYPE() { return getToken(GeemParser.USHORT_DATA_TYPE, 0); }
		public TerminalNode LONG_DATA_TYPE() { return getToken(GeemParser.LONG_DATA_TYPE, 0); }
		public TerminalNode ULONG_DATA_TYPE() { return getToken(GeemParser.ULONG_DATA_TYPE, 0); }
		public TerminalNode BOOL_DATA_TYPE() { return getToken(GeemParser.BOOL_DATA_TYPE, 0); }
		public DatatypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_datatype; }
	}

	public final DatatypeContext datatype() throws RecognitionException {
		DatatypeContext _localctx = new DatatypeContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_datatype);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(239);
			_la = _input.LA(1);
			if ( !(((((_la - 58)) & ~0x3f) == 0 && ((1L << (_la - 58)) & ((1L << (INT_DATA_TYPE - 58)) | (1L << (UINT_DATA_TYPE - 58)) | (1L << (BYTE_DATA_TYPE - 58)) | (1L << (UBYTE_DATA_TYPE - 58)) | (1L << (SHORT_DATA_TYPE - 58)) | (1L << (USHORT_DATA_TYPE - 58)) | (1L << (LONG_DATA_TYPE - 58)) | (1L << (ULONG_DATA_TYPE - 58)) | (1L << (BOOL_DATA_TYPE - 58)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Int_literalContext extends ParserRuleContext {
		public Object value;
		public List<TerminalNode> MINUS() { return getTokens(GeemParser.MINUS); }
		public TerminalNode MINUS(int i) {
			return getToken(GeemParser.MINUS, i);
		}
		public TerminalNode COLON() { return getToken(GeemParser.COLON, 0); }
		public TerminalNode PLUS() { return getToken(GeemParser.PLUS, 0); }
		public Int_literalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_int_literal; }
	}

	public final Int_literalContext int_literal() throws RecognitionException {
		Int_literalContext _localctx = new Int_literalContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_int_literal);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(242);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==MINUS) {
				{
				setState(241);
				match(MINUS);
				}
			}

			setState(245); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(244);
					_la = _input.LA(1);
					if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__2) | (1L << T__3) | (1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << T__8) | (1L << T__9) | (1L << T__10) | (1L << T__11))) != 0)) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(247); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(254);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				{
				setState(249);
				match(COLON);
				setState(251);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PLUS || _la==MINUS) {
					{
					setState(250);
					_la = _input.LA(1);
					if ( !(_la==PLUS || _la==MINUS) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
				}

				setState(253);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__3) | (1L << T__4) | (1L << T__6) | (1L << T__10))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 9:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 11);
		case 1:
			return precpred(_ctx, 10);
		case 2:
			return precpred(_ctx, 9);
		case 3:
			return precpred(_ctx, 8);
		case 4:
			return precpred(_ctx, 7);
		case 5:
			return precpred(_ctx, 6);
		case 6:
			return precpred(_ctx, 5);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3F\u0103\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\3\2\3\2\3\2\3\2\6\2=\n\2\r\2\16\2>\3\3"+
		"\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3"+
		"\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\b\3\b\3\b\7\bc\n"+
		"\b\f\b\16\bf\13\b\5\bh\n\b\3\t\3\t\3\n\3\n\3\n\7\no\n\n\f\n\16\nr\13\n"+
		"\5\nt\n\n\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\5\13\u008a\n\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\7\13\u00a2\n\13\f\13\16\13\u00a5\13\13\3\f\3"+
		"\f\3\r\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u00b5"+
		"\n\16\3\17\7\17\u00b8\n\17\f\17\16\17\u00bb\13\17\3\20\3\20\3\20\3\20"+
		"\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\24\3\24\3\24\3\25\3\25"+
		"\3\25\3\25\3\26\3\26\3\26\3\27\3\27\3\27\3\30\3\30\3\30\3\30\3\30\3\31"+
		"\3\31\3\31\3\32\3\32\3\32\3\32\3\32\3\33\3\33\3\34\5\34\u00f5\n\34\3\34"+
		"\6\34\u00f8\n\34\r\34\16\34\u00f9\3\34\3\34\5\34\u00fe\n\34\3\34\5\34"+
		"\u0101\n\34\3\34\2\3\24\35\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$"+
		"&(*,.\60\62\64\66\2\t\3\289\3\2+\60\3\2\3\4\3\2<D\3\2\5\16\3\2\33\34\5"+
		"\2\6\7\t\t\r\r\2\u010a\2<\3\2\2\2\4@\3\2\2\2\6E\3\2\2\2\bH\3\2\2\2\nS"+
		"\3\2\2\2\f\\\3\2\2\2\16g\3\2\2\2\20i\3\2\2\2\22s\3\2\2\2\24\u0089\3\2"+
		"\2\2\26\u00a6\3\2\2\2\30\u00a8\3\2\2\2\32\u00b4\3\2\2\2\34\u00b9\3\2\2"+
		"\2\36\u00bc\3\2\2\2 \u00c2\3\2\2\2\"\u00c7\3\2\2\2$\u00cf\3\2\2\2&\u00d7"+
		"\3\2\2\2(\u00da\3\2\2\2*\u00de\3\2\2\2,\u00e1\3\2\2\2.\u00e4\3\2\2\2\60"+
		"\u00e9\3\2\2\2\62\u00ec\3\2\2\2\64\u00f1\3\2\2\2\66\u00f4\3\2\2\28=\5"+
		"\4\3\29=\5\b\5\2:=\5\n\6\2;=\5\60\31\2<8\3\2\2\2<9\3\2\2\2<:\3\2\2\2<"+
		";\3\2\2\2=>\3\2\2\2><\3\2\2\2>?\3\2\2\2?\3\3\2\2\2@A\5\64\33\2AB\7F\2"+
		"\2BC\5\6\4\2CD\7\31\2\2D\5\3\2\2\2EF\7\61\2\2FG\5\24\13\2G\7\3\2\2\2H"+
		"I\7\62\2\2IJ\7F\2\2JK\7\20\2\2KL\5\16\b\2LM\7\17\2\2MN\7\32\2\2NO\5\64"+
		"\33\2OP\7\24\2\2PQ\5\34\17\2QR\7\23\2\2R\t\3\2\2\2ST\7\63\2\2TU\7F\2\2"+
		"UV\7\20\2\2VW\5\16\b\2WX\7\17\2\2XY\7\24\2\2YZ\5\34\17\2Z[\7\23\2\2[\13"+
		"\3\2\2\2\\]\5\64\33\2]^\7F\2\2^\r\3\2\2\2_d\5\f\7\2`a\7\30\2\2ac\5\f\7"+
		"\2b`\3\2\2\2cf\3\2\2\2db\3\2\2\2de\3\2\2\2eh\3\2\2\2fd\3\2\2\2g_\3\2\2"+
		"\2gh\3\2\2\2h\17\3\2\2\2ij\5\24\13\2j\21\3\2\2\2kp\5\20\t\2lm\7\30\2\2"+
		"mo\5\20\t\2nl\3\2\2\2or\3\2\2\2pn\3\2\2\2pq\3\2\2\2qt\3\2\2\2rp\3\2\2"+
		"\2sk\3\2\2\2st\3\2\2\2t\23\3\2\2\2uv\b\13\1\2vw\7F\2\2wx\7\20\2\2xy\5"+
		"\22\n\2yz\7\17\2\2z\u008a\3\2\2\2{|\7\34\2\2|}\7\20\2\2}~\5\24\13\2~\177"+
		"\7\17\2\2\177\u008a\3\2\2\2\u0080\u0081\7#\2\2\u0081\u008a\5\24\13\16"+
		"\u0082\u0083\7\20\2\2\u0083\u0084\5\24\13\2\u0084\u0085\7\17\2\2\u0085"+
		"\u008a\3\2\2\2\u0086\u008a\5\66\34\2\u0087\u008a\5\26\f\2\u0088\u008a"+
		"\7F\2\2\u0089u\3\2\2\2\u0089{\3\2\2\2\u0089\u0080\3\2\2\2\u0089\u0082"+
		"\3\2\2\2\u0089\u0086\3\2\2\2\u0089\u0087\3\2\2\2\u0089\u0088\3\2\2\2\u008a"+
		"\u00a3\3\2\2\2\u008b\u008c\f\r\2\2\u008c\u008d\7\36\2\2\u008d\u00a2\5"+
		"\24\13\16\u008e\u008f\f\f\2\2\u008f\u0090\7\35\2\2\u0090\u00a2\5\24\13"+
		"\r\u0091\u0092\f\13\2\2\u0092\u0093\7\34\2\2\u0093\u00a2\5\24\13\f\u0094"+
		"\u0095\f\n\2\2\u0095\u0096\7\33\2\2\u0096\u00a2\5\24\13\13\u0097\u0098"+
		"\f\t\2\2\u0098\u0099\5\30\r\2\u0099\u009a\5\24\13\n\u009a\u00a2\3\2\2"+
		"\2\u009b\u009c\f\b\2\2\u009c\u009d\7!\2\2\u009d\u00a2\5\24\13\t\u009e"+
		"\u009f\f\7\2\2\u009f\u00a0\7\"\2\2\u00a0\u00a2\5\24\13\b\u00a1\u008b\3"+
		"\2\2\2\u00a1\u008e\3\2\2\2\u00a1\u0091\3\2\2\2\u00a1\u0094\3\2\2\2\u00a1"+
		"\u0097\3\2\2\2\u00a1\u009b\3\2\2\2\u00a1\u009e\3\2\2\2\u00a2\u00a5\3\2"+
		"\2\2\u00a3\u00a1\3\2\2\2\u00a3\u00a4\3\2\2\2\u00a4\25\3\2\2\2\u00a5\u00a3"+
		"\3\2\2\2\u00a6\u00a7\t\2\2\2\u00a7\27\3\2\2\2\u00a8\u00a9\t\3\2\2\u00a9"+
		"\31\3\2\2\2\u00aa\u00b5\5 \21\2\u00ab\u00b5\5&\24\2\u00ac\u00b5\5(\25"+
		"\2\u00ad\u00b5\5*\26\2\u00ae\u00b5\5,\27\2\u00af\u00b5\5\"\22\2\u00b0"+
		"\u00b5\5$\23\2\u00b1\u00b5\5.\30\2\u00b2\u00b5\5\36\20\2\u00b3\u00b5\5"+
		"\60\31\2\u00b4\u00aa\3\2\2\2\u00b4\u00ab\3\2\2\2\u00b4\u00ac\3\2\2\2\u00b4"+
		"\u00ad\3\2\2\2\u00b4\u00ae\3\2\2\2\u00b4\u00af\3\2\2\2\u00b4\u00b0\3\2"+
		"\2\2\u00b4\u00b1\3\2\2\2\u00b4\u00b2\3\2\2\2\u00b4\u00b3\3\2\2\2\u00b5"+
		"\33\3\2\2\2\u00b6\u00b8\5\32\16\2\u00b7\u00b6\3\2\2\2\u00b8\u00bb\3\2"+
		"\2\2\u00b9\u00b7\3\2\2\2\u00b9\u00ba\3\2\2\2\u00ba\35\3\2\2\2\u00bb\u00b9"+
		"\3\2\2\2\u00bc\u00bd\7F\2\2\u00bd\u00be\7\20\2\2\u00be\u00bf\5\22\n\2"+
		"\u00bf\u00c0\7\17\2\2\u00c0\u00c1\7\31\2\2\u00c1\37\3\2\2\2\u00c2\u00c3"+
		"\7F\2\2\u00c3\u00c4\7\61\2\2\u00c4\u00c5\5\24\13\2\u00c5\u00c6\7\31\2"+
		"\2\u00c6!\3\2\2\2\u00c7\u00c8\7\66\2\2\u00c8\u00c9\7\20\2\2\u00c9\u00ca"+
		"\5\24\13\2\u00ca\u00cb\7\17\2\2\u00cb\u00cc\7\24\2\2\u00cc\u00cd\5\34"+
		"\17\2\u00cd\u00ce\7\23\2\2\u00ce#\3\2\2\2\u00cf\u00d0\7\67\2\2\u00d0\u00d1"+
		"\7\20\2\2\u00d1\u00d2\5\24\13\2\u00d2\u00d3\7\17\2\2\u00d3\u00d4\7\24"+
		"\2\2\u00d4\u00d5\5\34\17\2\u00d5\u00d6\7\23\2\2\u00d6%\3\2\2\2\u00d7\u00d8"+
		"\7\64\2\2\u00d8\u00d9\7\31\2\2\u00d9\'\3\2\2\2\u00da\u00db\7\65\2\2\u00db"+
		"\u00dc\5\24\13\2\u00dc\u00dd\7\31\2\2\u00dd)\3\2\2\2\u00de\u00df\7:\2"+
		"\2\u00df\u00e0\7\31\2\2\u00e0+\3\2\2\2\u00e1\u00e2\7;\2\2\u00e2\u00e3"+
		"\7\31\2\2\u00e3-\3\2\2\2\u00e4\u00e5\5\64\33\2\u00e5\u00e6\7F\2\2\u00e6"+
		"\u00e7\5\6\4\2\u00e7\u00e8\7\31\2\2\u00e8/\3\2\2\2\u00e9\u00ea\5\62\32"+
		"\2\u00ea\u00eb\7\31\2\2\u00eb\61\3\2\2\2\u00ec\u00ed\7\32\2\2\u00ed\u00ee"+
		"\t\4\2\2\u00ee\u00ef\3\2\2\2\u00ef\u00f0\5\24\13\2\u00f0\63\3\2\2\2\u00f1"+
		"\u00f2\t\5\2\2\u00f2\65\3\2\2\2\u00f3\u00f5\7\34\2\2\u00f4\u00f3\3\2\2"+
		"\2\u00f4\u00f5\3\2\2\2\u00f5\u00f7\3\2\2\2\u00f6\u00f8\t\6\2\2\u00f7\u00f6"+
		"\3\2\2\2\u00f8\u00f9\3\2\2\2\u00f9\u00f7\3\2\2\2\u00f9\u00fa\3\2\2\2\u00fa"+
		"\u0100\3\2\2\2\u00fb\u00fd\7\32\2\2\u00fc\u00fe\t\7\2\2\u00fd\u00fc\3"+
		"\2\2\2\u00fd\u00fe\3\2\2\2\u00fe\u00ff\3\2\2\2\u00ff\u0101\t\b\2\2\u0100"+
		"\u00fb\3\2\2\2\u0100\u0101\3\2\2\2\u0101\67\3\2\2\2\21<>dgps\u0089\u00a1"+
		"\u00a3\u00b4\u00b9\u00f4\u00f9\u00fd\u0100";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}