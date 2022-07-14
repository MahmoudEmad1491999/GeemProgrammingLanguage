// Generated from /home/mahmoud/Documents/GeemProgrammingLanguage/Geem/Parser/Geem.g4 by ANTLR 4.9.2

 using Geem.Infrastructure;	

import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class GeemLexer extends Lexer {
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
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
			"T__9", "T__10", "T__11", "LP", "RP", "LSB", "RSB", "LCB", "RCB", "ADDRESS_OF_OPERATOR", 
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


	public GeemLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Geem.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2F\u016f\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\4=\t="+
		"\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\3\2\3\2\3\2\3\2\3\2\3"+
		"\3\3\3\3\3\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\t\3\t\3\n"+
		"\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3\21\3\21"+
		"\3\22\3\22\3\23\3\23\3\24\3\24\3\24\3\25\3\25\3\25\3\26\3\26\3\26\3\26"+
		"\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\34\3\34\3\35"+
		"\3\35\3\36\3\36\3\37\3\37\3 \3 \3 \3!\3!\3!\3\"\3\"\3#\3#\3#\3$\3$\3$"+
		"\3$\3%\3%\3%\3&\3&\3\'\3\'\3(\3(\3)\3)\3*\3*\3*\3+\3+\3+\3,\3,\3-\3-\3"+
		".\3.\3.\3/\3/\3/\3\60\3\60\3\61\3\61\3\61\3\61\3\61\3\62\3\62\3\62\3\62"+
		"\3\62\3\62\3\63\3\63\3\63\3\63\3\63\3\64\3\64\3\64\3\64\3\64\3\64\3\64"+
		"\3\65\3\65\3\65\3\65\3\65\3\65\5\65\u011c\n\65\3\66\3\66\3\66\3\66\3\66"+
		"\3\66\3\67\3\67\3\67\3\67\3\67\38\38\38\38\38\38\58\u012f\n8\39\39\39"+
		"\39\3:\3:\3:\3:\3:\3:\3:\3:\5:\u013d\n:\3;\3;\3;\3;\3<\3<\3<\3<\3=\3="+
		"\3=\3=\3>\3>\3>\3>\3?\3?\3?\3?\3@\3@\3@\3@\3A\3A\3A\3A\3B\3B\3B\3B\3C"+
		"\3C\3C\3C\3C\3C\3D\3D\3D\3D\3E\3E\7E\u016b\nE\fE\16E\u016e\13E\2\2F\3"+
		"\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37"+
		"\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67\359\36;\37="+
		" ?!A\"C#E$G%I&K\'M(O)Q*S+U,W-Y.[/]\60_\61a\62c\63e\64g\65i\66k\67m8o9"+
		"q:s;u<w=y>{?}@\177A\u0081B\u0083C\u0085D\u0087E\u0089F\3\2\5\4\2\13\17"+
		"\"\"\5\2C\\c|\u0623\u064c\b\2\62;C\\aac|\u0623\u064c\u0662\u066b\2\u0172"+
		"\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2"+
		"\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2"+
		"\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2"+
		"\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2"+
		"\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3"+
		"\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2"+
		"\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\2"+
		"U\3\2\2\2\2W\3\2\2\2\2Y\3\2\2\2\2[\3\2\2\2\2]\3\2\2\2\2_\3\2\2\2\2a\3"+
		"\2\2\2\2c\3\2\2\2\2e\3\2\2\2\2g\3\2\2\2\2i\3\2\2\2\2k\3\2\2\2\2m\3\2\2"+
		"\2\2o\3\2\2\2\2q\3\2\2\2\2s\3\2\2\2\2u\3\2\2\2\2w\3\2\2\2\2y\3\2\2\2\2"+
		"{\3\2\2\2\2}\3\2\2\2\2\177\3\2\2\2\2\u0081\3\2\2\2\2\u0083\3\2\2\2\2\u0085"+
		"\3\2\2\2\2\u0087\3\2\2\2\2\u0089\3\2\2\2\3\u008b\3\2\2\2\5\u0090\3\2\2"+
		"\2\7\u0095\3\2\2\2\t\u0097\3\2\2\2\13\u0099\3\2\2\2\r\u009b\3\2\2\2\17"+
		"\u009d\3\2\2\2\21\u009f\3\2\2\2\23\u00a1\3\2\2\2\25\u00a3\3\2\2\2\27\u00a5"+
		"\3\2\2\2\31\u00a7\3\2\2\2\33\u00a9\3\2\2\2\35\u00ab\3\2\2\2\37\u00ad\3"+
		"\2\2\2!\u00af\3\2\2\2#\u00b1\3\2\2\2%\u00b3\3\2\2\2\'\u00b5\3\2\2\2)\u00b8"+
		"\3\2\2\2+\u00bb\3\2\2\2-\u00c0\3\2\2\2/\u00c2\3\2\2\2\61\u00c4\3\2\2\2"+
		"\63\u00c6\3\2\2\2\65\u00c8\3\2\2\2\67\u00ca\3\2\2\29\u00cc\3\2\2\2;\u00ce"+
		"\3\2\2\2=\u00d0\3\2\2\2?\u00d2\3\2\2\2A\u00d5\3\2\2\2C\u00d8\3\2\2\2E"+
		"\u00da\3\2\2\2G\u00dd\3\2\2\2I\u00e1\3\2\2\2K\u00e4\3\2\2\2M\u00e6\3\2"+
		"\2\2O\u00e8\3\2\2\2Q\u00ea\3\2\2\2S\u00ec\3\2\2\2U\u00ef\3\2\2\2W\u00f2"+
		"\3\2\2\2Y\u00f4\3\2\2\2[\u00f6\3\2\2\2]\u00f9\3\2\2\2_\u00fc\3\2\2\2a"+
		"\u00fe\3\2\2\2c\u0103\3\2\2\2e\u0109\3\2\2\2g\u010e\3\2\2\2i\u011b\3\2"+
		"\2\2k\u011d\3\2\2\2m\u0123\3\2\2\2o\u012e\3\2\2\2q\u0130\3\2\2\2s\u013c"+
		"\3\2\2\2u\u013e\3\2\2\2w\u0142\3\2\2\2y\u0146\3\2\2\2{\u014a\3\2\2\2}"+
		"\u014e\3\2\2\2\177\u0152\3\2\2\2\u0081\u0156\3\2\2\2\u0083\u015a\3\2\2"+
		"\2\u0085\u015e\3\2\2\2\u0087\u0164\3\2\2\2\u0089\u0168\3\2\2\2\u008b\u008c"+
		"\7\u0627\2\2\u008c\u008d\7\u0639\2\2\u008d\u008e\7\u062a\2\2\u008e\u008f"+
		"\7\u063b\2\2\u008f\4\3\2\2\2\u0090\u0091\7\u0629\2\2\u0091\u0092\7\u0639"+
		"\2\2\u0092\u0093\7\u062a\2\2\u0093\u0094\7\u063b\2\2\u0094\6\3\2\2\2\u0095"+
		"\u0096\7\u0662\2\2\u0096\b\3\2\2\2\u0097\u0098\7\u0663\2\2\u0098\n\3\2"+
		"\2\2\u0099\u009a\7\u0664\2\2\u009a\f\3\2\2\2\u009b\u009c\7\u0665\2\2\u009c"+
		"\16\3\2\2\2\u009d\u009e\7\u0666\2\2\u009e\20\3\2\2\2\u009f\u00a0\7\u0667"+
		"\2\2\u00a0\22\3\2\2\2\u00a1\u00a2\7\u0668\2\2\u00a2\24\3\2\2\2\u00a3\u00a4"+
		"\7\u0669\2\2\u00a4\26\3\2\2\2\u00a5\u00a6\7\u066a\2\2\u00a6\30\3\2\2\2"+
		"\u00a7\u00a8\7\u066b\2\2\u00a8\32\3\2\2\2\u00a9\u00aa\7*\2\2\u00aa\34"+
		"\3\2\2\2\u00ab\u00ac\7+\2\2\u00ac\36\3\2\2\2\u00ad\u00ae\7]\2\2\u00ae"+
		" \3\2\2\2\u00af\u00b0\7_\2\2\u00b0\"\3\2\2\2\u00b1\u00b2\7}\2\2\u00b2"+
		"$\3\2\2\2\u00b3\u00b4\7\177\2\2\u00b4&\3\2\2\2\u00b5\u00b6\7(\2\2\u00b6"+
		"\u00b7\7<\2\2\u00b7(\3\2\2\2\u00b8\u00b9\7,\2\2\u00b9\u00ba\7<\2\2\u00ba"+
		"*\3\2\2\2\u00bb\u00bc\7\u062f\2\2\u00bc\u00bd\7\u062e\2\2\u00bd\u00be"+
		"\7\u0647\2\2\u00be\u00bf\7<\2\2\u00bf,\3\2\2\2\u00c0\u00c1\7\u060e\2\2"+
		"\u00c1.\3\2\2\2\u00c2\u00c3\7\u061d\2\2\u00c3\60\3\2\2\2\u00c4\u00c5\7"+
		"<\2\2\u00c5\62\3\2\2\2\u00c6\u00c7\7-\2\2\u00c7\64\3\2\2\2\u00c8\u00c9"+
		"\7/\2\2\u00c9\66\3\2\2\2\u00ca\u00cb\7\u00d9\2\2\u00cb8\3\2\2\2\u00cc"+
		"\u00cd\7\u00f9\2\2\u00cd:\3\2\2\2\u00ce\u00cf\7\u066c\2\2\u00cf<\3\2\2"+
		"\2\u00d0\u00d1\7\'\2\2\u00d1>\3\2\2\2\u00d2\u00d3\7(\2\2\u00d3\u00d4\7"+
		"(\2\2\u00d4@\3\2\2\2\u00d5\u00d6\7~\2\2\u00d6\u00d7\7~\2\2\u00d7B\3\2"+
		"\2\2\u00d8\u00d9\7#\2\2\u00d9D\3\2\2\2\u00da\u00db\7>\2\2\u00db\u00dc"+
		"\7>\2\2\u00dcF\3\2\2\2\u00dd\u00de\7@\2\2\u00de\u00df\7@\2\2\u00df\u00e0"+
		"\7@\2\2\u00e0H\3\2\2\2\u00e1\u00e2\7@\2\2\u00e2\u00e3\7@\2\2\u00e3J\3"+
		"\2\2\2\u00e4\u00e5\7(\2\2\u00e5L\3\2\2\2\u00e6\u00e7\7~\2\2\u00e7N\3\2"+
		"\2\2\u00e8\u00e9\7`\2\2\u00e9P\3\2\2\2\u00ea\u00eb\7\u0080\2\2\u00ebR"+
		"\3\2\2\2\u00ec\u00ed\7>\2\2\u00ed\u00ee\7?\2\2\u00eeT\3\2\2\2\u00ef\u00f0"+
		"\7@\2\2\u00f0\u00f1\7?\2\2\u00f1V\3\2\2\2\u00f2\u00f3\7>\2\2\u00f3X\3"+
		"\2\2\2\u00f4\u00f5\7@\2\2\u00f5Z\3\2\2\2\u00f6\u00f7\7?\2\2\u00f7\u00f8"+
		"\7?\2\2\u00f8\\\3\2\2\2\u00f9\u00fa\7#\2\2\u00fa\u00fb\7?\2\2\u00fb^\3"+
		"\2\2\2\u00fc\u00fd\7?\2\2\u00fd`\3\2\2\2\u00fe\u00ff\7\u0631\2\2\u00ff"+
		"\u0100\7\u0629\2\2\u0100\u0101\7\u0646\2\2\u0101\u0102\7\u062b\2\2\u0102"+
		"b\3\2\2\2\u0103\u0104\7\u063b\2\2\u0104\u0105\7\u0647\2\2\u0105\u0106"+
		"\7\u0646\2\2\u0106\u0107\7\u064c\2\2\u0107\u0108\7\u062b\2\2\u0108d\3"+
		"\2\2\2\u0109\u010a\7\u0633\2\2\u010a\u010b\7\u062e\2\2\u010b\u010c\7\u064a"+
		"\2\2\u010c\u010d\7\u063b\2\2\u010df\3\2\2\2\u010e\u010f\7\u0629\2\2\u010f"+
		"\u0110\7\u0646\2\2\u0110\u0111\7\u0648\2\2\u0111\u0112\7\u0629\2\2\u0112"+
		"\u0113\7\u062c\2\2\u0113\u0114\7\u062e\2\2\u0114h\3\2\2\2\u0115\u0116"+
		"\7\u0627\2\2\u0116\u0117\7\u0632\2\2\u0117\u011c\7\u0629\2\2\u0118\u0119"+
		"\7\u0629\2\2\u0119\u011a\7\u0632\2\2\u011a\u011c\7\u0629\2\2\u011b\u0115"+
		"\3\2\2\2\u011b\u0118\3\2\2\2\u011cj\3\2\2\2\u011d\u011e\7\u0639\2\2\u011e"+
		"\u011f\7\u0629\2\2\u011f\u0120\7\u0646\2\2\u0120\u0121\7\u0647\2\2\u0121"+
		"\u0122\7\u0629\2\2\u0122l\3\2\2\2\u0123\u0124\7\u0637\2\2\u0124\u0125"+
		"\7\u064a\2\2\u0125\u0126\7\u0629\2\2\u0126\u0127\7\u062a\2\2\u0127n\3"+
		"\2\2\2\u0128\u0129\7\u0630\2\2\u0129\u012a\7\u0639\2\2\u012a\u012f\7\u0629"+
		"\2\2\u012b\u012c\7\u0630\2\2\u012c\u012d\7\u0639\2\2\u012d\u012f\7\u0625"+
		"\2\2\u012e\u0128\3\2\2\2\u012e\u012b\3\2\2\2\u012fp\3\2\2\2\u0130\u0131"+
		"\7\u0644\2\2\u0131\u0132\7\u0639\2\2\u0132\u0133\7\u063b\2\2\u0133r\3"+
		"\2\2\2\u0134\u0135\7\u062c\2\2\u0135\u0136\7\u0630\2\2\u0136\u0137\7\u063a"+
		"\2\2\u0137\u013d\7\u064b\2\2\u0138\u0139\7\u062c\2\2\u0139\u013a\7\u0630"+
		"\2\2\u013a\u013b\7\u0639\2\2\u013b\u013d\7\u064c\2\2\u013c\u0134\3\2\2"+
		"\2\u013c\u0138\3\2\2\2\u013dt\3\2\2\2\u013e\u013f\7\u0637\2\2\u013f\u0140"+
		"\7a\2\2\u0140\u0141\7\u0666\2\2\u0141v\3\2\2\2\u0142\u0143\7\u0639\2\2"+
		"\u0143\u0144\7a\2\2\u0144\u0145\7\u0666\2\2\u0145x\3\2\2\2\u0146\u0147"+
		"\7\u0637\2\2\u0147\u0148\7a\2\2\u0148\u0149\7\u0663\2\2\u0149z\3\2\2\2"+
		"\u014a\u014b\7\u0639\2\2\u014b\u014c\7a\2\2\u014c\u014d\7\u0663\2\2\u014d"+
		"|\3\2\2\2\u014e\u014f\7\u0637\2\2\u014f\u0150\7a\2\2\u0150\u0151\7\u0664"+
		"\2\2\u0151~\3\2\2\2\u0152\u0153\7\u0639\2\2\u0153\u0154\7a\2\2\u0154\u0155"+
		"\7\u0664\2\2\u0155\u0080\3\2\2\2\u0156\u0157\7\u0637\2\2\u0157\u0158\7"+
		"a\2\2\u0158\u0159\7\u066a\2\2\u0159\u0082\3\2\2\2\u015a\u015b\7\u0639"+
		"\2\2\u015b\u015c\7a\2\2\u015c\u015d\7\u066a\2\2\u015d\u0084\3\2\2\2\u015e"+
		"\u015f\7\u0647\2\2\u015f\u0160\7\u0648\2\2\u0160\u0161\7\u0639\2\2\u0161"+
		"\u0162\7\u0644\2\2\u0162\u0163\7\u064c\2\2\u0163\u0086\3\2\2\2\u0164\u0165"+
		"\t\2\2\2\u0165\u0166\3\2\2\2\u0166\u0167\bD\2\2\u0167\u0088\3\2\2\2\u0168"+
		"\u016c\t\3\2\2\u0169\u016b\t\4\2\2\u016a\u0169\3\2\2\2\u016b\u016e\3\2"+
		"\2\2\u016c\u016a\3\2\2\2\u016c\u016d\3\2\2\2\u016d\u008a\3\2\2\2\u016e"+
		"\u016c\3\2\2\2\7\2\u011b\u012e\u013c\u016c\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}