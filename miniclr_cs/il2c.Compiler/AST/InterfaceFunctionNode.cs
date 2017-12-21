using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class InterfaceFunctionNode : IInterfaceEntryType
	{
		#region IInterfaceEntryType implementation
		public InterfaceEntryType Type {
			get {
				return InterfaceEntryType.Function;
			}
		}
		#endregion

		public static bool IsPresent(Lexer lex){
			if (lex.Peek ().Type == TokenType.LParen)
				return true;

			return false;
		}

		public static InterfaceFunctionNode Parse(Lexer lex){
			InterfaceFunctionNode n = new InterfaceFunctionNode ();

			lex.Dequeue (TokenType.LParen);

			lex.Dequeue (TokenType.RParen);

			return n;
		}
	}

}

