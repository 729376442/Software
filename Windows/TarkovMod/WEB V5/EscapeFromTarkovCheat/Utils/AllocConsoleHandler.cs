using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

namespace EscapeFromTarkovCheat.Utils
{
	// Token: 0x0200000D RID: 13
	public static class AllocConsoleHandler
	{
		// Token: 0x0600005B RID: 91
		[DllImport("Kernel32.dll")]
		private static extern bool AllocConsole();

		// Token: 0x0600005C RID: 92
		[DllImport("msvcrt.dll")]
		public static extern int system(string cmd);

		// Token: 0x0600005D RID: 93 RVA: 0x000074F4 File Offset: 0x000056F4
		public static void Open()
		{
			AllocConsoleHandler.AllocConsole();
			Console.SetOut(new StreamWriter(Console.OpenStandardOutput())
			{
				AutoFlush = true
			});
			Application.logMessageReceivedThreaded += delegate(string condition, string stackTrace, LogType type)
			{
				Console.WriteLine(condition + " " + stackTrace);
			};
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00007541 File Offset: 0x00005741
		public static void ClearAllocConsole()
		{
			AllocConsoleHandler.system("CLS");
		}
	}
}
