using System;

namespace OverrideTests
{
	class BaseClass {
		public virtual void Test(){
			Console.WriteLine ("BaseClass");
		}
	}

	class ChildClass : BaseClass {
		public override void Test ()
		{
			Console.WriteLine ("ChildClass");
		} 
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
