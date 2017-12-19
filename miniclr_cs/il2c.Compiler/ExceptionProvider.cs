using System;

namespace il2c.Compiler
{
	public class ExceptionProvider
	{
		private static string Code;

		public static void SetCode(string code){
			Code = code;
		}

		public static void GetLineAndColumn(int cursor, out int line, out int column){
			int l = 0;
			int c = 0;

			for (int i = 0; i < cursor; i++) {
				c++;
				if (Code [i] == '\n') {
					l++;
					c = 0;
				}
			}

			line = l + 1;
			column = c + 1;
		}

		public static SyntaxException Syntax(int cursor, string message) {
			int line = 0, column = 0;
			GetLineAndColumn (cursor, out line, out column);

			return new SyntaxException (line, column, message);
		}
	}
}

