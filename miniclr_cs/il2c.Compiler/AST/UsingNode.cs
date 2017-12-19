using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class UsingNode
	{
		public TRefNode Identifier;

		public override string ToString ()
		{
			return string.Format ("[UsingNode]\n" + Identifier.ToString());
		}

		public static bool IsPresent(Lexer lex){
			Token t = lex.Peek ();

			if (t.Type == TokenType.Keyword && t.Value == "using")
				return true;

			return false;
		}

		public static UsingNode Parse(Lexer lex){
			UsingNode n = new UsingNode ();

			lex.DequeueIf ("using");
			n.Identifier = TRefNode.Parse (lex);
			lex.DequeueIf (TokenType.Semi);

			return n;
		}
	}
}

