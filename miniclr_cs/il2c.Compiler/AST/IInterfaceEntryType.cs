using System;
using System.Collections.Generic;
using il2c.Compiler.Parser;

namespace il2c.Compiler.AST
{
	public enum InterfaceEntryType{
		Function,
		Property
	}

	public interface IInterfaceEntryType
	{
		InterfaceEntryType Type { get; }
	}

}

