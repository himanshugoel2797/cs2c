using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class InterfaceDefNode : ITypeDef
	{

		#region ITypeDef implementation

		public TypeDefType Type {
			get {
				return TypeDefType.Interface;
			}
		}

		#endregion

		public static bool IsPresent(Lexer lex){
			var tkn = lex.Peek ();

			if (tkn.Type == TokenType.Keyword && tkn.Value == "interface")
				return true;

			return false;
		}

		public static InterfaceDefNode Parse(Lexer lex) {
			InterfaceDefNode n = new InterfaceDefNode ();

			lex.Dequeue ("interface");
			//TODO: CLASS_IDENT

			Token tkn;
			if (lex.DequeueIf (TokenType.Colon, out tkn)) {
				//TODO: CLASS_INHERIT
			}

			lex.Dequeue (TokenType.LBrace);
			//TODO: INTERFACE_DEFS
			lex.Dequeue (TokenType.RBrace);

			return n;
		}
	}

}

