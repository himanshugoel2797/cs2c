using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace il2c.Compiler.C1
{
	public class CodeGenerator : ICodeGenerator
	{
		public CodeGenerator ()
		{
		}

		public string Filename { get; private set; }
		public string Header { get; private set; }
		public string Code { get; private set; }

		#region Name Helpers

		private static string GetTypeGenericName(Type t){
			return GetTypePrefix (t) + "_Generic_";
		}

		private static string GetTypeVtableName(Type t){
			return GetTypePrefix (t) + "_VTable_";
		}

		private static string GetTypeFieldName(Type t){
			return GetTypePrefix (t) + "_FieldTable_";
		}

		private static string GetTypeInstanceName(Type t){
			return GetTypePrefix (t).ToLower ();
		}

		private static string GetTypePrefix(Type t){
			return (t.Namespace + "_DOT_" + t.Name).Replace (".", "_DOT_");
		}

		private static string GetTypeHeader(Type t){
			return GetTypePrefix (t) + ".h";
		}

		private static string BuildFunctionPtrSignature(MethodInfo m){
			return ""; //consider valuetypes
		}

		private static string BuildFieldSignature(FieldInfo f){
			return ""; //consider volatile, valuetype
		}
		#endregion

		#region Subunits
		private static string lineTerm = ";\n";

		private string GenerateGeneric(Type t) {
			StringBuilder rVal = new StringBuilder("struct {\n");

			var constraints = t.GetGenericParameterConstraints ();
			for (int i = 0; i < constraints.Length; i++) {
				//constraints[i]
			}

			rVal.Append("}" + GetTypeGenericName(t) + lineTerm);
			return rVal.ToString();
		}

		private string GenerateVtable(Type t) {
			StringBuilder rVal = new StringBuilder("struct {\n");

			//Add function pointers
			var funcs = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

			for (int i = 0; i < funcs.Length; i++) {
				if (!funcs [i].IsVirtual && !funcs [i].IsAbstract)
					continue;

				rVal.Append(BuildFunctionPtrSignature (funcs [i]) + lineTerm);
			}

			rVal.Append("}" + GetTypeVtableName(t) + lineTerm);
			return rVal.ToString();
		}

		private string GenerateFieldStruct(Type t){
			StringBuilder rVal = new StringBuilder("struct {\n");

			//Add base type instance
			rVal.Append("struct " + GetTypeFieldName(t.BaseType) + " super" + lineTerm);

			//Add implemented interfaces
			var interfaces = t.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++) {
				IncludedTypes.Add (interfaces [i]);
				rVal.Append("struct " + GetTypeFieldName (interfaces [i]) + " " + GetTypeInstanceName (interfaces[i]) + lineTerm);
			}

			//Add vtable
			rVal.Append( "struct " + GetTypeVtableName(t) + " *vptr" + lineTerm);

			//Add generics table if needed
			if (t.IsGenericType)
				rVal.Append("struct " + GetTypeGenericName (t) + " *generic" + lineTerm);

			//Add fields
			var fields = t.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++) {
				//Generate field definitions
				rVal.Append(BuildFieldSignature(fields[i]) + lineTerm);
			}

			rVal.Append("}" + GetTypeFieldName(t) + lineTerm);
			return rVal.ToString ();
		}

		private string GenerateCommonCtor(Type t){
			//generic parameters
			return "";
		}

		private string GenerateCtors(Type t){
			return "";
		}
		#endregion

		#region ICodeGenerator implementation
		private string Includes;
		private string GenericStruct;
		private string FieldStruct;
		private string VtableStruct;
		private string StaticFields;
		private string StaticFunctions;
		private string InstanceCtors;
		private string Methods;
		private string Thunks;

		private bool IsPublic;
		private List<Type> IncludedTypes;

		public void Generate (Type t)
		{
			//NOTES: Keep list of includes

			//Determine visibility
			if (t.IsNested)
				IsPublic = t.IsNestedPublic;
			else
				IsPublic = t.IsPublic;

			//Generate vtable struct
			VtableStruct = GenerateVtable(t);

			//Generate generic struct if needed
			if (t.IsGenericType)
				GenericStruct = GenerateGeneric (t);

			//Generate field struct
			FieldStruct = GenerateFieldStruct(t);

			//Generate common constructor
			InstanceCtors = GenerateCommonCtor(t) + "\n";

			//Generate constructors
			InstanceCtors += GenerateCtors(t) + "\n";

			//Generate functions

			//Generate property accessors

			//Generate thunks

			//Generate static fields

			//Generate static functions
		}

		#endregion
	}
}

