using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class ClassDefNode : ITypeDef
	{
		#region ITypeDef implementation

		public TypeDefType Type {
			get{
				return TypeDefType.Class;
			}
		}

		#endregion

		public static bool IsPresent(Lexer lex){
			var tkn = lex.Peek ();
			if (tkn.Type == TokenType.Keyword && tkn.Value == "abstract")
				return true;

			if (tkn.Type == TokenType.Keyword && tkn.Value == "class")
				return true;

			return false;
		}

		public static ClassDefNode Parse(Lexer lex){

		}
	}
}

