using System;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class ClassDefNode : ITypeDef
	{
		public bool IsAbstract;
		public TRefNode ParentClass;

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
			ClassDefNode n = new ClassDefNode ();

			Token tkn;
			n.IsAbstract = lex.DequeueIf ("abstract", out tkn);
			lex.Dequeue ("class");
			//TODO: CLASS_IDENT
			if (lex.DequeueIf (TokenType.Colon, out tkn)) {
				//TODO: CLASS_INHERIT
			}

			lex.Dequeue (TokenType.LBrace);
			//TODO: CLASS_STRUCT_DEFS
			lex.Dequeue (TokenType.RBrace);
			return n;
		}
	}
}

