using System;

namespace il2c.Compiler.AST
{
	public class TypeRef
	{
		public string Name { get; private set; }
		public Assembly Assembly { get; private set; }

		public TypeRef(Assembly assem, string ns, string name){
			Name = ns + "." + name;
			Assembly = assem;
		}

		public TypeRef(Type t) : this(null, t.Namespace, t.Name){ }
	}

}

