using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class InterfaceEntryNode
	{
		public bool IsVirtual;
		public bool IsUnsafe;

		public TRefNode TypeIdentifier;
		public string KeywordTypeIdentifier;

		public GenericParamNode GenericParams;
		public string Identifier;

		public IInterfaceEntryType Entry;

		public static bool IsPresent(Lexer lex){
			var tkn = lex.Peek ();

			if (tkn.Type == TokenType.Keyword) {
				if (tkn.Value == "virtual")
					return true;

				if (tkn.Value == "unsafe")
					return true;

				if (BuiltinTypeSet.Match (lex)) {
					lex.Dequeue ();
					return true;
				}
			}

			if (TRefNode.IsPresent (lex))
				return true;

			return false;
		}

		public static InterfaceEntryNode Parse(Lexer lex) {
			InterfaceEntryNode n = new InterfaceEntryNode ();

			Token tkn;
			n.IsVirtual = lex.DequeueIf ("virtual", out tkn);
			n.IsUnsafe = lex.DequeueIf ("unsafe", out tkn);

			if (TRefNode.IsPresent (lex))
				n.TypeIdentifier = TRefNode.Parse (lex);
			else {
				tkn = lex.Dequeue ();
				n.KeywordTypeIdentifier = tkn.Value;
			}

			if (GenericParamNode.IsPresent (lex))
				n.GenericParams = GenericParamNode.Parse (lex);

			tkn = lex.Dequeue (TokenType.Identifier);
			n.Identifier = tkn.Value;

			if (InterfaceFunctionNode.IsPresent (lex))
				n.Entry = InterfaceFunctionNode.Parse (lex);
			else if (InterfacePropertyNode.IsPresent (lex))
				n.Entry = InterfacePropertyNode.Parse (lex);
			else
				throw ExceptionProvider.Syntax (lex.Peek ().Cursor, "Unrecognized definition");
			return n;
		}
	}
}

