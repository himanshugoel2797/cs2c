using System;

namespace il2c.Compiler
{
	public class SyntaxException : Exception
	{
		public SyntaxException (int line, int column, string msg) : base("Syntax Error: " + line + "," + column + ":" + msg)
		{
		}
	}
}

