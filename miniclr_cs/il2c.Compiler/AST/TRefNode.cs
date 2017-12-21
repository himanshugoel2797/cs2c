using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class TRefNode
	{
		public List<string> Identifier = new List<string>();

		public static bool IsPresent(Lexer lex) {
			return (lex.Peek ().Type == TokenType.Identifier)
				;
		}

		public static TRefNode Parse(Lexer lex){
			TRefNode r = new TRefNode ();

			Token t = lex.Dequeue (TokenType.Identifier);
			r.Identifier.Add(t.Value);

			while(lex.DequeueIf(TokenType.Dot, out t)){
				t = lex.Dequeue (TokenType.Identifier);
				r.Identifier.Add (t.Value);;
			}

			return r;
		}
	}
}

