using System;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class Argument
	{
		public bool IsVariable { get; private set; }
		public bool IsOptional { get; private set; }

		public TypeRef ArgType { get; private set; }
		public object Value { get; private set; }

		public List<AttributeDef> Attributes { get; private set; }

		public Argument (TypeRef argType, object val, bool isVariable, bool isOptional)
		{
			ArgType = argType;
			Value = val;
			IsVariable = isVariable;
			IsOptional = isOptional;

			Attributes = new List<AttributeDef> ();
		}

		public void AddAttribute(AttributeDef attr){
			Attributes.Add (attr);
		}
	}
}

