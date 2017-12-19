using System;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class MethodDef
	{
		public string Name { get; private set; }

		public Visibility Visibility { get; private set; }

		public bool IsStatic { get; private set; }
		public bool IsOverride { get; private set; }
		public bool IsExternal { get; private set; }
		public bool IsGeneric { get; private set; }
		public bool IsConstructor { get; private set; }

		public List<TypeRef> GenericParameters { get; private set; }
		public List<TypeRef> GenericConstraints { get; private set; }

		public List<AttributeDef> Attributes { get; private set; }

		public Argument[] Arguments { get; private set; }

		public byte[] Code { get; private set; }

		public MethodDef (string ns, string name, Visibility vis, bool isStatic, bool isConstructor, bool isOverride, bool isExternal, Argument[] arguments)
		{
			Name = ns + "." + name;

			Visibility = vis;

			Attributes = new List<AttributeDef> ();
			Arguments = arguments;

			IsStatic = isStatic;
			IsConstructor = isConstructor;
			IsOverride = isOverride;
			IsExternal = isExternal;
		}

		public void AddGenericParameter (TypeRef p)
		{
			if (!IsGeneric) {
				IsGeneric = true;
				GenericParameters = new List<TypeRef> ();
				GenericConstraints = new List<TypeRef> ();
			}
			GenericParameters.Add (p);
		}

		public void AddGenericConstraint (TypeRef p)
		{
			GenericConstraints.Add (p);
		}

		public void AddAttribute(AttributeDef attr){
			Attributes.Add (attr);
		}

		public void AddMethodCode(byte[] code){
			Code = code;
		}
	}
}

