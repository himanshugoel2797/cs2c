using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class StructDefNode : ITypeDef
	{
		public string Identifier;

		#region ITypeDef implementation

		public TypeDefType Type {
			get {
				return TypeDefType.Struct;
			}
		}

		#endregion

		public static bool IsPresent(Lexer lex){
			var tkn = lex.Peek ();

			if (tkn.Type == TokenType.Keyword && tkn.Value == "struct")
				return true;

			return false;
		}

		public static StructDefNode Parse(Lexer lex) {
			StructDefNode n = new StructDefNode ();

			lex.Dequeue ("struct");
			var tkn = lex.Dequeue (TokenType.Identifier);
			n.Identifier = tkn.Value;

			lex.Dequeue (TokenType.LBrace);
			//TODO: CLASS_STRUCT_DEFS
			lex.Dequeue(TokenType.RBrace);

			return n;
		}
	}

}

