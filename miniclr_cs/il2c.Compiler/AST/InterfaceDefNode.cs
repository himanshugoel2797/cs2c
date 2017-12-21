using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class InterfaceDefNode : ITypeDef
	{
		public ClassIdentNode Identifier;
		public ClassInheritNode Parents;
		public List<GenericConstraintNode> Constraints = new List<GenericConstraintNode>();
		public List<InterfaceEntryNode> Entries = new List<InterfaceEntryNode>();
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

			if (ClassInheritNode.IsPresent(lex)) {
				n.Parents = ClassInheritNode.Parse (lex);
			}

			while (GenericConstraintNode.IsPresent (lex)) {
				n.Constraints.Add (GenericConstraintNode.Parse (lex));
			}

			lex.Dequeue (TokenType.LBrace);
			while (InterfaceEntryNode.IsPresent (lex)) {
				n.Entries.Add (InterfaceEntryNode.Parse (lex));
			}
			lex.Dequeue (TokenType.RBrace);

			return n;
		}
	}

}

