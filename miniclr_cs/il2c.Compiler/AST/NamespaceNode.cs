using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class NamespaceNode
	{
		public TRefNode Identifier;

		public List<SubdefNode> Subdefinitions = new List<SubdefNode>();

		public override string ToString ()
		{
			return string.Format ("[NamespaceNode]\n" + Identifier.ToString());
		}

		public static NamespaceNode Parse(Lexer lex) {
			var n = new NamespaceNode ();

			lex.Dequeue ("namespace");
			n.Identifier = TRefNode.Parse (lex);
			lex.Dequeue (TokenType.LBrace);

			while (SubdefNode.IsPresent (lex))
				n.Subdefinitions.Add (SubdefNode.Parse (lex));

			lex.Dequeue (TokenType.RBrace);

			return n;
		}
	}
}

