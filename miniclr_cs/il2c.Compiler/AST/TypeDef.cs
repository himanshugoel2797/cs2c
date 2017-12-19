using System;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class TypeDef
	{
		public string Name { get; private set; }

		public bool IsAbstract { get; private set; }
		public bool IsInterface { get; private set; }
		public bool IsSealed { get; private set; }
		public bool IsValueType { get; private set; }
		public bool IsGeneric { get; private set; }

		public Visibility Visibility { get; private set; }

		public TypeRef Parent { get; private set; }

		public List<TypeRef> GenericParameters { get; private set; }
		public List<TypeRef> GenericConstraints { get; private set; }
		public List<TypeRef> Interfaces { get; private set; }
		public List<TypeRef> NestedTypes { get; private set; }
		public List<MethodDef> Methods { get; private set; }
		public List<FieldDef> Fields { get; private set; }
		public List<AttributeDef> Attributes { get; private set; }


		public TypeDef (string ns, string name, Visibility vis, TypeRef parent, bool isInterface, bool isAbstract, bool isSealed, bool isValueType)
		{
			Name = ns + "." + name;
			Parent = parent;
			Visibility = vis;

			IsInterface = isInterface;
			IsAbstract = isAbstract;
			IsSealed = isSealed;
			IsValueType = isValueType;

			Methods = new List<MethodDef> ();
			Fields = new List<FieldDef> ();
			Interfaces = new List<TypeRef> ();
			NestedTypes = new List<TypeRef> ();
			Attributes = new List<AttributeDef> ();
		}

		public TypeDef(System.Reflection.TypeInfo tI) : this( tI.Namespace, tI.Name, Visibility.Public, new TypeRef(tI.BaseType), tI.IsInterface, tI.IsAbstract, tI.IsSealed, tI.IsValueType){
			
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

		public void AddMethod(MethodDef mthd){
			if (!Methods.Contains (mthd))
				Methods.Add (mthd);
		}

		public void AddField(FieldDef field){
			if (!Fields.Contains (field))
				Fields.Add (field);
		}

		public void AddAttribute(AttributeDef attr){
			Attributes.Add (attr);
		}
	}
}

