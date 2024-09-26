using System;
using System.Collections.Generic;
using System.Linq;
using EFT.Interactive;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class LootableContainerESP : MonoBehaviour
{
	// Token: 0x0600000E RID: 14 RVA: 0x00002204 File Offset: 0x00000404
	public void Start()
	{
		this._gameLootContainers = new List<GameLootContainer>();
		this.LootableContainerWorth = new Dictionary<Vector3, float>();
		this._containerGroups = new List<ContainerGroup>();
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002228 File Offset: 0x00000428
	public void Update()
	{
		if (!Settings.DrawLootableContainers)
		{
			return;
		}
		if (Time.time >= this._nextLootContainerCacheTime && Main.GameWorld != null && Main.GameWorld.LootItems != null)
		{
			this._gameLootContainers.Clear();
			this.SetLootableContainers();
			this._nextLootContainerCacheTime = Time.time + LootableContainerESP.CacheLootItemsInterval;
		}
		foreach (GameLootContainer gameLootContainer in this._gameLootContainers)
		{
			gameLootContainer.RecalculateDynamics();
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000022C8 File Offset: 0x000004C8
	private void SetLootableContainers()
	{
		try
		{
			if (this.LootableContainerWorth == null)
			{
				this.LootableContainerWorth = new Dictionary<Vector3, float>();
			}
			this.LootableContainerWorth.Clear();
			if (this._containerGroups == null)
			{
				this._containerGroups = new List<ContainerGroup>();
			}
			this._containerGroups.Clear();
			LootableContainer[] array = Object.FindObjectsOfType<LootableContainer>();
			if (array != null)
			{
				LootableContainer[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					LootableContainerESP.<>c__DisplayClass14_0 CS$<>8__locals1 = new LootableContainerESP.<>c__DisplayClass14_0();
					CS$<>8__locals1.<>4__this = this;
					CS$<>8__locals1.lootableContainer = array2[i];
					if (!(CS$<>8__locals1.lootableContainer == null) && !(Main.MainCamera == null) && GameUtils.IsLootableContainerValid(CS$<>8__locals1.lootableContainer))
					{
						float num = Vector3.Distance(Main.MainCamera.transform.position, CS$<>8__locals1.lootableContainer.transform.position);
						\uED44 itemOwner = CS$<>8__locals1.lootableContainer.ItemOwner;
						bool? flag;
						if (itemOwner == null)
						{
							flag = null;
						}
						else
						{
							Item rootItem = itemOwner.RootItem;
							if (rootItem == null)
							{
								flag = null;
							}
							else
							{
								flag = new bool?(\uED3F.GetAllItems(rootItem).Any((Item item) => Settings.WatchedItems.Contains(item.TemplateId)));
							}
						}
						bool? flag2 = flag;
						if (flag2.GetValueOrDefault() || num <= Settings.DrawLootableContainersDistance)
						{
							GameLootContainer item5 = new GameLootContainer(CS$<>8__locals1.lootableContainer);
							if (this._gameLootContainers == null)
							{
								this._gameLootContainers = new List<GameLootContainer>();
							}
							this._gameLootContainers.Add(item5);
							float num2 = 0f;
							if (CS$<>8__locals1.lootableContainer.ItemOwner != null && CS$<>8__locals1.lootableContainer.ItemOwner.RootItem != null)
							{
								foreach (Item item2 in \uED3F.GetAllItems(CS$<>8__locals1.lootableContainer.ItemOwner.RootItem))
								{
									if (item2 != null && item2.Template != null)
									{
										ValueTuple<string, int, int, int, string[]> valueTuple;
										if (PredefinedItems.Items != null && PredefinedItems.Items.TryGetValue(item2.TemplateId, out valueTuple))
										{
											num2 += (float)valueTuple.Item2;
										}
										else
										{
											num2 += (float)item2.Template.CreditsPrice;
										}
									}
								}
							}
							CS$<>8__locals1.containerName = "Unknown Container";
							\uED44 itemOwner2 = CS$<>8__locals1.lootableContainer.ItemOwner;
							Item item3;
							if (itemOwner2 == null)
							{
								item3 = null;
							}
							else
							{
								Item rootItem2 = itemOwner2.RootItem;
								if (rootItem2 == null)
								{
									item3 = null;
								}
								else
								{
									IEnumerable<Item> allItems = \uED3F.GetAllItems(rootItem2);
									item3 = ((allItems != null) ? allItems.FirstOrDefault<Item>() : null);
								}
							}
							Item item4 = item3;
							if (item4 != null)
							{
								LootableContainerESP.<>c__DisplayClass14_0 CS$<>8__locals2 = CS$<>8__locals1;
								string shortName = item4.ShortName;
								CS$<>8__locals2.containerName = (((shortName != null) ? \uE86B.Localized(shortName, null) : null) ?? "Unknown Container");
							}
							ContainerGroup containerGroup = this._containerGroups.FirstOrDefault((ContainerGroup g) => g.ContainerName == CS$<>8__locals1.containerName && Vector3.Distance(g.Position, CS$<>8__locals1.lootableContainer.transform.position) < CS$<>8__locals1.<>4__this._groupingDistance);
							if (containerGroup == null)
							{
								containerGroup = new ContainerGroup(CS$<>8__locals1.containerName, CS$<>8__locals1.lootableContainer.transform.position);
								this._containerGroups.Add(containerGroup);
							}
							containerGroup.Containers.Add(item5);
							containerGroup.TotalWorth += num2;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Error in SetLootableContainers: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	// Token: 0x06000011 RID: 17 RVA: 0x0000261C File Offset: 0x0000081C
	public void OnGUI()
	{
		if (!Settings.DrawLootableContainers)
		{
			return;
		}
		foreach (ContainerGroup containerGroup in this._containerGroups)
		{
			GameLootContainer gameLootContainer = containerGroup.Containers[0];
			Item item;
			bool flag = containerGroup.Containers.Any((GameLootContainer container) => \uED3F.GetAllItems(container.LootableContainer.ItemOwner.RootItem).Any((Item item) => Settings.WatchedItems.Contains(item.TemplateId)));
			if (gameLootContainer.IsOnScreen && (flag || gameLootContainer.Distance <= Settings.DrawLootableContainersDistance) && (containerGroup.TotalWorth >= Settings.LootMinimumValue || flag))
			{
				string text = containerGroup.ContainerName;
				if (containerGroup.Containers.Count > 1)
				{
					text += string.Format(" (x{0})", containerGroup.Containers.Count);
				}
				text = text + " [" + gameLootContainer.FormattedDistance + "]";
				Render.DrawString(new Vector2(gameLootContainer.ScreenPosition.x - 50f, gameLootContainer.ScreenPosition.y), text, LootableContainerESP.LootableContainerColor, true);
				float num = 15f;
				foreach (GameLootContainer gameLootContainer2 in containerGroup.Containers)
				{
					using (IEnumerator<Item> enumerator3 = \uED3F.GetAllItems(gameLootContainer2.LootableContainer.ItemOwner.RootItem).Skip(1).GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							item = enumerator3.Current;
							if (item != null && item.Template != null && !string.IsNullOrEmpty(\uE86B.Localized(item.ShortName, null)))
							{
								bool flag2 = Settings.WatchedItems.Contains(item.TemplateId);
								ValueTuple<string, int, int, int, string[]> valueTuple;
								if (PredefinedItems.Items.TryGetValue(item.TemplateId, out valueTuple))
								{
									int item2 = valueTuple.Item4;
									if (!flag2)
									{
										if ((float)item2 < Settings.LootMinimumValue)
										{
											continue;
										}
										bool flag3;
										if (Settings.LootTagFilters.Any((KeyValuePair<string, bool> kvp) => kvp.Value))
										{
											flag3 = valueTuple.Item5.Any(delegate(string tag)
											{
												bool flag4;
												return Settings.LootTagFilters.TryGetValue(tag, out flag4) && flag4;
											});
										}
										else
										{
											flag3 = true;
										}
										if (!flag3)
										{
											continue;
										}
									}
									string label = string.Format("{0} {1}", \uE86B.Localized(item.ShortName, null), item2);
									Color color = flag2 ? Settings.WatchedItemColor : this.GetItemColor(item);
									Render.DrawString(new Vector2(gameLootContainer.ScreenPosition.x - 50f, gameLootContainer.ScreenPosition.y + num), label, color, true);
									num += 15f;
								}
								else if (flag2)
								{
									string label2 = string.Format("{0} {1}", \uE86B.Localized(item.ShortName, null), item.Template.CreditsPrice);
									Render.DrawString(new Vector2(gameLootContainer.ScreenPosition.x - 50f, gameLootContainer.ScreenPosition.y + num), label2, Settings.WatchedItemColor, true);
									num += 15f;
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000029C8 File Offset: 0x00000BC8
	private Color GetItemColor(Item item)
	{
		if (item.Template.QuestItem)
		{
			return LootableContainerESP.QuestColor;
		}
		switch (item.Template.Rarity)
		{
		case 0:
			return LootableContainerESP.CommonColor;
		case 1:
			return LootableContainerESP.RareColor;
		case 2:
			return LootableContainerESP.SuperRareColor;
		default:
			return LootableContainerESP.CommonColor;
		}
	}

	// Token: 0x04000007 RID: 7
	private static readonly float CacheLootItemsInterval = 5f;

	// Token: 0x04000008 RID: 8
	private float _nextLootContainerCacheTime;

	// Token: 0x04000009 RID: 9
	private List<GameLootContainer> _gameLootContainers;

	// Token: 0x0400000A RID: 10
	private static readonly Color LootableContainerColor = new Color(1f, 0.2f, 0.09f);

	// Token: 0x0400000B RID: 11
	private Dictionary<Vector3, float> LootableContainerWorth;

	// Token: 0x0400000C RID: 12
	private Rect debugWindowRect = new Rect(20f, 20f, 400f, 600f);

	// Token: 0x0400000D RID: 13
	private static readonly Color QuestColor = Color.yellow;

	// Token: 0x0400000E RID: 14
	private static readonly Color CommonColor = Color.white;

	// Token: 0x0400000F RID: 15
	private static readonly Color RareColor = new Color(0.38f, 0.43f, 1f);

	// Token: 0x04000010 RID: 16
	private static readonly Color SuperRareColor = new Color(1f, 0.29f, 0.36f);

	// Token: 0x04000011 RID: 17
	private List<ContainerGroup> _containerGroups;

	// Token: 0x04000012 RID: 18
	private float _groupingDistance = 1f;
}
