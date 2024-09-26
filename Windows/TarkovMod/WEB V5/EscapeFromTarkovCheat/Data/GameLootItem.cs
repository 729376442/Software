using System;
using EFT.Interactive;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Data
{
	// Token: 0x02000018 RID: 24
	public class GameLootItem
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00008F61 File Offset: 0x00007161
		public LootItem LootItem { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00008F69 File Offset: 0x00007169
		public Vector3 ScreenPosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00008F71 File Offset: 0x00007171
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00008F79 File Offset: 0x00007179
		public bool IsOnScreen { get; private set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00008F82 File Offset: 0x00007182
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00008F8A File Offset: 0x0000718A
		public float Distance { get; private set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00008F93 File Offset: 0x00007193
		public string FormattedDistance
		{
			get
			{
				return string.Format("{0}m", Math.Round((double)this.Distance));
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00008FB0 File Offset: 0x000071B0
		public GameLootItem(LootItem lootItem)
		{
			if (lootItem == null)
			{
				throw new ArgumentNullException("lootItem");
			}
			this.LootItem = lootItem;
			this.screenPosition = default(Vector3);
			this.Distance = 0f;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00008FEC File Offset: 0x000071EC
		public void RecalculateDynamics()
		{
			if (!GameUtils.IsLootItemValid(this.LootItem))
			{
				return;
			}
			this.screenPosition = GameUtils.WorldPointToScreenPoint(this.LootItem.transform.position);
			this.IsOnScreen = GameUtils.IsScreenPointVisible(this.screenPosition);
			this.Distance = Vector3.Distance(Main.MainCamera.transform.position, this.LootItem.transform.position);
		}

		// Token: 0x0400009B RID: 155
		private Vector3 screenPosition;
	}
}
