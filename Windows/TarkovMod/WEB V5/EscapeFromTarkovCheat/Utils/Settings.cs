using System;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeFromTarkovCheat.Utils
{
	// Token: 0x02000010 RID: 16
	internal class Settings
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00007BB6 File Offset: 0x00005DB6
		public static void ToggleStreetsFix()
		{
			Settings.StreetsFixEnabled = !Settings.StreetsFixEnabled;
			Debug.Log("Streets fix " + (Settings.StreetsFixEnabled ? "enabled" : "disabled"));
		}

		// Token: 0x0400005E RID: 94
		internal static bool DrawLootItems = true;

		// Token: 0x0400005F RID: 95
		internal static bool DrawLootableContainers = false;

		// Token: 0x04000060 RID: 96
		internal static bool DrawExfiltrationPoints = false;

		// Token: 0x04000061 RID: 97
		internal static bool DrawPlayers = true;

		// Token: 0x04000062 RID: 98
		internal static bool DrawPlayerName = true;

		// Token: 0x04000063 RID: 99
		internal static bool DrawPlayerHealth = false;

		// Token: 0x04000064 RID: 100
		internal static bool DrawPlayerBox = false;

		// Token: 0x04000065 RID: 101
		internal static bool DrawPlayerLine = false;

		// Token: 0x04000066 RID: 102
		internal static float DrawLootItemsDistance = 100f;

		// Token: 0x04000067 RID: 103
		internal static float LootMinimumValue = 30000f;

		// Token: 0x04000068 RID: 104
		internal static bool TeleportItems = false;

		// Token: 0x04000069 RID: 105
		internal static float DrawLootableContainersDistance = 10f;

		// Token: 0x0400006A RID: 106
		internal static float DrawPlayersDistance = 200f;

		// Token: 0x0400006B RID: 107
		public static Dictionary<string, bool> LootTagFilters = new Dictionary<string, bool>();

		// Token: 0x0400006C RID: 108
		public static HashSet<string> WatchedItems = new HashSet<string>();

		// Token: 0x0400006D RID: 109
		public static readonly Color WatchedItemColor = new Color(1f, 0.5f, 0f);

		// Token: 0x0400006E RID: 110
		internal static float FieldOfView = 60f;

		// Token: 0x0400006F RID: 111
		internal static bool Aimbot = false;

		// Token: 0x04000070 RID: 112
		internal static KeyCode AimbotKey = 306;

		// Token: 0x04000071 RID: 113
		internal static float AimbotFOV = 75f;

		// Token: 0x04000072 RID: 114
		internal static float AimbotSmooth = 0f;

		// Token: 0x04000073 RID: 115
		internal static bool NoRecoil = true;

		// Token: 0x04000074 RID: 116
		internal static bool AimbotDrawFOV = true;

		// Token: 0x04000075 RID: 117
		internal static bool SilentAim = false;

		// Token: 0x04000076 RID: 118
		internal static KeyCode UnlockDoors = 257;

		// Token: 0x04000077 RID: 119
		internal static KeyCode KillAll = 258;

		// Token: 0x04000078 RID: 120
		internal static KeyCode InstaHeal = 284;

		// Token: 0x04000079 RID: 121
		internal static KeyCode AddTraderStanding = 265;

		// Token: 0x0400007A RID: 122
		internal static bool IncreaseTraderStanding = false;

		// Token: 0x0400007B RID: 123
		internal static bool DrawPlayerSkeleton = true;

		// Token: 0x0400007C RID: 124
		internal static bool ForceThermal = false;

		// Token: 0x0400007D RID: 125
		internal static bool FullBright = false;

		// Token: 0x0400007E RID: 126
		internal static bool FOVToggle = false;

		// Token: 0x0400007F RID: 127
		internal static bool GodMode = true;

		// Token: 0x04000080 RID: 128
		internal static bool Speedhack = true;

		// Token: 0x04000081 RID: 129
		internal static float SpeedMultiplier = 4f;

		// Token: 0x04000082 RID: 130
		internal static bool InfiniteStamina = true;

		// Token: 0x04000083 RID: 131
		internal static bool MaxSkills = false;

		// Token: 0x04000084 RID: 132
		internal static bool TeleportAllEnemies = false;

		// Token: 0x04000085 RID: 133
		internal static bool TeleportBosses = false;

		// Token: 0x04000086 RID: 134
		internal static bool CallAirdrop = false;

		// Token: 0x04000087 RID: 135
		internal static bool SetExperience = false;

		// Token: 0x04000088 RID: 136
		internal static long ExperienceAmount = 5000L;

		// Token: 0x04000089 RID: 137
		internal static int DupeStackValue = 2;

		// Token: 0x0400008A RID: 138
		public static bool StreetsFixEnabled = false;
	}
}
