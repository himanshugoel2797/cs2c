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
	public class { }
	interface { }
	struct C { }
	public enum B { }
}";

			Tokenizer tknzr = new Tokenizer ();
			Lexer lexer = new Lexer ();
			ExceptionProvider.SetCode (code);

			var tkns = tknzr.Tokenize (code);
			foreach (Token t in tkns) {
				Console.WriteLine (t.ToString ());
			}


			var root = lexer.Lex (tkns);
			Console.WriteLine ("AST:\n\n\n");
			Console.WriteLine (root);
		}
	}
}
