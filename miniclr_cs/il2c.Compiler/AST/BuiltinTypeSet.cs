using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class BuiltinTypeSet
	{
		public static bool Match(Lexer lex){
			Token tkn = lex.Peek ();

			if (tkn.Type == TokenType.Keyword) {
				switch (tkn.Value) {
				case "byte":
				case "sbyte":
				case "uint":
				case "int":
				case "ulong":
				case "long":
				case "void":
				case "decimal":
				case "float":
				case "double":
					return true;
				default:
					return false;
				}
			}

			return false;
		}
	}
}

