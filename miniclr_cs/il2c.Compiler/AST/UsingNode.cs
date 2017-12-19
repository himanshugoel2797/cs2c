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

		public static bool IsUsing(Lexer lex){
			Token t = lex.Peek ();

			if (t.Type == TokenType.Keyword && t.Value == "using")
				return true;

			return false;
		}

		public static UsingNode Parse(Lexer lex){
			if (!IsUsing (lex))
				throw new Exception ("Syntax Error: Expected Using statement");

			UsingNode n = new UsingNode ();
			lex.Dequeue ();

			n.Identifier = TRefNode.Parse (lex);

			if (lex.Peek ().Type != TokenType.Semi)
				throw new Exception ("Syntax Error: Expected Semicolon");

			lex.Dequeue ();	//Remove the semicolon

			return n;
		}
	}
}

