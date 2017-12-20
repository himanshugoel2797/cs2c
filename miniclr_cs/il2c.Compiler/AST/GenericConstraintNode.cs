using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class GenericConstraintNode
	{

		public bool IsPresent(Lexer lex) {
			var tkn = lex.Peek ();
			if (tkn.Type == TokenType.Keyword && tkn.Value == "where")
				return true;

			return false;
		}

		public static GenericConstraintNode Parse(Lexer lex) {
			GenericConstraintNode n = new GenericConstraintNode ();

			return n;
		}
	}


}

