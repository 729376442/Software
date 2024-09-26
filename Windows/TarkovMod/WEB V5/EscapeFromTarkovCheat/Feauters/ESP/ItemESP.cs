using System;
using System.Collections.Generic;
using System.Linq;
using EFT.Interactive;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Feauters.ESP
{
	// Token: 0x0200000A RID: 10
	public class ItemESP : MonoBehaviour
	{
		// Token: 0x0600004D RID: 77 RVA: 0x0000676C File Offset: 0x0000496C
		public void DrawLootItems(IEnumerable<GameLootItem> gameLootItems)
		{
			foreach (GameLootItem gameLootItem in gameLootItems)
			{
				if (GameUtils.IsLootItemValid(gameLootItem.LootItem))
				{
					string templateId = gameLootItem.LootItem.Item.TemplateId;
					bool flag = Settings.WatchedItems.Contains(templateId);
					if (gameLootItem.IsOnScreen && (flag || (gameLootItem.IsOnScreen && gameLootItem.Distance <= Settings.DrawLootItemsDistance)))
					{
						ValueTuple<string, int, int, int, string[]> valueTuple;
						string arg;
						int num;
						if (PredefinedItems.Items.TryGetValue(templateId, out valueTuple))
						{
							arg = valueTuple.Item1;
							num = valueTuple.Item4;
							string[] source = valueTuple.Item5;
							if (!flag)
							{
								if ((float)num < Settings.LootMinimumValue)
								{
									continue;
								}
								bool flag2;
								if (Settings.LootTagFilters.Any((KeyValuePair<string, bool> kvp) => kvp.Value))
								{
									flag2 = source.Any(delegate(string tag)
									{
										bool flag3;
										return Settings.LootTagFilters.TryGetValue(tag, out flag3) && flag3;
									});
								}
								else
								{
									flag2 = true;
								}
								if (!flag2)
								{
									continue;
								}
							}
						}
						else
						{
							arg = \uE86B.Localized(gameLootItem.LootItem.Item.ShortName, null);
							num = gameLootItem.LootItem.Item.Template.CreditsPrice;
							string[] source = new string[0];
							if (!flag)
							{
								if ((float)num < Settings.LootMinimumValue)
								{
									continue;
								}
								if (Settings.LootTagFilters.Any((KeyValuePair<string, bool> kvp) => kvp.Value))
								{
									continue;
								}
							}
						}
						string label = string.Format("{0} {1} [{2}]", arg, num, gameLootItem.FormattedDistance);
						Color color = flag ? Settings.WatchedItemColor : this.GetItemColor(gameLootItem.LootItem.Item);
						Render.DrawString(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), label, color, true);
					}
				}
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00006988 File Offset: 0x00004B88
		private Color GetItemColor(Item item)
		{
			if (item.Template.QuestItem)
			{
				return ItemESP.QuestColor;
			}
			switch (item.Template.Rarity)
			{
			case 0:
				return ItemESP.CommonColor;
			case 1:
				return ItemESP.RareColor;
			case 2:
				return ItemESP.SuperRareColor;
			default:
				return ItemESP.CommonColor;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000069E0 File Offset: 0x00004BE0
		public void Update()
		{
			if (!Settings.DrawLootItems)
			{
				return;
			}
			if (Time.time >= this._nextLootItemCacheTime && Main.GameWorld != null && Main.GameWorld.LootItems != null)
			{
				this._gameLootItems.Clear();
				for (int i = 0; i < Main.GameWorld.LootItems.Count; i++)
				{
					LootItem byIndex = Main.GameWorld.LootItems.GetByIndex(i);
					if (byIndex != null && Main.MainCamera != null && GameUtils.IsLootItemValid(byIndex))
					{
						bool flag = Settings.WatchedItems.Contains(byIndex.TemplateId);
						float num = Vector3.Distance(Main.MainCamera.transform.position, byIndex.transform.position);
						if (flag || num <= Settings.DrawLootItemsDistance)
						{
							this._gameLootItems.Add(new GameLootItem(byIndex));
						}
					}
				}
				this._nextLootItemCacheTime = Time.time + ItemESP.CacheLootItemsInterval;
			}
			if (this._gameLootItems != null)
			{
				foreach (GameLootItem gameLootItem in this._gameLootItems)
				{
					if (gameLootItem != null)
					{
						gameLootItem.RecalculateDynamics();
					}
				}
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00006B2C File Offset: 0x00004D2C
		private void OnGUI()
		{
			if (Settings.DrawLootItems)
			{
				this.DrawLootItems(this._gameLootItems);
			}
		}

		// Token: 0x0400004A RID: 74
		private static readonly float CacheLootItemsInterval = 1f;

		// Token: 0x0400004B RID: 75
		private float _nextLootItemCacheTime;

		// Token: 0x0400004C RID: 76
		private static readonly Color QuestColor = Color.yellow;

		// Token: 0x0400004D RID: 77
		private static readonly Color CommonColor = Color.white;

		// Token: 0x0400004E RID: 78
		private static readonly Color RareColor = new Color(0.38f, 0.43f, 1f);

		// Token: 0x0400004F RID: 79
		private static readonly Color SuperRareColor = new Color(1f, 0.29f, 0.36f);

		// Token: 0x04000050 RID: 80
		private Rect debugWindowRect = new Rect(20f, 20f, 400f, 600f);

		// Token: 0x04000051 RID: 81
		private List<GameLootItem> _gameLootItems = new List<GameLootItem>();
	}
}
