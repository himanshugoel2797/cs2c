﻿using System;

namespace System
{
	[Serializable]
	[CLSCompliant(true)]
	public class SystemException : Exception
	{
		public SystemException () : base()
		{
		}

		public SystemException(string message) : base(message)
		{
		}

		public SystemException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}

