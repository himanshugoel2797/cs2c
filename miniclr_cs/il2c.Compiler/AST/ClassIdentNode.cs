using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class ClassIdentNode
	{
		public string Identifier;
		public GenericParamNode GenericParams;

		public static ClassIdentNode Parse(Lexer lex){
			ClassIdentNode n = new ClassIdentNode ();

			var tkn = lex.Dequeue (TokenType.Identifier);
			n.Identifier = tkn.Value;

			if(GenericParamNode.IsPresent(lex))
				n.GenericParams = GenericParamNode.Parse (lex);
			
			return n;
		}
	}
}

