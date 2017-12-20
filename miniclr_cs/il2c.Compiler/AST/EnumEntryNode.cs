using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class EnumEntryNode
	{
		public string Identifier;
		public ConstExprNode Value;

		public static bool IsPresent(Lexer lex){
			return (lex.Peek ().Type == TokenType.Identifier);
		}

		public static EnumEntryNode Parse(Lexer lex){
			EnumEntryNode n = new EnumEntryNode ();

			var tkn = lex.Dequeue (TokenType.Identifier);
			n.Identifier = tkn.Value;

			if (lex.DequeueIf (TokenType.Assign, out tkn)) {
				n.Value = ConstExprNode.Parse (lex);
			}

			return n;
		}
	}
}

