using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class GenericConstraintNode
	{
		public string Parameter;
		public List<TRefNode> Constraints = new List<TRefNode> ();
		public List<string> KeywordConstraints = new List<string>();

		public static bool IsPresent(Lexer lex) {
			var tkn = lex.Peek ();
			if (tkn.Type == TokenType.Keyword && tkn.Value == "where")
				return true;

			return false;
		}

		public static GenericConstraintNode Parse(Lexer lex) {
			GenericConstraintNode n = new GenericConstraintNode ();

			lex.Dequeue ("where");
			var tkn = lex.Dequeue (TokenType.Identifier);
			n.Parameter = tkn.Value;

			lex.Dequeue (TokenType.Colon);
			do {
				if (GenericConstraintTypeSet.Match(lex)){
					lex.Dequeue();	
					n.KeywordConstraints.Add(tkn.Value);
				} else
					n.Constraints.Add(TRefNode.Parse(lex));
				
			} while(lex.DequeueIf (TokenType.Comma, out tkn));

			return n;
		}
	}


}

