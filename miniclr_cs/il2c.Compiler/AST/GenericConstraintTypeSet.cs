using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class GenericConstraintTypeSet
	{
		public static bool Match(Lexer lex){

			Token tkn = lex.Peek ();
			if (tkn.Type == TokenType.Keyword && tkn.Value == "struct")
				return true;
			
			if (tkn.Type == TokenType.Keyword && tkn.Value == "class")
				return true;
			
			if (tkn.Type == TokenType.Keyword && tkn.Value == "new()")
				return true;

			return false;
		}
	}
}

