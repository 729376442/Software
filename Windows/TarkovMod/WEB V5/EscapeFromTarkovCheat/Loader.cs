using System;
using UnityEngine;

namespace EscapeFromTarkovCheat
{
	// Token: 0x02000008 RID: 8
	public class Loader
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000656D File Offset: 0x0000476D
		public static void Load()
		{
			Loader.HookObject = new GameObject();
			Loader.HookObject.AddComponent<Main>();
			Object.DontDestroyOnLoad(Loader.HookObject);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000658E File Offset: 0x0000478E
		public static void Unload()
		{
			Object.Destroy(Loader.HookObject);
		}

		// Token: 0x04000045 RID: 69
		public static GameObject HookObject;
	}
}
