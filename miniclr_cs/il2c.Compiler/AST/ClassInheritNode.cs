using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class ClassInheritNode
	{
		public List<TRefNode> Bases = new List<TRefNode>();

		public static bool IsPresent(Lexer lex){
			return (lex.Peek ().Type == TokenType.Colon);
		}

		public static ClassInheritNode Parse(Lexer lex){
			ClassInheritNode n = new ClassInheritNode ();

			lex.Dequeue (TokenType.Colon);

			Token tkn;
			do {
				n.Bases.Add(TRefNode.Parse(lex));
			} while(lex.DequeueIf(TokenType.Comma, out tkn));

			return n;
		}
	}
}

