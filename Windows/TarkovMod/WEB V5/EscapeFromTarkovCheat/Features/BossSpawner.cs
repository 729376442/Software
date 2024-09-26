using System;
using Comfort.Common;
using EFT;
using UnityEngine;

namespace EscapeFromTarkovCheat.Features
{
	// Token: 0x02000012 RID: 18
	public class BossSpawner
	{
		// Token: 0x06000088 RID: 136 RVA: 0x0000815C File Offset: 0x0000635C
		public void SpawnBoss(WildSpawnType bossType)
		{
			IBotGame instance = Singleton<IBotGame>.Instance;
			if (instance == null)
			{
				Debug.LogWarning("Bot game instance is not available.");
				return;
			}
			instance.BotsController.SpawnBotDebugServer(4, false, bossType, 1, true);
			Debug.Log(string.Format("Spawned a {0} bot.", bossType));
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000081A2 File Offset: 0x000063A2
		public void SpawnKilla()
		{
			this.SpawnBoss(6);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000081AB File Offset: 0x000063AB
		public void SpawnReshala()
		{
			this.SpawnBoss(3);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000081B4 File Offset: 0x000063B4
		public void SpawnSanitar()
		{
			this.SpawnBoss(17);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000081BE File Offset: 0x000063BE
		public void SpawnGluhar()
		{
			this.SpawnBoss(11);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000081C8 File Offset: 0x000063C8
		public void SpawnShturman()
		{
			this.SpawnBoss(7);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000081D1 File Offset: 0x000063D1
		public void SpawnTagilla()
		{
			this.SpawnBoss(22);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000081DB File Offset: 0x000063DB
		public void SpawnKnight()
		{
			this.SpawnBoss(26);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000081E5 File Offset: 0x000063E5
		public void SpawnBigPipe()
		{
			this.SpawnBoss(27);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000081EF File Offset: 0x000063EF
		public void SpawnBirdEye()
		{
			this.SpawnBoss(28);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000081F9 File Offset: 0x000063F9
		public void SpawnZryachiy()
		{
			this.SpawnBoss(29);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00008203 File Offset: 0x00006403
		public void SpawnKaban()
		{
			this.SpawnBoss(32);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000820D File Offset: 0x0000640D
		public void SpawnSectantWarrior()
		{
			this.SpawnBoss(20);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00008217 File Offset: 0x00006417
		public void SpawnSectantPriest()
		{
			this.SpawnBoss(21);
		}
	}
}
