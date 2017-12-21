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
	public class A<C,G> where C : Test where G : Test2 { }
	interface B : D { int TestProperty { get; private set; } }
	struct C<A> : D where A : Test { }
	public enum B { A, B, C, D }
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
