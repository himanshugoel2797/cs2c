using System;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public struct ProgramNode
	{
		public List<UsingNode> Using = new List<UsingNode>();
		public NamespaceNode Namespace;
	}
}

