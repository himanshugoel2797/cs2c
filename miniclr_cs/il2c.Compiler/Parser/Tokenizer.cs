using System;
using System.Collections.Generic;

namespace il2c.Compiler.Parser
{
	public enum TokenType {
		LBrace,
		RBrace,
		LBracket,
		RBracket,
		LParen,
		RParen,
		Colon,
		Semi,
		Comma,
		Eq,
		Assign,
		NotEq,
		Not,
		PlusPlus,
		MinusMinus,
		MinusAssign,
		Deref,
		Minus,
		PlusAssign,
		Plus,
		CondOr,
		BitOrAssign,
		BitClearAssign,
		BitClear,
		CondAnd,
		BitAndAssign,
		BitAnd,
		BitOr,
		ShiftLeftAssign,
		ShiftLeft,
		LessOrEqual,
		Less,
		BitXorAssign,
		BitXor,
		MultAssign,
		CloseBlockComment,
		Mult,
		QuotAssign,
		OpenBlockComment,
		LineComment,
		Quot,
		RemainderAssign,
		Remainder,
		ShiftRightAssign,
		ShiftRight,
		GreaterOrEqual,
		Greater,
		Dot,
		Apos,
		Quote,
		Back,
		Newline,
		Format,
		Preprocessor,
		Whitespace,
		Keyword,
		Number,
		String,
		CharString,
		Identifier,
	}

	public struct Token {
		public TokenType Type { get; set; }
		public string Value { get; set; }
		public int Cursor { get; set; }

		public override string ToString ()
		{
			return string.Format ("[Token: Type={0}, Value={1}]", Type, Value);
		}
	}

	public class Tokenizer
	{
		public Tokenizer ()
		{
		}

		public static string[] patterns = new string[] {
			"{",
			"}",
			"[",
			"]",
			"(",
			")",
			":",
			";",
			",",
			"==",
			"=",
			"!=",
			"!",
			"++",
			"--",
			"-=",
			"->",
			"-",
			"+=",
			"+",
			"||",
			"|=",
			"&^=",
			"&^",
			"&&",
			"&=",
			"&",
			"|",
			">>=",
			">>",
			"<=",
			"<",
			"^=",
			"^",
			"*=",
			"*/",
			"*",
			"/=",
			"/*",
			"//",
			"/",
			"%=",
			"%",
			"<<=",
			"<<",
			">=",
			">",
			".",
			"'",
			"\"",
			"\\",
			"\n",
			"$",
			"#",
		};

		private static string[] keywords = new string[] {
			"abstract",
			"async",
			"as",
			"await",
			"base",
			"bool",
			"break",
			"byte",
			"case",
			"catch",
			"char",
			"checked",
			"class",
			"const",
			"continue",
			"decimal",
			"default",
			"define",
			"delegate",
			"double",
			"do",
			"else",
			"endregion",
			"enum",
			"event",
			"explicit",
			"extern",
			"false",
			"finally",
			"fixed",
			"float",
			"foreach",
			"for",
			"get",
			"goto",
			"if",
			"implicit",
			"interface",
			"internal",
			"int",
			"in",
			"is",
			"lock",
			"long",
			"nameof",
			"namespace",
			"new()",
			"new",
			"null",
			"object",
			"operator",
			"out",
			"override",
			"params",
			"partial",
			"private",
			"protected",
			"public",
			"readonly",
			"ref",
			"region",
			"return",
			"sbyte",
			"sealed",
			"short",
			"sizeof",
			"stackalloc",
			"static",
			"string",
			"struct",
			"switch",
			"this",
			"throw",
			"true",
			"try",
			"typeof",
			"uint",
			"ulong",
			"unchecked",
			"unsafe",
			"ushort",
			"using",
			"var",
			"virtual",
			"void",
			"volatile",
			"where",
			"while",
			"yield",
		};

		private static bool Match(string str, int pos, string cmp) {
			for (int i = 0; i < cmp.Length; i++) {
				if (pos + i >= str.Length)
					return false;

				if (str [pos + i] != cmp [i])
					return false;
			}

			return true;
		}

