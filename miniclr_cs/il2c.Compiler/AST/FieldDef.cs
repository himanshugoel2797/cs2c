using System;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class FieldDef
	{
		public string Name { get; private set; }

		public Visibility Visibility { get; private set; }

		public bool IsStatic { get; private set; }
		public bool IsOverride { get; private set; }
		public bool IsGeneric { get; private set; }

		public TypeRef FieldType { get; private set; }

		public List<TypeRef> GenericParameters { get; private set; }

		public List<AttributeDef> Attributes { get; private set; }

		public Argument[] Arguments { get; private set; }

		public FieldDef (string ns, string name, Visibility vis, TypeRef tref, bool isStatic, bool isOverride, Argument[] arguments)
		{
			Name = ns + "." + name;

			Visibility = vis;

			Attributes = new List<AttributeDef> ();
			Arguments = arguments;

			FieldType = tref;

			IsStatic = isStatic;
			IsOverride = isOverride;
		}

		public void AddGenericParameter (TypeRef p)
		{
			if (!IsGeneric) {
				IsGeneric = true;
				GenericParameters = new List<TypeRef> ();
			}
			GenericParameters.Add (p);
		}

		public void AddAttribute(AttributeDef attr){
			Attributes.Add (attr);
		}
	}
}

