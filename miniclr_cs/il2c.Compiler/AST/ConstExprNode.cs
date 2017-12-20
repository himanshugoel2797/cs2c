using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class ConstExprNode
	{
		public static bool IsPresent(Lexer lex){
			return true;
		}

		public static ConstExprNode Parse(Lexer lex){
			ConstExprNode n = new ConstExprNode ();

			return n;
		}
	}

}

