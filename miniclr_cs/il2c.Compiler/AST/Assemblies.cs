using System;
using System.Collections.Generic;

namespace il2c.Compiler.AST
{
	public class Assemblies
	{
		public Dictionary<string, Assembly> AssemblySet{get;private set;}

		public Assemblies(){
			AssemblySet = new Dictionary<string, Assembly> ();
		}

		public void AddAssembly(Assembly assem){
			AssemblySet [assem.Name] = assem;
		}
	}
}

