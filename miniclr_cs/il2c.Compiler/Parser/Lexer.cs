using System;
using System.Collections.Generic;

namespace il2c.Compiler.Parser
{
	public class Lexer
	{
		//Define sequences and call appropriate handlers?

		public Lexer ()
		{
		}

		private Queue<Token> tkn_q;

		#region Lexer Case Handlers
		private static bool UsingStHandler() {

		}

		private static bool UsingExHandler() {
			//check if the statement fits the 'using ...' syntax, and generate the appropriate AST for it
			return false;
		}

		private static bool IdentifierHandler() {
			return false;
		}

		private static bool TRefHandler() {
			IdentifierHandler ();
		}

		private static bool NamespaceTknHandler() {
			return false;
		}

		private static bool NamespaceStHandler() {
			while (NamespaceTknHandler ())
				;
			return true;
		}

		private static void ProgramHandler() {
			UsingExHandler();
			NamespaceStHandler ();
		}
		#endregion

		public void Lex(Token[] tkns) {
			tkn_q = new Queue<Token> (tkns);
			ProgramHandler ();
		}
	}
}

