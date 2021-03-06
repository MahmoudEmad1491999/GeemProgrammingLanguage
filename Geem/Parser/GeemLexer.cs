//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/mahmoud/Documents/GeemProgrammingLanguage/Geem/Parser/Geem.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Geem.Parser {

 using Geem.Infrastructure;	

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class GeemLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
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
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "LP", "RP", "LSB", "RSB", "LCB", "RCB", "ADDRESS_OF_OPERATOR", 
		"VALUE_INSIDE_OPERATOR", "SIZE_OF", "FASLA", "FASLA_MANQUOTA", "COLON", 
		"PLUS", "MINUS", "MULTIPLY", "DIVIDE", "ARABIC_MODULS", "MODULUS", "LAND", 
		"LOR", "LNOT", "SL_SYM", "SRA_SYM", "SR_SYM", "BAND_SYM", "BOR_SYM", "BXOR_SYM", 
		"BNOT_SYM", "LTE_SYM", "GTE_SYM", "LT_SYM", "GT_SYM", "EQUAL_SYM", "NOTEQ_SYM", 
		"ASSIGN_SYM", "FUNC_KEYWORD", "OP_KEYWORD", "RET_KEYWORD", "RES_KEYWORD", 
		"IF_KEYWORD", "WHILE_KEYWORD", "TRUE_KEYWORD", "FALSE_KEYWORD", "BREAK_KEYWORD", 
		"CONTINUE_KEYWORRD", "INT_DATA_TYPE", "UINT_DATA_TYPE", "BYTE_DATA_TYPE", 
		"UBYTE_DATA_TYPE", "SHORT_DATA_TYPE", "USHORT_DATA_TYPE", "LONG_DATA_TYPE", 
		"ULONG_DATA_TYPE", "BOOL_DATA_TYPE", "WHITE_SPACE", "ID"
	};


	public GeemLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public GeemLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
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
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, "LP", "RP", "LSB", "RSB", "LCB", "RCB", "ADDRESS_OF_OPERATOR", "VALUE_INSIDE_OPERATOR", 
		"SIZE_OF", "FASLA", "FASLA_MANQUOTA", "COLON", "PLUS", "MINUS", "MULTIPLY", 
		"DIVIDE", "ARABIC_MODULS", "MODULUS", "LAND", "LOR", "LNOT", "SL_SYM", 
		"SRA_SYM", "SR_SYM", "BAND_SYM", "BOR_SYM", "BXOR_SYM", "BNOT_SYM", "LTE_SYM", 
		"GTE_SYM", "LT_SYM", "GT_SYM", "EQUAL_SYM", "NOTEQ_SYM", "ASSIGN_SYM", 
		"FUNC_KEYWORD", "OP_KEYWORD", "RET_KEYWORD", "RES_KEYWORD", "IF_KEYWORD", 
		"WHILE_KEYWORD", "TRUE_KEYWORD", "FALSE_KEYWORD", "BREAK_KEYWORD", "CONTINUE_KEYWORRD", 
		"INT_DATA_TYPE", "UINT_DATA_TYPE", "BYTE_DATA_TYPE", "UBYTE_DATA_TYPE", 
		"SHORT_DATA_TYPE", "USHORT_DATA_TYPE", "LONG_DATA_TYPE", "ULONG_DATA_TYPE", 
		"BOOL_DATA_TYPE", "WHITE_SPACE", "ID"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Geem.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static GeemLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x46', '\x16F', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x4', ',', '\t', 
		',', '\x4', '-', '\t', '-', '\x4', '.', '\t', '.', '\x4', '/', '\t', '/', 
		'\x4', '\x30', '\t', '\x30', '\x4', '\x31', '\t', '\x31', '\x4', '\x32', 
		'\t', '\x32', '\x4', '\x33', '\t', '\x33', '\x4', '\x34', '\t', '\x34', 
		'\x4', '\x35', '\t', '\x35', '\x4', '\x36', '\t', '\x36', '\x4', '\x37', 
		'\t', '\x37', '\x4', '\x38', '\t', '\x38', '\x4', '\x39', '\t', '\x39', 
		'\x4', ':', '\t', ':', '\x4', ';', '\t', ';', '\x4', '<', '\t', '<', '\x4', 
		'=', '\t', '=', '\x4', '>', '\t', '>', '\x4', '?', '\t', '?', '\x4', '@', 
		'\t', '@', '\x4', '\x41', '\t', '\x41', '\x4', '\x42', '\t', '\x42', '\x4', 
		'\x43', '\t', '\x43', '\x4', '\x44', '\t', '\x44', '\x4', '\x45', '\t', 
		'\x45', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', 
		'\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', 
		'\v', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x15', 
		'\x3', '\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', 
		'\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', 
		'\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', '!', '\x3', '!', 
		'\x3', '\"', '\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '$', 
		'\x3', '$', '\x3', '$', '\x3', '$', '\x3', '%', '\x3', '%', '\x3', '%', 
		'\x3', '&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x3', '(', '\x3', '(', 
		'\x3', ')', '\x3', ')', '\x3', '*', '\x3', '*', '\x3', '*', '\x3', '+', 
		'\x3', '+', '\x3', '+', '\x3', ',', '\x3', ',', '\x3', '-', '\x3', '-', 
		'\x3', '.', '\x3', '.', '\x3', '.', '\x3', '/', '\x3', '/', '\x3', '/', 
		'\x3', '\x30', '\x3', '\x30', '\x3', '\x31', '\x3', '\x31', '\x3', '\x31', 
		'\x3', '\x31', '\x3', '\x31', '\x3', '\x32', '\x3', '\x32', '\x3', '\x32', 
		'\x3', '\x32', '\x3', '\x32', '\x3', '\x32', '\x3', '\x33', '\x3', '\x33', 
		'\x3', '\x33', '\x3', '\x33', '\x3', '\x33', '\x3', '\x34', '\x3', '\x34', 
		'\x3', '\x34', '\x3', '\x34', '\x3', '\x34', '\x3', '\x34', '\x3', '\x34', 
		'\x3', '\x35', '\x3', '\x35', '\x3', '\x35', '\x3', '\x35', '\x3', '\x35', 
		'\x3', '\x35', '\x5', '\x35', '\x11C', '\n', '\x35', '\x3', '\x36', '\x3', 
		'\x36', '\x3', '\x36', '\x3', '\x36', '\x3', '\x36', '\x3', '\x36', '\x3', 
		'\x37', '\x3', '\x37', '\x3', '\x37', '\x3', '\x37', '\x3', '\x37', '\x3', 
		'\x38', '\x3', '\x38', '\x3', '\x38', '\x3', '\x38', '\x3', '\x38', '\x3', 
		'\x38', '\x5', '\x38', '\x12F', '\n', '\x38', '\x3', '\x39', '\x3', '\x39', 
		'\x3', '\x39', '\x3', '\x39', '\x3', ':', '\x3', ':', '\x3', ':', '\x3', 
		':', '\x3', ':', '\x3', ':', '\x3', ':', '\x3', ':', '\x5', ':', '\x13D', 
		'\n', ':', '\x3', ';', '\x3', ';', '\x3', ';', '\x3', ';', '\x3', '<', 
		'\x3', '<', '\x3', '<', '\x3', '<', '\x3', '=', '\x3', '=', '\x3', '=', 
		'\x3', '=', '\x3', '>', '\x3', '>', '\x3', '>', '\x3', '>', '\x3', '?', 
		'\x3', '?', '\x3', '?', '\x3', '?', '\x3', '@', '\x3', '@', '\x3', '@', 
		'\x3', '@', '\x3', '\x41', '\x3', '\x41', '\x3', '\x41', '\x3', '\x41', 
		'\x3', '\x42', '\x3', '\x42', '\x3', '\x42', '\x3', '\x42', '\x3', '\x43', 
		'\x3', '\x43', '\x3', '\x43', '\x3', '\x43', '\x3', '\x43', '\x3', '\x43', 
		'\x3', '\x44', '\x3', '\x44', '\x3', '\x44', '\x3', '\x44', '\x3', '\x45', 
		'\x3', '\x45', '\a', '\x45', '\x16B', '\n', '\x45', '\f', '\x45', '\xE', 
		'\x45', '\x16E', '\v', '\x45', '\x2', '\x2', '\x46', '\x3', '\x3', '\x5', 
		'\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', 
		'\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', 
		'\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', '!', '\x12', '#', '\x13', 
		'%', '\x14', '\'', '\x15', ')', '\x16', '+', '\x17', '-', '\x18', '/', 
		'\x19', '\x31', '\x1A', '\x33', '\x1B', '\x35', '\x1C', '\x37', '\x1D', 
		'\x39', '\x1E', ';', '\x1F', '=', ' ', '?', '!', '\x41', '\"', '\x43', 
		'#', '\x45', '$', 'G', '%', 'I', '&', 'K', '\'', 'M', '(', 'O', ')', 'Q', 
		'*', 'S', '+', 'U', ',', 'W', '-', 'Y', '.', '[', '/', ']', '\x30', '_', 
		'\x31', '\x61', '\x32', '\x63', '\x33', '\x65', '\x34', 'g', '\x35', 'i', 
		'\x36', 'k', '\x37', 'm', '\x38', 'o', '\x39', 'q', ':', 's', ';', 'u', 
		'<', 'w', '=', 'y', '>', '{', '?', '}', '@', '\x7F', '\x41', '\x81', '\x42', 
		'\x83', '\x43', '\x85', '\x44', '\x87', '\x45', '\x89', '\x46', '\x3', 
		'\x2', '\x5', '\x4', '\x2', '\v', '\xF', '\"', '\"', '\x5', '\x2', '\x43', 
		'\\', '\x63', '|', '\x623', '\x64C', '\b', '\x2', '\x32', ';', '\x43', 
		'\\', '\x61', '\x61', '\x63', '|', '\x623', '\x64C', '\x662', '\x66B', 
		'\x2', '\x172', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', '\x2', 
		'\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '/', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', '\x3', 
		'\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', '\x2', '\x2', '=', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x41', '\x3', '\x2', '\x2', '\x2', '\x2', '\x43', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x45', '\x3', '\x2', '\x2', '\x2', '\x2', 'G', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'I', '\x3', '\x2', '\x2', '\x2', '\x2', 'K', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'M', '\x3', '\x2', '\x2', '\x2', '\x2', 'O', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'Q', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'S', '\x3', '\x2', '\x2', '\x2', '\x2', 'U', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'W', '\x3', '\x2', '\x2', '\x2', '\x2', 'Y', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '[', '\x3', '\x2', '\x2', '\x2', '\x2', ']', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '_', '\x3', '\x2', '\x2', '\x2', '\x2', '\x61', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x63', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x65', '\x3', '\x2', '\x2', '\x2', '\x2', 'g', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'i', '\x3', '\x2', '\x2', '\x2', '\x2', 'k', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'm', '\x3', '\x2', '\x2', '\x2', '\x2', 'o', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'q', '\x3', '\x2', '\x2', '\x2', '\x2', 's', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'u', '\x3', '\x2', '\x2', '\x2', '\x2', 'w', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'y', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'{', '\x3', '\x2', '\x2', '\x2', '\x2', '}', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x7F', '\x3', '\x2', '\x2', '\x2', '\x2', '\x81', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x83', '\x3', '\x2', '\x2', '\x2', '\x2', '\x85', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x87', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x89', '\x3', '\x2', '\x2', '\x2', '\x3', '\x8B', '\x3', '\x2', 
		'\x2', '\x2', '\x5', '\x90', '\x3', '\x2', '\x2', '\x2', '\a', '\x95', 
		'\x3', '\x2', '\x2', '\x2', '\t', '\x97', '\x3', '\x2', '\x2', '\x2', 
		'\v', '\x99', '\x3', '\x2', '\x2', '\x2', '\r', '\x9B', '\x3', '\x2', 
		'\x2', '\x2', '\xF', '\x9D', '\x3', '\x2', '\x2', '\x2', '\x11', '\x9F', 
		'\x3', '\x2', '\x2', '\x2', '\x13', '\xA1', '\x3', '\x2', '\x2', '\x2', 
		'\x15', '\xA3', '\x3', '\x2', '\x2', '\x2', '\x17', '\xA5', '\x3', '\x2', 
		'\x2', '\x2', '\x19', '\xA7', '\x3', '\x2', '\x2', '\x2', '\x1B', '\xA9', 
		'\x3', '\x2', '\x2', '\x2', '\x1D', '\xAB', '\x3', '\x2', '\x2', '\x2', 
		'\x1F', '\xAD', '\x3', '\x2', '\x2', '\x2', '!', '\xAF', '\x3', '\x2', 
		'\x2', '\x2', '#', '\xB1', '\x3', '\x2', '\x2', '\x2', '%', '\xB3', '\x3', 
		'\x2', '\x2', '\x2', '\'', '\xB5', '\x3', '\x2', '\x2', '\x2', ')', '\xB8', 
		'\x3', '\x2', '\x2', '\x2', '+', '\xBB', '\x3', '\x2', '\x2', '\x2', '-', 
		'\xC0', '\x3', '\x2', '\x2', '\x2', '/', '\xC2', '\x3', '\x2', '\x2', 
		'\x2', '\x31', '\xC4', '\x3', '\x2', '\x2', '\x2', '\x33', '\xC6', '\x3', 
		'\x2', '\x2', '\x2', '\x35', '\xC8', '\x3', '\x2', '\x2', '\x2', '\x37', 
		'\xCA', '\x3', '\x2', '\x2', '\x2', '\x39', '\xCC', '\x3', '\x2', '\x2', 
		'\x2', ';', '\xCE', '\x3', '\x2', '\x2', '\x2', '=', '\xD0', '\x3', '\x2', 
		'\x2', '\x2', '?', '\xD2', '\x3', '\x2', '\x2', '\x2', '\x41', '\xD5', 
		'\x3', '\x2', '\x2', '\x2', '\x43', '\xD8', '\x3', '\x2', '\x2', '\x2', 
		'\x45', '\xDA', '\x3', '\x2', '\x2', '\x2', 'G', '\xDD', '\x3', '\x2', 
		'\x2', '\x2', 'I', '\xE1', '\x3', '\x2', '\x2', '\x2', 'K', '\xE4', '\x3', 
		'\x2', '\x2', '\x2', 'M', '\xE6', '\x3', '\x2', '\x2', '\x2', 'O', '\xE8', 
		'\x3', '\x2', '\x2', '\x2', 'Q', '\xEA', '\x3', '\x2', '\x2', '\x2', 'S', 
		'\xEC', '\x3', '\x2', '\x2', '\x2', 'U', '\xEF', '\x3', '\x2', '\x2', 
		'\x2', 'W', '\xF2', '\x3', '\x2', '\x2', '\x2', 'Y', '\xF4', '\x3', '\x2', 
		'\x2', '\x2', '[', '\xF6', '\x3', '\x2', '\x2', '\x2', ']', '\xF9', '\x3', 
		'\x2', '\x2', '\x2', '_', '\xFC', '\x3', '\x2', '\x2', '\x2', '\x61', 
		'\xFE', '\x3', '\x2', '\x2', '\x2', '\x63', '\x103', '\x3', '\x2', '\x2', 
		'\x2', '\x65', '\x109', '\x3', '\x2', '\x2', '\x2', 'g', '\x10E', '\x3', 
		'\x2', '\x2', '\x2', 'i', '\x11B', '\x3', '\x2', '\x2', '\x2', 'k', '\x11D', 
		'\x3', '\x2', '\x2', '\x2', 'm', '\x123', '\x3', '\x2', '\x2', '\x2', 
		'o', '\x12E', '\x3', '\x2', '\x2', '\x2', 'q', '\x130', '\x3', '\x2', 
		'\x2', '\x2', 's', '\x13C', '\x3', '\x2', '\x2', '\x2', 'u', '\x13E', 
		'\x3', '\x2', '\x2', '\x2', 'w', '\x142', '\x3', '\x2', '\x2', '\x2', 
		'y', '\x146', '\x3', '\x2', '\x2', '\x2', '{', '\x14A', '\x3', '\x2', 
		'\x2', '\x2', '}', '\x14E', '\x3', '\x2', '\x2', '\x2', '\x7F', '\x152', 
		'\x3', '\x2', '\x2', '\x2', '\x81', '\x156', '\x3', '\x2', '\x2', '\x2', 
		'\x83', '\x15A', '\x3', '\x2', '\x2', '\x2', '\x85', '\x15E', '\x3', '\x2', 
		'\x2', '\x2', '\x87', '\x164', '\x3', '\x2', '\x2', '\x2', '\x89', '\x168', 
		'\x3', '\x2', '\x2', '\x2', '\x8B', '\x8C', '\a', '\x627', '\x2', '\x2', 
		'\x8C', '\x8D', '\a', '\x639', '\x2', '\x2', '\x8D', '\x8E', '\a', '\x62A', 
		'\x2', '\x2', '\x8E', '\x8F', '\a', '\x63B', '\x2', '\x2', '\x8F', '\x4', 
		'\x3', '\x2', '\x2', '\x2', '\x90', '\x91', '\a', '\x629', '\x2', '\x2', 
		'\x91', '\x92', '\a', '\x639', '\x2', '\x2', '\x92', '\x93', '\a', '\x62A', 
		'\x2', '\x2', '\x93', '\x94', '\a', '\x63B', '\x2', '\x2', '\x94', '\x6', 
		'\x3', '\x2', '\x2', '\x2', '\x95', '\x96', '\a', '\x662', '\x2', '\x2', 
		'\x96', '\b', '\x3', '\x2', '\x2', '\x2', '\x97', '\x98', '\a', '\x663', 
		'\x2', '\x2', '\x98', '\n', '\x3', '\x2', '\x2', '\x2', '\x99', '\x9A', 
		'\a', '\x664', '\x2', '\x2', '\x9A', '\f', '\x3', '\x2', '\x2', '\x2', 
		'\x9B', '\x9C', '\a', '\x665', '\x2', '\x2', '\x9C', '\xE', '\x3', '\x2', 
		'\x2', '\x2', '\x9D', '\x9E', '\a', '\x666', '\x2', '\x2', '\x9E', '\x10', 
		'\x3', '\x2', '\x2', '\x2', '\x9F', '\xA0', '\a', '\x667', '\x2', '\x2', 
		'\xA0', '\x12', '\x3', '\x2', '\x2', '\x2', '\xA1', '\xA2', '\a', '\x668', 
		'\x2', '\x2', '\xA2', '\x14', '\x3', '\x2', '\x2', '\x2', '\xA3', '\xA4', 
		'\a', '\x669', '\x2', '\x2', '\xA4', '\x16', '\x3', '\x2', '\x2', '\x2', 
		'\xA5', '\xA6', '\a', '\x66A', '\x2', '\x2', '\xA6', '\x18', '\x3', '\x2', 
		'\x2', '\x2', '\xA7', '\xA8', '\a', '\x66B', '\x2', '\x2', '\xA8', '\x1A', 
		'\x3', '\x2', '\x2', '\x2', '\xA9', '\xAA', '\a', '*', '\x2', '\x2', '\xAA', 
		'\x1C', '\x3', '\x2', '\x2', '\x2', '\xAB', '\xAC', '\a', '+', '\x2', 
		'\x2', '\xAC', '\x1E', '\x3', '\x2', '\x2', '\x2', '\xAD', '\xAE', '\a', 
		']', '\x2', '\x2', '\xAE', ' ', '\x3', '\x2', '\x2', '\x2', '\xAF', '\xB0', 
		'\a', '_', '\x2', '\x2', '\xB0', '\"', '\x3', '\x2', '\x2', '\x2', '\xB1', 
		'\xB2', '\a', '}', '\x2', '\x2', '\xB2', '$', '\x3', '\x2', '\x2', '\x2', 
		'\xB3', '\xB4', '\a', '\x7F', '\x2', '\x2', '\xB4', '&', '\x3', '\x2', 
		'\x2', '\x2', '\xB5', '\xB6', '\a', '(', '\x2', '\x2', '\xB6', '\xB7', 
		'\a', '<', '\x2', '\x2', '\xB7', '(', '\x3', '\x2', '\x2', '\x2', '\xB8', 
		'\xB9', '\a', ',', '\x2', '\x2', '\xB9', '\xBA', '\a', '<', '\x2', '\x2', 
		'\xBA', '*', '\x3', '\x2', '\x2', '\x2', '\xBB', '\xBC', '\a', '\x62F', 
		'\x2', '\x2', '\xBC', '\xBD', '\a', '\x62E', '\x2', '\x2', '\xBD', '\xBE', 
		'\a', '\x647', '\x2', '\x2', '\xBE', '\xBF', '\a', '<', '\x2', '\x2', 
		'\xBF', ',', '\x3', '\x2', '\x2', '\x2', '\xC0', '\xC1', '\a', '\x60E', 
		'\x2', '\x2', '\xC1', '.', '\x3', '\x2', '\x2', '\x2', '\xC2', '\xC3', 
		'\a', '\x61D', '\x2', '\x2', '\xC3', '\x30', '\x3', '\x2', '\x2', '\x2', 
		'\xC4', '\xC5', '\a', '<', '\x2', '\x2', '\xC5', '\x32', '\x3', '\x2', 
		'\x2', '\x2', '\xC6', '\xC7', '\a', '-', '\x2', '\x2', '\xC7', '\x34', 
		'\x3', '\x2', '\x2', '\x2', '\xC8', '\xC9', '\a', '/', '\x2', '\x2', '\xC9', 
		'\x36', '\x3', '\x2', '\x2', '\x2', '\xCA', '\xCB', '\a', '\xD9', '\x2', 
		'\x2', '\xCB', '\x38', '\x3', '\x2', '\x2', '\x2', '\xCC', '\xCD', '\a', 
		'\xF9', '\x2', '\x2', '\xCD', ':', '\x3', '\x2', '\x2', '\x2', '\xCE', 
		'\xCF', '\a', '\x66C', '\x2', '\x2', '\xCF', '<', '\x3', '\x2', '\x2', 
		'\x2', '\xD0', '\xD1', '\a', '\'', '\x2', '\x2', '\xD1', '>', '\x3', '\x2', 
		'\x2', '\x2', '\xD2', '\xD3', '\a', '(', '\x2', '\x2', '\xD3', '\xD4', 
		'\a', '(', '\x2', '\x2', '\xD4', '@', '\x3', '\x2', '\x2', '\x2', '\xD5', 
		'\xD6', '\a', '~', '\x2', '\x2', '\xD6', '\xD7', '\a', '~', '\x2', '\x2', 
		'\xD7', '\x42', '\x3', '\x2', '\x2', '\x2', '\xD8', '\xD9', '\a', '#', 
		'\x2', '\x2', '\xD9', '\x44', '\x3', '\x2', '\x2', '\x2', '\xDA', '\xDB', 
		'\a', '>', '\x2', '\x2', '\xDB', '\xDC', '\a', '>', '\x2', '\x2', '\xDC', 
		'\x46', '\x3', '\x2', '\x2', '\x2', '\xDD', '\xDE', '\a', '@', '\x2', 
		'\x2', '\xDE', '\xDF', '\a', '@', '\x2', '\x2', '\xDF', '\xE0', '\a', 
		'@', '\x2', '\x2', '\xE0', 'H', '\x3', '\x2', '\x2', '\x2', '\xE1', '\xE2', 
		'\a', '@', '\x2', '\x2', '\xE2', '\xE3', '\a', '@', '\x2', '\x2', '\xE3', 
		'J', '\x3', '\x2', '\x2', '\x2', '\xE4', '\xE5', '\a', '(', '\x2', '\x2', 
		'\xE5', 'L', '\x3', '\x2', '\x2', '\x2', '\xE6', '\xE7', '\a', '~', '\x2', 
		'\x2', '\xE7', 'N', '\x3', '\x2', '\x2', '\x2', '\xE8', '\xE9', '\a', 
		'`', '\x2', '\x2', '\xE9', 'P', '\x3', '\x2', '\x2', '\x2', '\xEA', '\xEB', 
		'\a', '\x80', '\x2', '\x2', '\xEB', 'R', '\x3', '\x2', '\x2', '\x2', '\xEC', 
		'\xED', '\a', '>', '\x2', '\x2', '\xED', '\xEE', '\a', '?', '\x2', '\x2', 
		'\xEE', 'T', '\x3', '\x2', '\x2', '\x2', '\xEF', '\xF0', '\a', '@', '\x2', 
		'\x2', '\xF0', '\xF1', '\a', '?', '\x2', '\x2', '\xF1', 'V', '\x3', '\x2', 
		'\x2', '\x2', '\xF2', '\xF3', '\a', '>', '\x2', '\x2', '\xF3', 'X', '\x3', 
		'\x2', '\x2', '\x2', '\xF4', '\xF5', '\a', '@', '\x2', '\x2', '\xF5', 
		'Z', '\x3', '\x2', '\x2', '\x2', '\xF6', '\xF7', '\a', '?', '\x2', '\x2', 
		'\xF7', '\xF8', '\a', '?', '\x2', '\x2', '\xF8', '\\', '\x3', '\x2', '\x2', 
		'\x2', '\xF9', '\xFA', '\a', '#', '\x2', '\x2', '\xFA', '\xFB', '\a', 
		'?', '\x2', '\x2', '\xFB', '^', '\x3', '\x2', '\x2', '\x2', '\xFC', '\xFD', 
		'\a', '?', '\x2', '\x2', '\xFD', '`', '\x3', '\x2', '\x2', '\x2', '\xFE', 
		'\xFF', '\a', '\x631', '\x2', '\x2', '\xFF', '\x100', '\a', '\x629', '\x2', 
		'\x2', '\x100', '\x101', '\a', '\x646', '\x2', '\x2', '\x101', '\x102', 
		'\a', '\x62B', '\x2', '\x2', '\x102', '\x62', '\x3', '\x2', '\x2', '\x2', 
		'\x103', '\x104', '\a', '\x63B', '\x2', '\x2', '\x104', '\x105', '\a', 
		'\x647', '\x2', '\x2', '\x105', '\x106', '\a', '\x646', '\x2', '\x2', 
		'\x106', '\x107', '\a', '\x64C', '\x2', '\x2', '\x107', '\x108', '\a', 
		'\x62B', '\x2', '\x2', '\x108', '\x64', '\x3', '\x2', '\x2', '\x2', '\x109', 
		'\x10A', '\a', '\x633', '\x2', '\x2', '\x10A', '\x10B', '\a', '\x62E', 
		'\x2', '\x2', '\x10B', '\x10C', '\a', '\x64A', '\x2', '\x2', '\x10C', 
		'\x10D', '\a', '\x63B', '\x2', '\x2', '\x10D', '\x66', '\x3', '\x2', '\x2', 
		'\x2', '\x10E', '\x10F', '\a', '\x629', '\x2', '\x2', '\x10F', '\x110', 
		'\a', '\x646', '\x2', '\x2', '\x110', '\x111', '\a', '\x648', '\x2', '\x2', 
		'\x111', '\x112', '\a', '\x629', '\x2', '\x2', '\x112', '\x113', '\a', 
		'\x62C', '\x2', '\x2', '\x113', '\x114', '\a', '\x62E', '\x2', '\x2', 
		'\x114', 'h', '\x3', '\x2', '\x2', '\x2', '\x115', '\x116', '\a', '\x627', 
		'\x2', '\x2', '\x116', '\x117', '\a', '\x632', '\x2', '\x2', '\x117', 
		'\x11C', '\a', '\x629', '\x2', '\x2', '\x118', '\x119', '\a', '\x629', 
		'\x2', '\x2', '\x119', '\x11A', '\a', '\x632', '\x2', '\x2', '\x11A', 
		'\x11C', '\a', '\x629', '\x2', '\x2', '\x11B', '\x115', '\x3', '\x2', 
		'\x2', '\x2', '\x11B', '\x118', '\x3', '\x2', '\x2', '\x2', '\x11C', 'j', 
		'\x3', '\x2', '\x2', '\x2', '\x11D', '\x11E', '\a', '\x639', '\x2', '\x2', 
		'\x11E', '\x11F', '\a', '\x629', '\x2', '\x2', '\x11F', '\x120', '\a', 
		'\x646', '\x2', '\x2', '\x120', '\x121', '\a', '\x647', '\x2', '\x2', 
		'\x121', '\x122', '\a', '\x629', '\x2', '\x2', '\x122', 'l', '\x3', '\x2', 
		'\x2', '\x2', '\x123', '\x124', '\a', '\x637', '\x2', '\x2', '\x124', 
		'\x125', '\a', '\x64A', '\x2', '\x2', '\x125', '\x126', '\a', '\x629', 
		'\x2', '\x2', '\x126', '\x127', '\a', '\x62A', '\x2', '\x2', '\x127', 
		'n', '\x3', '\x2', '\x2', '\x2', '\x128', '\x129', '\a', '\x630', '\x2', 
		'\x2', '\x129', '\x12A', '\a', '\x639', '\x2', '\x2', '\x12A', '\x12F', 
		'\a', '\x629', '\x2', '\x2', '\x12B', '\x12C', '\a', '\x630', '\x2', '\x2', 
		'\x12C', '\x12D', '\a', '\x639', '\x2', '\x2', '\x12D', '\x12F', '\a', 
		'\x625', '\x2', '\x2', '\x12E', '\x128', '\x3', '\x2', '\x2', '\x2', '\x12E', 
		'\x12B', '\x3', '\x2', '\x2', '\x2', '\x12F', 'p', '\x3', '\x2', '\x2', 
		'\x2', '\x130', '\x131', '\a', '\x644', '\x2', '\x2', '\x131', '\x132', 
		'\a', '\x639', '\x2', '\x2', '\x132', '\x133', '\a', '\x63B', '\x2', '\x2', 
		'\x133', 'r', '\x3', '\x2', '\x2', '\x2', '\x134', '\x135', '\a', '\x62C', 
		'\x2', '\x2', '\x135', '\x136', '\a', '\x630', '\x2', '\x2', '\x136', 
		'\x137', '\a', '\x63A', '\x2', '\x2', '\x137', '\x13D', '\a', '\x64B', 
		'\x2', '\x2', '\x138', '\x139', '\a', '\x62C', '\x2', '\x2', '\x139', 
		'\x13A', '\a', '\x630', '\x2', '\x2', '\x13A', '\x13B', '\a', '\x639', 
		'\x2', '\x2', '\x13B', '\x13D', '\a', '\x64C', '\x2', '\x2', '\x13C', 
		'\x134', '\x3', '\x2', '\x2', '\x2', '\x13C', '\x138', '\x3', '\x2', '\x2', 
		'\x2', '\x13D', 't', '\x3', '\x2', '\x2', '\x2', '\x13E', '\x13F', '\a', 
		'\x637', '\x2', '\x2', '\x13F', '\x140', '\a', '\x61', '\x2', '\x2', '\x140', 
		'\x141', '\a', '\x666', '\x2', '\x2', '\x141', 'v', '\x3', '\x2', '\x2', 
		'\x2', '\x142', '\x143', '\a', '\x639', '\x2', '\x2', '\x143', '\x144', 
		'\a', '\x61', '\x2', '\x2', '\x144', '\x145', '\a', '\x666', '\x2', '\x2', 
		'\x145', 'x', '\x3', '\x2', '\x2', '\x2', '\x146', '\x147', '\a', '\x637', 
		'\x2', '\x2', '\x147', '\x148', '\a', '\x61', '\x2', '\x2', '\x148', '\x149', 
		'\a', '\x663', '\x2', '\x2', '\x149', 'z', '\x3', '\x2', '\x2', '\x2', 
		'\x14A', '\x14B', '\a', '\x639', '\x2', '\x2', '\x14B', '\x14C', '\a', 
		'\x61', '\x2', '\x2', '\x14C', '\x14D', '\a', '\x663', '\x2', '\x2', '\x14D', 
		'|', '\x3', '\x2', '\x2', '\x2', '\x14E', '\x14F', '\a', '\x637', '\x2', 
		'\x2', '\x14F', '\x150', '\a', '\x61', '\x2', '\x2', '\x150', '\x151', 
		'\a', '\x664', '\x2', '\x2', '\x151', '~', '\x3', '\x2', '\x2', '\x2', 
		'\x152', '\x153', '\a', '\x639', '\x2', '\x2', '\x153', '\x154', '\a', 
		'\x61', '\x2', '\x2', '\x154', '\x155', '\a', '\x664', '\x2', '\x2', '\x155', 
		'\x80', '\x3', '\x2', '\x2', '\x2', '\x156', '\x157', '\a', '\x637', '\x2', 
		'\x2', '\x157', '\x158', '\a', '\x61', '\x2', '\x2', '\x158', '\x159', 
		'\a', '\x66A', '\x2', '\x2', '\x159', '\x82', '\x3', '\x2', '\x2', '\x2', 
		'\x15A', '\x15B', '\a', '\x639', '\x2', '\x2', '\x15B', '\x15C', '\a', 
		'\x61', '\x2', '\x2', '\x15C', '\x15D', '\a', '\x66A', '\x2', '\x2', '\x15D', 
		'\x84', '\x3', '\x2', '\x2', '\x2', '\x15E', '\x15F', '\a', '\x647', '\x2', 
		'\x2', '\x15F', '\x160', '\a', '\x648', '\x2', '\x2', '\x160', '\x161', 
		'\a', '\x639', '\x2', '\x2', '\x161', '\x162', '\a', '\x644', '\x2', '\x2', 
		'\x162', '\x163', '\a', '\x64C', '\x2', '\x2', '\x163', '\x86', '\x3', 
		'\x2', '\x2', '\x2', '\x164', '\x165', '\t', '\x2', '\x2', '\x2', '\x165', 
		'\x166', '\x3', '\x2', '\x2', '\x2', '\x166', '\x167', '\b', '\x44', '\x2', 
		'\x2', '\x167', '\x88', '\x3', '\x2', '\x2', '\x2', '\x168', '\x16C', 
		'\t', '\x3', '\x2', '\x2', '\x169', '\x16B', '\t', '\x4', '\x2', '\x2', 
		'\x16A', '\x169', '\x3', '\x2', '\x2', '\x2', '\x16B', '\x16E', '\x3', 
		'\x2', '\x2', '\x2', '\x16C', '\x16A', '\x3', '\x2', '\x2', '\x2', '\x16C', 
		'\x16D', '\x3', '\x2', '\x2', '\x2', '\x16D', '\x8A', '\x3', '\x2', '\x2', 
		'\x2', '\x16E', '\x16C', '\x3', '\x2', '\x2', '\x2', '\a', '\x2', '\x11B', 
		'\x12E', '\x13C', '\x16C', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Geem.Parser