		public Token[] Tokenize(string code) {
			List<Token> tkns = new List<Token> ();
			Token tkn = new Token () {
				Type = TokenType.Apos,
				Value = "",
				Cursor = 0,
			};

			int cursor = 0;
			while (cursor < code.Length) {
				if(code [cursor] == ' ' || code [cursor] == '\t') {
					string ws_v = "";
					while (code [cursor] == ' ' || code [cursor] == '\t') {
						ws_v += code [cursor].ToString();
						cursor++;
					}
					cursor -= ws_v.Length;
					tkn = new Token () {
						Type = TokenType.Whitespace,
						Value = ws_v,
						Cursor = cursor
					};
				} else {
					bool basicMatchFnd = false;
					for (int i = 0; i < patterns.Length; i++) {
						if (Match (code, cursor, patterns [i])) {
							tkn = new Token () {
								Type = (TokenType)i,
								Value = patterns [i],
								Cursor = cursor
							};
							basicMatchFnd = true;
							break;
						}
					}

					//Basic tests failed, check for keywords
					if (!basicMatchFnd) {
						bool keywordMatchFnd = false;
						for (int i = 0; i < keywords.Length; i++) {
							if (Match (code, cursor, keywords [i])) {
								tkn = new Token () {
									Type = TokenType.Keyword,
									Value = keywords [i],
									Cursor = cursor
								};

								keywordMatchFnd = true;
								break;
							}
						}

						if (!keywordMatchFnd) {
							//If still failed, check for numbers, identifiers
							if (char.IsDigit (code [cursor])) {
								//Number
								string v = code [cursor++].ToString();
								while (char.IsDigit (code [cursor]) && cursor < code.Length) {
									v += code [cursor];
									cursor++;
								}
								cursor -= v.Length;

								tkn = new Token () {
									Type = TokenType.Number,
									Value = v,
									Cursor = cursor
								};
							} else {
								//Identifier
								string v = code [cursor++].ToString();
								while ( (char.IsLetterOrDigit (code [cursor]) | code[cursor] == '_' | code[cursor] == '@') && cursor < code.Length) {
									v += code [cursor];
									cursor++;
								}
								cursor -= v.Length;

								tkn = new Token () {
									Type = TokenType.Identifier,
									Value = v,
									Cursor = cursor
								};
							}
						}
					}
				}

				cursor += tkn.Value.Length;
				tkns.Add (tkn);
			}

			List<Token> finalTkns = new List<Token> ();
			for (int i = 0; i < tkns.Count; i++) {
				int cur = tkns [i].Cursor;
				if (tkns [i].Type == TokenType.Quote) {

					string v = "\"";
					i++;

					while (i < tkns.Count) {
						v += tkns [i].Value;
						if (tkns [i].Type == TokenType.Quote && tkns [i - 1].Type != TokenType.Back) {
							//end string
							i++;
							break;
						}
						i++;
					}

					Token t = new Token () {
						Type = TokenType.String,
						Value = v,
						Cursor = cur
					};
					finalTkns.Add (t);
				} else if (tkns [i].Type == TokenType.Apos) {
					string v = "'";
					i++;

					while (i < tkns.Count) {
						v += tkns [i].Value;
						if (tkns [i].Type == TokenType.Apos && tkns [i - 1].Type != TokenType.Back) {
							//end char string
							i++;
							break;
						}
						i++;
					}

					Token t = new Token () {
						Type = TokenType.CharString,
						Value = v,
						Cursor = cur
					};
					finalTkns.Add (t);
				} else if (tkns [i].Type == TokenType.LineComment) {
					while (i < tkns.Count) {
						if (tkns [i].Type == TokenType.Newline) {
							//end line comment
							i++;
							break;
						}
						i++;
					}
				} else if (tkns [i].Type == TokenType.OpenBlockComment) {
					while (i < tkns.Count) {
						if (tkns [i].Type == TokenType.CloseBlockComment) {
							//end comment block
							i++;
							break;
						}
						i++;
					}
				} else if (tkns [i].Type == TokenType.Whitespace) {
					//Skip whitespace
				} else if (tkns [i].Type == TokenType.Newline) {
					//Skip newlines
				} else
					finalTkns.Add (tkns [i]);
			}

			return finalTkns.ToArray ();
		}
	}
}

