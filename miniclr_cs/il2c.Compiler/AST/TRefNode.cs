using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class TRefNode
	{
		public string Identifier;
		public TRefNode Child;

		public override string ToString ()
		{
			return string.Format ("[TRefNode]" + Identifier + ((Child == null)?"":("\n" + Child.ToString())));
		}

		public static TRefNode Parse(Lexer lex){
			TRefNode r = new TRefNode ();
			if (lex.Peek ().Type != TokenType.Identifier)
				throw ExceptionProvider.Syntax( lex.Peek().Cursor, "Expected identifier.");

			Token t = lex.Dequeue ();
			r.Identifier = t.Value;

			if(lex.Peek().Type == TokenType.Dot){
				lex.Dequeue ();
				r.Child = Parse (lex);
			}

			return r;
		}
	}
}

