using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public class FunctionArgumentDeclNode
	{
		public List<Tuple<TypeNode, string>> Arguments = new List<Tuple<TypeNode, string>>();
	}
}

