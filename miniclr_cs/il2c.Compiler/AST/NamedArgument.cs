using System;

namespace il2c.Compiler.AST
{
	public class NamedArgument
	{
		public bool VariableParameters { get; private set; }

		public TypeRef ArgType { get; private set; }
		public string ArgName { get; private set; }
		public object Value { get; private set; }

		public NamedArgument (TypeRef argType, string name, object val, bool isVariable)
		{
			ArgType = argType;
			ArgName = name;
			Value = val;
			VariableParameters = isVariable;
		}
	}
}

