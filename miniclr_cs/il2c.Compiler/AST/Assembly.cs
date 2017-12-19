using System;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class Assembly
	{
		public string Name { get; private set; }
		public List<string> References { get; private set; }
		public Dictionary<string, TypeDef> Types { get; private set; }

		public List<AttributeDef> Attributes { get; private set; }

		public Assembly (string name)
		{
			Name = name;
			References = new List<string> ();
			Types = new Dictionary<string, TypeDef> ();
			Attributes = new List<AttributeDef> ();
		}

		public void AddReference(string assembly){
			if(!References.Contains(assembly)) References.Add (assembly);
		}

		public void AddTypeDef(TypeDef def) {
			Types [def.Name] = def;
		}

		public void AddAttribute(AttributeDef attr){
			Attributes.Add (attr);
		}
	}
}

