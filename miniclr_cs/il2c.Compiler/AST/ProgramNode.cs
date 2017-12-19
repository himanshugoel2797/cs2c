using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class ProgramNode
	{
		public List<UsingNode> Using = new List<UsingNode>();
		public NamespaceNode Namespace;

		public override string ToString ()
		{
			string ret = "[ProgramNode]";

			for (int i = 0; i < Using.Count; i++) {
				ret += "\n" + Using [i].ToString ();
			}

			return ret + "\n" + Namespace.ToString();
		}

		public static ProgramNode Parse(Lexer lex){
			ProgramNode n = new ProgramNode ();

			while (UsingNode.IsPresent (lex))
				n.Using.Add (UsingNode.Parse (lex));

			n.Namespace = NamespaceNode.Parse (lex);
			return n;
		}
	}
}

