using System;

namespace il2c.Compiler.AST
{
	public enum TypeDefType {
		Unknown,
		Class,
		Interface,
		Enum,
		Struct,
	}

	public interface ITypeDef
	{
		TypeDefType Type { get; }
	}
}

