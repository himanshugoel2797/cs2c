using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class InterfacePropertyNode : IInterfaceEntryType
	{
		public string GetterVisibility;
		public string SetterVisibility;

		public bool Getter;
		public bool Setter;

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

			lex.Dequeue(TokenType.LBrace);

			Token tkn;
			for (int i = 0; i < 2; i++) {
				string vis = "public";
				if (VisibilitySet.Match (lex)) {
					tkn = lex.Dequeue ();
					vis = tkn.Value;
				}

				if (lex.DequeueIf ("get", out tkn)) {
					n.Getter = true;
					n.GetterVisibility = vis;
					lex.Dequeue (TokenType.Semi);

					if (lex.DequeueIf (TokenType.RBrace, out tkn))
						break;
				} else if (lex.DequeueIf ("set", out tkn)) {
					n.Setter = true;
					n.SetterVisibility = vis;
					lex.Dequeue (TokenType.Semi);

					if (lex.DequeueIf (TokenType.RBrace, out tkn))
						break;
				} else
					throw ExceptionProvider.Syntax (tkn.Cursor, "Expected getter/setter declaration");
			}

			return n;
		}
	}

}

