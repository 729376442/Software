using System;
using EFT.Interactive;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Data
{
	// Token: 0x02000017 RID: 23
	internal class GameLootContainer
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00008E65 File Offset: 0x00007065
		public LootableContainer LootableContainer { get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00008E6D File Offset: 0x0000706D
		public Vector3 ScreenPosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00008E75 File Offset: 0x00007075
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00008E7D File Offset: 0x0000707D
		public bool IsOnScreen { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00008E86 File Offset: 0x00007086
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00008E8E File Offset: 0x0000708E
		public float Distance { get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00008E97 File Offset: 0x00007097
		public string FormattedDistance
		{
			get
			{
				return string.Format("{0}m", Math.Round((double)this.Distance));
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00008EB4 File Offset: 0x000070B4
		public GameLootContainer(LootableContainer lootableContainer)
		{
			if (lootableContainer == null)
			{
				throw new ArgumentNullException("lootableContainer");
			}
			this.LootableContainer = lootableContainer;
			this.screenPosition = default(Vector3);
			this.Distance = 0f;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00008EF0 File Offset: 0x000070F0
		public void RecalculateDynamics()
		{
			if (!GameUtils.IsLootableContainerValid(this.LootableContainer))
			{
				return;
			}
			this.screenPosition = GameUtils.WorldPointToScreenPoint(this.LootableContainer.transform.position);
			this.IsOnScreen = GameUtils.IsScreenPointVisible(this.screenPosition);
			this.Distance = Vector3.Distance(Main.MainCamera.transform.position, this.LootableContainer.transform.position);
		}

		// Token: 0x04000097 RID: 151
		private Vector3 screenPosition;
	}
}
