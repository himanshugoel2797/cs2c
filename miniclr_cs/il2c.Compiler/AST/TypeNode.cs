using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class TypeNode
	{
		public TRefNode CustomType;
		public string BuiltinType;

		public static bool IsPresent(Lexer lex){
			if (BuiltinTypeSet.Match (lex))
				return true;

			if (TRefNode.IsPresent (lex))
				return true;

			return false;
		}

		public static TypeNode Parse(Lexer lex) {
			TypeNode n = new TypeNode ();

			if (BuiltinTypeSet.Match (lex))
				n.BuiltinType = lex.Dequeue ().Value;
			else if (TRefNode.IsPresent (lex))
				n.CustomType = TRefNode.Parse (lex);
			
			return n;
		}
	}
}

