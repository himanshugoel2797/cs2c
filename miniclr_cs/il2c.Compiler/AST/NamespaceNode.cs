using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class NamespaceNode
	{
		public TRefNode Identifier;

		public override string ToString ()
		{
			return string.Format ("[NamespaceNode]\n" + Identifier.ToString());
		}

		public static NamespaceNode Parse(Lexer lex) {
			var n = new NamespaceNode ();

			lex.DequeueIf ("namespace");
			n.Identifier = TRefNode.Parse (lex);
			lex.DequeueIf (TokenType.LBrace);

			lex.DequeueIf (TokenType.RBrace);

			return n;
		}
	}
}

