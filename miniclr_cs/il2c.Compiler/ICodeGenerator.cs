using System;
using System.Reflection;

namespace il2c.Compiler
{
	public interface ICodeGenerator
	{
		void Generate(Type t);
	}
}

