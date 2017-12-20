using System;
using il2c.Compiler.Parser;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class EnumDefNode : ITypeDef
	{
		public string Identifier;
		public List<EnumEntryNode> Entries = new List<EnumEntryNode> ();

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
			bool isLast = false;
			while (EnumEntryNode.IsPresent (lex)) {
				if (isLast) {
					throw ExceptionProvider.Syntax (tkn.Cursor, "Expected ',' or end of enum");
				}

				n.Entries.Add (EnumEntryNode.Parse (lex));

				if (!lex.DequeueIf (TokenType.Comma, out tkn)) {
					isLast = true;
				}
			}
			lex.Dequeue (TokenType.RBrace);

			return n;
		}
	}

}

