using System;
using System.Collections.Generic;
using il2c.Compiler.AST;

namespace il2c.Compiler.Parser
{
	public class Lexer
	{
		//Define sequences and call appropriate handlers?

		public Lexer ()
		{
		}

		private Queue<Token> tkn_q;

		private ProgramNode root;

		public ProgramNode Lex(Token[] tkns) {
			tkn_q = new Queue<Token> (tkns);
			root = ProgramNode.Parse (this);
			return root;
		}

		public int Count { get { return tkn_q.Count; } }

		public Token Peek(){
			return tkn_q.Peek ();
		}

		public Token Dequeue(){
			return tkn_q.Dequeue ();
		}
	}
}

