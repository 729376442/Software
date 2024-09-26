using System;
using EFT;
using UnityEngine;

namespace EscapeFromTarkovCheat.Features
{
	// Token: 0x02000013 RID: 19
	public static class ExperienceManager
	{
		// Token: 0x06000097 RID: 151 RVA: 0x0000822C File Offset: 0x0000642C
		public static void SetExperience(Player player, long experience)
		{
			if (player != null && player.Profile != null)
			{
				player.Profile.EftStats.SessionCounters.SetLong(experience, new object[]
				{
					75
				});
				Debug.Log(string.Format("Experience set to {0}", experience));
			}
		}
	}
}
