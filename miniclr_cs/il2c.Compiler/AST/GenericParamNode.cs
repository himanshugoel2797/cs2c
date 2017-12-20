using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class GenericParamNode
	{
		public List<string> Parameters = new List<string> ();

		public static bool IsPresent(Lexer lex){
			return (lex.Peek ().Type == TokenType.Less);
		}

		public static GenericParamNode Parse(Lexer lex) {
			GenericParamNode n = new GenericParamNode ();

			lex.Dequeue (TokenType.Less);
			Token tkn;
			do {
				tkn = lex.Dequeue (TokenType.Identifier);
				n.Parameters.Add(tkn.Value);
			} while(lex.DequeueIf (TokenType.Comma, out tkn));
			lex.Dequeue (TokenType.Greater);

			return n;
		}
	}
}

