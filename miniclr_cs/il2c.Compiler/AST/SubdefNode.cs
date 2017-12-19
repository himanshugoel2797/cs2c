using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class SubdefNode
	{
		public List<AttributeNode> Attributes = new List<AttributeNode>();
		public ITypeDef Definition;
		public bool IsPublic;

		public static bool IsPresent(Lexer lex) {

		}

		public static SubdefNode Parse(Lexer lex){
			SubdefNode n = new SubdefNode ();

			while (AttributeNode.IsPresent (lex))
				n.Attributes.Add (AttributeNode.Parse (lex));

			Token pubTkn;
			n.IsPublic = lex.DequeueIf ("public", out pubTkn);

			if (ClassDefNode.IsPresent (lex))
				n.Definition = ClassDefNode.Parse (lex);
			else if (StructDefNode.IsPresent (lex))
				n.Definition = StructDefNode.Parse (lex);
		}
	}
}

