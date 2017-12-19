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
			if (AttributeNode.IsPresent (lex))
				return true;

			var tkn = lex.Peek ();
			if (tkn.Type == TokenType.Keyword && tkn.Value == "public")
				return true;

			if (ClassDefNode.IsPresent (lex))
				return true;

			if (StructDefNode.IsPresent (lex))
				return true;

			if (EnumDefNode.IsPresent (lex))
				return true;

			if (InterfaceDefNode.IsPresent (lex))
				return true;

			return false;
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
			else if (EnumDefNode.IsPresent (lex))
				n.Definition = EnumDefNode.Parse (lex);
			else if (InterfaceDefNode.IsPresent (lex))
				n.Definition = InterfaceDefNode.Parse (lex);

			return n;
		}
	}
}

