using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class AttributeNode
	{
		public TRefNode Identifier;

		public static bool IsPresent(Lexer lex) {
			var tkn = lex.Peek ();
			return (tkn.Type == TokenType.LBracket);
		}

		public static AttributeNode Parse(Lexer lex) {
			AttributeNode n = new AttributeNode ();

			lex.Dequeue (TokenType.LBracket);
			n.Identifier = TRefNode.Parse (lex);
			lex.Dequeue (TokenType.LParen);

			//TODO: Add parameter parsing

			lex.Dequeue (TokenType.RParen);
			lex.Dequeue (TokenType.RBracket);

			return n;
		}
	}

}

