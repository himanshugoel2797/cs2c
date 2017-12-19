using System;
using il2c.Compiler.AST;

namespace il2c.Compiler
{
	public class ASTBuilder
	{
		Assemblies assemblies;

		public ASTBuilder ()
		{
			assemblies = new Assemblies ();
		}

		public void AddAssembly(System.Reflection.Assembly assembly){
			Assembly assemInfo = new Assembly (assembly.FullName);

			foreach (System.Reflection.TypeInfo t in assembly.DefinedTypes) {
				var td = BuildType (t);
			}
		}

		private TypeDef BuildType(System.Reflection.TypeInfo t){
			TypeDef tdef = new TypeDef (t);

			return tdef;
		}

		public il2c.Compiler.AST.Assembly GetAST(System.Reflection.Assembly assem){
			return assemblies.AssemblySet [assem.FullName];
		}
	}
}

