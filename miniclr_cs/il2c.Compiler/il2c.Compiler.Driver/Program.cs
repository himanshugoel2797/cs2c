using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.Driver
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string code = @"
			using System; 
			using il2c.Compiler.Parser; 
			//Next
			namespace il2c.Compiler.Driver { 
}";

			Tokenizer tknzr = new Tokenizer ();
			Lexer lexer = new Lexer ();

			var tkns = tknzr.Tokenize (code);
			var root = lexer.Lex (tkns);

			foreach (Token t in tkns) {
				Console.WriteLine (t.ToString ());
			}

			Console.WriteLine ("AST:\n\n\n");
			Console.WriteLine (root);
		}
	}
}
