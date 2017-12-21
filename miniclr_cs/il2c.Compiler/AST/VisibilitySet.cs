using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class VisibilitySet
	{
		public static bool Match(Lexer lex){
			var tkn = lex.Peek ();

			if (tkn.Type == TokenType.Keyword) {
				switch (tkn.Value) {
				case "public":
				case "private":
				case "protected":
				case "internal":
					return true;
				default:
					return false;
				}
			}

			return false;
		}
	}
}

