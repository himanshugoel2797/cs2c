using System;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class AttributeDef
	{
		public string Name { get; private set; }

		public TypeRef AttributeType { get; private set; }

		public List<Argument> Arguments { get; private set; }
		public List<NamedArgument> NamedArguments { get; private set; }
		public List<AttributeDef> Attributes { get; private set; }

		public AttributeDef (string ns, string name, TypeRef attrType)
		{
			Name = ns + "." + name;
			AttributeType = attrType;

			Arguments = new List<Argument> ();
			NamedArguments = new List<NamedArgument> ();
			Attributes = new List<AttributeDef> ();
		}

		public void AddArgument(Argument arg){
			Arguments.Add (arg);
		}

		public void AddNamedArgument(NamedArgument narg){
			NamedArguments.Add (narg);
		}

		public void AddAttribute(AttributeDef attr){
			Attributes.Add (attr);
		}

	}
}

