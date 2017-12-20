using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class InterfaceDefNode : ITypeDef
	{
		public ClassIdentNode Identifier;
		public ClassInheritNode Parents;

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
			n.Identifier = ClassIdentNode.Parse (lex);

			Token tkn;
			if (ClassInheritNode.IsPresent(lex)) {
				n.Parents = ClassInheritNode.Parse (lex);
			}
				
			if (GenericConstraintNode.IsPresent (lex)) {
				//TODO: GENERIC_CONSTRAINT
			}

			lex.Dequeue (TokenType.LBrace);
			//TODO: INTERFACE_DEFS
			lex.Dequeue (TokenType.RBrace);

			return n;
		}
	}

}

