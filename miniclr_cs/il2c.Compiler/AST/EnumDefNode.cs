using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class EnumDefNode : ITypeDef
	{
		public string Identifier;

		#region ITypeDef implementation

		public TypeDefType Type {
			get {
				return TypeDefType.Enum;
			}
		}

		#endregion

		public static bool IsPresent(Lexer lex){
			var tkn = lex.Peek ();

			if (tkn.Type == TokenType.Keyword && tkn.Value == "enum")
				return true;

			return false;
		}

		public static EnumDefNode Parse(Lexer lex) {
			EnumDefNode n = new EnumDefNode ();

			lex.Dequeue ("enum");
			var tkn = lex.Dequeue (TokenType.Identifier);
			n.Identifier = tkn.Value;

			lex.Dequeue (TokenType.LBrace);
			//TODO: ENUM_DEFS
			lex.Dequeue (TokenType.RBrace);

			return n;
		}
	}

}

