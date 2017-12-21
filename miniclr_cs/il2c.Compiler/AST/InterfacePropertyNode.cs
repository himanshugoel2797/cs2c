using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class InterfacePropertyNode : IInterfaceEntryType
	{
		#region IInterfaceEntryType implementation
		public InterfaceEntryType Type {
			get {
				return InterfaceEntryType.Property;
			}
		}
		#endregion

		public static bool IsPresent(Lexer lex){
			if (lex.Peek ().Type == TokenType.LBrace)
				return true;

			return false;
		}

		public static InterfacePropertyNode Parse(Lexer lex) {
			InterfacePropertyNode n = new InterfacePropertyNode ();

			//TODO: parse this rule

			return n;
		}
	}

}

