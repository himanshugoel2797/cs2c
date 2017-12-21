using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class GenericParamNode
	{
		public List<ClassIdentNode> Parameters = new List<ClassIdentNode> ();

		public static bool IsPresent(Lexer lex){
			return (lex.Peek ().Type == TokenType.Less);
		}

		public static GenericParamNode Parse(Lexer lex) {
			GenericParamNode n = new GenericParamNode ();

			lex.Dequeue (TokenType.Less);
			Token tkn;
			do {
				n.Parameters.Add(ClassIdentNode.Parse(lex));
			} while(lex.DequeueIf (TokenType.Comma, out tkn));
			lex.Dequeue (TokenType.Greater);

			return n;
		}
	}
}

//TODO: Update GENERIC_CONSTRAINT_SUB, TYPES, FUNCTION_ARGUMENT_DECL, ATTRIBUTE_DEF, INTERFACE_ST, CLASS_ST

