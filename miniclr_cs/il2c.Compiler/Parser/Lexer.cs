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


		public bool DequeueIf(string keyword, out Token tkn){
			var t0 = tkn_q.Peek ();
			tkn = t0;

			if (t0.Type == TokenType.Keyword && t0.Value == keyword) {
				tkn_q.Dequeue ();	
				return true;
			}
			return false;
		}

		public bool DequeueIf(TokenType t, out Token tkn){
			var t0 = tkn_q.Peek();
			tkn = t0;

			if (t0.Type == t) {
				tkn_q.Dequeue ();	
				return true;
			}
			return false;
		}

		public Token Dequeue(string keyword){
			var t0 = tkn_q.Peek ();

			if (t0.Type == TokenType.Keyword && t0.Value == keyword) {
				tkn_q.Dequeue ();	
				return t0;
			}

			throw ExceptionProvider.Syntax (t0.Cursor, "Expected '" + keyword + "'.");
		}

		public Token Dequeue(TokenType t){
			var t0 = tkn_q.Peek();

			if (t0.Type == t) {
				tkn_q.Dequeue ();	
				return t0;
			}

			throw ExceptionProvider.Syntax (t0.Cursor, "Expected " + t + ".");
		}

		public Token Peek(){
			return tkn_q.Peek ();
		}

		public Token Dequeue(){
			return tkn_q.Dequeue ();
		}
	}
}

