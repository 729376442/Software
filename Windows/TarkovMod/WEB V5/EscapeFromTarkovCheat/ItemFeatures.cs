using System;
using System.Collections.Generic;
using System.Linq;
using EFT;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat
{
	// Token: 0x02000007 RID: 7
	public class ItemFeatures
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00005EC8 File Offset: 0x000040C8
		public static bool IsInventoryItemValid(Item item)
		{
			return item != null && item.Template != null;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00005ED8 File Offset: 0x000040D8
		public string ItemStringText
		{
			get
			{
				return this._itemStringText;
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00005EE0 File Offset: 0x000040E0
		public string GetSearchQuery()
		{
			return this._searchQuery;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00005EE8 File Offset: 0x000040E8
		public string NewValue1
		{
			get
			{
				return this._newValueToWrite1;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00005EF0 File Offset: 0x000040F0
		public string NewValue2
		{
			get
			{
				return this._newValueToWrite2;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) TokPlayer.Profile.Inventory.GetItemsInSlotsen: 0x0600003A RID: 58 RVA: 0x00005EF8 File Offset: 0x000040F8
		public string NewValueToWrite3
		{
			get
			{
				return this._newValueToWrite3;
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005F00 File Offset: 0x00004100
		public void GetItemsInInventory(EquipmentSlot slot)
		{
			this.collectedItems.Clear();
			List<string> list = new List<string>();
			IEnumerable<Item> itemsInSlots = Main.LocalPlayer.Profile.Inventory.GetItemsInSlots(new EquipmentSlot[]
			{
				slot
			});
			if (itemsInSlots != null)
			{
				foreach (Item item in itemsInSlots)
				{
					if (GameUtils.IsInventoryItemValid(item) && item.Name.ToLower().Contains(this._searchQuery.ToLower()))
					{
						list.Add(item.Name);
						this.collectedItems.Add(item);
					}
				}
				this._itemStringText = string.Join("\n", list);
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005FC4 File Offset: 0x000041C4
		public void SetItemsInInventory()
		{
			Debug.Log("SetItemsInInventory called");
			if (this.collectedItems.Count > 0)
			{
				using (List<Item>.Enumerator enumerator = this.collectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Item item = enumerator.Current;
						if (item.Name.ToLower().Contains(this._searchQuery.ToLower()))
						{
							item.Template._id = this._newValueToWrite1;
							Debug.Log("Set " + item.Name + " _id to " + this._newValueToWrite1);
							int num;
							if (int.TryParse(this._newValueToWrite2, out num))
							{
								item.Template.Width = num;
								Debug.Log(string.Format("Set {0} Width to {1}", item.Name, num));
							}
							int num2;
							if (int.TryParse(this._newValueToWrite3, out num2))
							{
								item.Template.Height = num2;
								Debug.Log(string.Format("Set {0} Height to {1}", item.Name, num2));
							}
						}
					}
					return;
				}
			}
			Debug.Log("No items in collectedItems");
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000060F8 File Offset: 0x000042F8
		public void ResetItemsInInventory()
		{
			Debug.Log("ResetItemsInInventory called");
			if (this.collectedItems.Count > 0)
			{
				using (List<Item>.Enumerator enumerator = this.collectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Item item = enumerator.Current;
						item.StackObjectsCount = 1;
						Debug.Log("Reset " + item.Name + " stack to 1");
					}
					return;
				}
			}
			Debug.Log("No items in collectedItems");
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00006188 File Offset: 0x00004388
		public void DupeItemsInInventory(int stackValue)
		{
			Debug.Log(string.Format("DupeItemsInInventory called with stack value: {0}", stackValue));
			if (this.collectedItems.Count > 0)
			{
				using (List<Item>.Enumerator enumerator = this.collectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Item item = enumerator.Current;
						item.StackObjectsCount = stackValue;
						Debug.Log(string.Format("Duped {0} stack to {1}", item.Name, stackValue));
					}
					return;
				}
			}
			Debug.Log("No items in collectedItems");
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00006224 File Offset: 0x00004424
		public void DupeDollarsEuros()
		{
			Debug.Log("DupeDollarsEuros called");
			if (this.collectedItems.Count > 0)
			{
				using (List<Item>.Enumerator enumerator = this.collectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Item item = enumerator.Current;
						item.StackObjectsCount = 50000;
						Debug.Log("Duped " + item.Name + " stack to 50000");
					}
					return;
				}
			}
			Debug.Log("No items in collectedItems");
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000062B8 File Offset: 0x000044B8
		public void DupeRubles()
		{
			Debug.Log("DupeRubles called");
			if (this.collectedItems.Count > 0)
			{
				using (List<Item>.Enumerator enumerator = this.collectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Item item = enumerator.Current;
						item.StackObjectsCount = 500000;
						Debug.Log("Duped " + item.Name + " stack to 500000");
					}
					return;
				}
			}
			Debug.Log("No items in collectedItems");
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000634C File Offset: 0x0000454C
		public void DupeItemsInInventoryHigh()
		{
			Debug.Log("DupeItemsInInventoryHigh called");
			if (this.collectedItems.Count > 0)
			{
				using (List<Item>.Enumerator enumerator = this.collectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Item item = enumerator.Current;
						item.StackObjectsCount = 60;
						Debug.Log("Duped " + item.Name + " stack to 60");
					}
					return;
				}
			}
			Debug.Log("No items in collectedItems");
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000063DC File Offset: 0x000045DC
		public void FoundInRaidInventory()
		{
			Debug.Log("FoundInRaidInventory called");
			Player localPlayer = Main.LocalPlayer;
			IEnumerable<Item> enumerable;
			if (localPlayer == null)
			{
				enumerable = null;
			}
			else
			{
				Profile profile = localPlayer.Profile;
				if (profile == null)
				{
					enumerable = null;
				}
				else
				{
					Inventory inventory = profile.Inventory;
					enumerable = ((inventory != null) ? inventory.GetPlayerItems(31) : null);
				}
			}
			IEnumerable<Item> enumerable2 = enumerable;
			if (enumerable2 != null)
			{
				Debug.Log(string.Format("Found {0} items in inventory", enumerable2.Count<Item>()));
				using (IEnumerator<Item> enumerator = enumerable2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Item item = enumerator.Current;
						if (GameUtils.IsInventoryItemValid(item))
						{
							item.SpawnedInSession = true;
							Debug.Log("Set " + item.Name + " to SpawnedInSession");
						}
					}
					return;
				}
			}
			Debug.Log("No items found or LocalPlayer is null");
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000064A4 File Offset: 0x000046A4
		public void SetSearchQuery(string searchQuery)
		{
			this._searchQuery = searchQuery;
			Debug.Log("Search query set to: " + searchQuery);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000064C0 File Offset: 0x000046C0
		public void SetNewValues(string newValue1, string newValue2, string newValue3)
		{
			this._newValueToWrite1 = newValue1;
			this._newValueToWrite2 = newValue2;
			this._newValueToWrite3 = newValue3;
			Debug.Log(string.Concat(new string[]
			{
				"New values set: ",
				newValue1,
				", ",
				newValue2,
				", ",
				newValue3
			}));
		}

		// Token: 0x0400003F RID: 63
		public List<Item> collectedItems = new List<Item>();

		// Token: 0x04000040 RID: 64
		public string _searchQuery = "";

		// Token: 0x04000041 RID: 65
		public string _itemStringText = "";

		// Token: 0x04000042 RID: 66
		public string _newValueToWrite1 = "";

		// Token: 0x04000043 RID: 67
		public string _newValueToWrite2 = "";

		// Token: 0x04000044 RID: 68
		public string _newValueToWrite3 = "";
	}
}
