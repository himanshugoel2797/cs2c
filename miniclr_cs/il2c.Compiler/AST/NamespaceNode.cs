using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class NamespaceNode
	{
		public override string ToString ()
		{
			return string.Format ("[NamespaceNode]");
		}

		public static NamespaceNode Parse(Lexer lex) {
			return new NamespaceNode ();
		}
	}
}

