using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT;
using EscapeFromTarkovCheat;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Features;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace Menu.UI
{
	// Token: 0x02000005 RID: 5
	public class Menu : MonoBehaviour
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002ACA File Offset: 0x00000CCA
		private void Awake()
		{
			this._itemFeatures = new ItemFeatures();
			this.bossSpawner = new BossSpawner();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002AE4 File Offset: 0x00000CE4
		private void Start()
		{
			AllocConsoleHandler.Open();
			this._mainWindow = new Rect(20f, 60f, 250f, 150f);
			this._playerVisualWindow = new Rect(20f, 220f, 250f, 150f);
			this._miscVisualWindow = new Rect(20f, 260f, 250f, 150f);
			this._noRecoilVisualWindow = new Rect(20f, 260f, 250f, 150f);
			this._itemMenuWindow = new Rect(280f, 60f, 250f, 400f);
			this._aimbotVisualWindow = new Rect(280f, 80f, 250f, 150f);
			this._rageFeaturesWindow = new Rect(20f, 300f, 250f, 150f);
			this._miscMenuWindow = new Rect(300f, 300f, 250f, 150f);
			this._skillsWindow = new Rect(350f, 350f, 300f, 500f);
			this._bossSpawnerWindow = new Rect(20f, 420f, 300f, 400f);
			foreach (ValueTuple<string, int, int, int, string[]> valueTuple in PredefinedItems.Items.Values)
			{
				foreach (string item2 in valueTuple.Item5)
				{
					this._uniqueTags.Add(item2);
				}
			}
			foreach (string key in this._uniqueTags)
			{
				if (!Settings.LootTagFilters.ContainsKey(key))
				{
					Settings.LootTagFilters[key] = false;
				}
			}
			this._skillsLevels = new Dictionary<string, int>
			{
				{
					"Strength",
					51
				},
				{
					"StressResistance",
					51
				},
				{
					"MagDrills",
					51
				},
				{
					"Melee",
					51
				},
				{
					"HideoutManagement",
					50
				},
				{
					"Crafting",
					51
				},
				{
					"HeavyVests",
					51
				},
				{
					"LightVests",
					51
				},
				{
					"RecoilControl",
					51
				},
				{
					"LMG",
					51
				},
				{
					"Assault",
					51
				},
				{
					"Pistol",
					51
				},
				{
					"Perception",
					51
				},
				{
					"Sniper",
					51
				},
				{
					"Sniping",
					51
				},
				{
					"Endurance",
					51
				},
				{
					"Throwing",
					51
				},
				{
					"Charisma",
					51
				},
				{
					"BotReload",
					0
				},
				{
					"TroubleShooting",
					51
				},
				{
					"Health",
					51
				},
				{
					"Vitality",
					51
				},
				{
					"Metabolism",
					51
				},
				{
					"Immunity",
					51
				},
				{
					"Intellect",
					51
				},
				{
					"Attention",
					51
				},
				{
					"Shotgun",
					51
				},
				{
					"HMG",
					51
				},
				{
					"Launcher",
					51
				},
				{
					"DMR",
					51
				},
				{
					"AimDrills",
					51
				},
				{
					"Surgery",
					51
				},
				{
					"CovertMovement",
					51
				},
				{
					"Search",
					51
				},
				{
					"FieldMedicine",
					0
				},
				{
					"FirstAid",
					0
				},
				{
					"SMG",
					51
				},
				{
					"WeaponTreatment",
					51
				},
				{
					"Revolver",
					51
				},
				{
					"AttachedLauncher",
					51
				}
			};
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002EFC File Offset: 0x000010FC
		private void Update()
		{
			if (Input.GetKeyDown(277))
			{
				this._visible = !this._visible;
			}
			if (Input.GetKeyDown(285))
			{
				this._streetsModeEnabled = !this._streetsModeEnabled;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002F34 File Offset: 0x00001134
		private void OnGUI()
		{
			if (this._visible)
			{
				this._mainWindow = GUILayout.Window(0, this._mainWindow, new GUI.WindowFunction(this.RenderUi), "Webs PVE Menu v5", Array.Empty<GUILayoutOption>());
				if (this._playerEspVisualVisible)
				{
					this._playerVisualWindow = GUILayout.Window(1, this._playerVisualWindow, new GUI.WindowFunction(this.RenderUi), "Player ESP", Array.Empty<GUILayoutOption>());
				}
				if (this._miscVisualVisible)
				{
					this._miscVisualWindow = GUILayout.Window(2, this._miscVisualWindow, new GUI.WindowFunction(this.RenderUi), "Item ESP", Array.Empty<GUILayoutOption>());
				}
				if (this._aimbotVisualVisible)
				{
					this._aimbotVisualWindow = GUILayout.Window(3, this._aimbotVisualWindow, new GUI.WindowFunction(this.RenderAimbotMenu), "Aimbot Settings", Array.Empty<GUILayoutOption>());
				}
				if (this._rageFeaturesVisible)
				{
					this._rageFeaturesWindow = GUILayout.Window(4, this._rageFeaturesWindow, new GUI.WindowFunction(this.RenderRageFeatures), "Rage Features", Array.Empty<GUILayoutOption>());
				}
				if (this._miscMenuVisible)
				{
					this._miscMenuWindow = GUILayout.Window(5, this._miscMenuWindow, new GUI.WindowFunction(this.RenderMiscMenu), "Misc Features", Array.Empty<GUILayoutOption>());
				}
				if (this._itemMenuVisible)
				{
					this._itemMenuWindow = GUILayout.Window(6, this._itemMenuWindow, new GUI.WindowFunction(this.RenderItemMenu), "Item Spawner", Array.Empty<GUILayoutOption>());
				}
				if (this._showWatchListWindow)
				{
					Rect rect;
					rect..ctor((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 300), 400f, 600f);
					GUI.Window(99, rect, new GUI.WindowFunction(this.RenderWatchListWindow), "Item Watch List");
				}
				if (this._skillsWindowVisible)
				{
					this._skillsWindow = GUILayout.Window(7, this._skillsWindow, new GUI.WindowFunction(this.RenderSkillsWindow), "Skills Editor", Array.Empty<GUILayoutOption>());
				}
				if (this._bossSpawnerVisible)
				{
					this._bossSpawnerWindow = GUILayout.Window(8, this._bossSpawnerWindow, new GUI.WindowFunction(this.RenderBossSpawnerMenu), "Boss Spawner", Array.Empty<GUILayoutOption>());
				}
			}
			this.RenderWatermark();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000314C File Offset: 0x0000134C
		private void RenderWatermark()
		{
			if (this._movingRight)
			{
				this._watermarkXPosition += this._watermarkSpeed * Time.deltaTime;
				if (this._watermarkXPosition > (float)(Screen.width - 250))
				{
					this._movingRight = false;
				}
			}
			else
			{
				this._watermarkXPosition -= this._watermarkSpeed * Time.deltaTime;
				if (this._watermarkXPosition < 0f)
				{
					this._movingRight = true;
				}
			}
			Color textColor = Color.HSVToRGB(Mathf.PingPong(Time.time * 0.1f, 1f), 1f, 1f);
			GUIStyle guistyle = new GUIStyle
			{
				fontSize = 24,
				normal = 
				{
					textColor = textColor
				},
				alignment = 4
			};
			string text = " Webs PVE Menu v5 ";
			GUI.Label(new Rect(this._watermarkXPosition, 10f, 250f, 30f), text, guistyle);
			GUIStyle guistyle2 = new GUIStyle
			{
				fontSize = 18,
				normal = 
				{
					textColor = Color.white
				},
				alignment = 5
			};
			string text2 = "Streets Mode: " + (this._streetsModeEnabled ? "Enabled" : "Disabled");
			GUI.Label(new Rect((float)(Screen.width - 260), 40f, 250f, 30f), text2, guistyle2);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000032A0 File Offset: 0x000014A0
		private void RenderUi(int id)
		{
			switch (id)
			{
			case 0:
				GUILayout.Label("                 Key Binds", Array.Empty<GUILayoutOption>());
				GUILayout.Label("Insert: Open/Close Menu", Array.Empty<GUILayoutOption>());
				GUILayout.Label("NumPad 1: Unlock All Doors", Array.Empty<GUILayoutOption>());
				GUILayout.Label("NumPad 2: Kill All", Array.Empty<GUILayoutOption>());
				GUILayout.Label("NumPad 3: Instant Heal", Array.Empty<GUILayoutOption>());
				GUILayout.Label("Numpad 4: Streets Offline", Array.Empty<GUILayoutOption>());
				GUILayout.Label("LftCntlr: Aimbot", Array.Empty<GUILayoutOption>());
				if (GUILayout.Button("Aimbot Settings", Array.Empty<GUILayoutOption>()))
				{
					this._aimbotVisualVisible = !this._aimbotVisualVisible;
				}
				if (GUILayout.Button("Player ESP", Array.Empty<GUILayoutOption>()))
				{
					this._playerEspVisualVisible = !this._playerEspVisualVisible;
				}
				if (GUILayout.Button("Item ESP", Array.Empty<GUILayoutOption>()))
				{
					this._miscVisualVisible = !this._miscVisualVisible;
				}
				if (GUILayout.Button("Item Spawner", Array.Empty<GUILayoutOption>()))
				{
					this._itemMenuVisible = !this._itemMenuVisible;
				}
				if (GUILayout.Button("Rage Features", Array.Empty<GUILayoutOption>()))
				{
					this._rageFeaturesVisible = !this._rageFeaturesVisible;
				}
				if (GUILayout.Button("Misc", Array.Empty<GUILayoutOption>()))
				{
					this._miscMenuVisible = !this._miscMenuVisible;
				}
				break;
			case 1:
				Settings.DrawPlayers = GUILayout.Toggle(Settings.DrawPlayers, "Draw Players", Array.Empty<GUILayoutOption>());
				Settings.DrawPlayerBox = GUILayout.Toggle(Settings.DrawPlayerBox, "Draw Player Box", Array.Empty<GUILayoutOption>());
				Settings.DrawPlayerName = GUILayout.Toggle(Settings.DrawPlayerName, "Draw Player Name", Array.Empty<GUILayoutOption>());
				Settings.DrawPlayerLine = GUILayout.Toggle(Settings.DrawPlayerLine, "Draw Player Line", Array.Empty<GUILayoutOption>());
				Settings.DrawPlayerHealth = GUILayout.Toggle(Settings.DrawPlayerHealth, "Draw Player Health", Array.Empty<GUILayoutOption>());
				Settings.DrawPlayerSkeleton = GUILayout.Toggle(Settings.DrawPlayerSkeleton, "Draw Player Skeleton", Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Player Distance {0} m", (int)Settings.DrawPlayersDistance), Array.Empty<GUILayoutOption>());
				Settings.DrawPlayersDistance = GUILayout.HorizontalSlider(Settings.DrawPlayersDistance, 0f, 2000f, Array.Empty<GUILayoutOption>());
				break;
			case 2:
				Settings.DrawLootItems = GUILayout.Toggle(Settings.DrawLootItems, "Draw Loot Items", Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Loot Item Distance {0} m", (int)Settings.DrawLootItemsDistance), Array.Empty<GUILayoutOption>());
				Settings.DrawLootItemsDistance = GUILayout.HorizontalSlider(Settings.DrawLootItemsDistance, 0f, 1000f, Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Minimum Loot Value: {0:N0}", Settings.LootMinimumValue), Array.Empty<GUILayoutOption>());
				Settings.LootMinimumValue = Mathf.Round(GUILayout.HorizontalSlider(Settings.LootMinimumValue, 0f, 10000000f, Array.Empty<GUILayoutOption>()) / 5000f) * 5000f;
				Settings.DrawLootableContainers = GUILayout.Toggle(Settings.DrawLootableContainers, "Draw Containers", Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Container Distance {0} m", (int)Settings.DrawLootableContainersDistance), Array.Empty<GUILayoutOption>());
				Settings.DrawLootableContainersDistance = GUILayout.HorizontalSlider(Settings.DrawLootableContainersDistance, 0f, 1000f, Array.Empty<GUILayoutOption>());
				if (GUILayout.Button(this._showLootTagFilters ? "Hide Loot Tag Filters" : "Show Loot Tag Filters", Array.Empty<GUILayoutOption>()))
				{
					this._showLootTagFilters = !this._showLootTagFilters;
				}
				if (this._showLootTagFilters)
				{
					this._lootTagScrollPosition = GUILayout.BeginScrollView(this._lootTagScrollPosition, new GUILayoutOption[]
					{
						GUILayout.Height(150f)
					});
					foreach (string text in from t in this._uniqueTags
					orderby t
					select t)
					{
						Settings.LootTagFilters[text] = GUILayout.Toggle(Settings.LootTagFilters[text], text, Array.Empty<GUILayoutOption>());
					}
					GUILayout.EndScrollView();
				}
				if (GUILayout.Button("Manage Watch List", Array.Empty<GUILayoutOption>()))
				{
					this._showWatchListWindow = !this._showWatchListWindow;
				}
				break;
			case 3:
				Settings.Aimbot = GUILayout.Toggle(Settings.Aimbot, "Aimbot", Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Aimbot Smooth {0}", (int)Settings.AimbotSmooth), Array.Empty<GUILayoutOption>());
				Settings.AimbotSmooth = GUILayout.HorizontalSlider(Settings.AimbotSmooth, 0f, 100f, Array.Empty<GUILayoutOption>());
				Settings.AimbotDrawFOV = GUILayout.Toggle(Settings.AimbotDrawFOV, "Draw Fov", Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Aimbot FOV {0}", (int)Settings.AimbotFOV), Array.Empty<GUILayoutOption>());
				Settings.AimbotFOV = GUILayout.HorizontalSlider(Settings.AimbotFOV, 0f, 180f, Array.Empty<GUILayoutOption>());
				Settings.NoRecoil = GUILayout.Toggle(Settings.NoRecoil, "No Recoil", Array.Empty<GUILayoutOption>());
				Settings.SilentAim = GUILayout.Toggle(Settings.SilentAim, "Silent Aim", Array.Empty<GUILayoutOption>());
				break;
			case 4:
				Settings.GodMode = GUILayout.Toggle(Settings.GodMode, "GodMode", Array.Empty<GUILayoutOption>());
				Settings.NoRecoil = GUILayout.Toggle(Settings.NoRecoil, "No Recoil", Array.Empty<GUILayoutOption>());
				Settings.InfiniteStamina = GUILayout.Toggle(Settings.InfiniteStamina, "Infinite Stamina", Array.Empty<GUILayoutOption>());
				Settings.Speedhack = GUILayout.Toggle(Settings.Speedhack, "Speedhack", Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Speed Multiplier {0}x", (int)Settings.SpeedMultiplier), Array.Empty<GUILayoutOption>());
				Settings.SpeedMultiplier = GUILayout.HorizontalSlider(Settings.SpeedMultiplier, 1f, 10f, Array.Empty<GUILayoutOption>());
				if (GUILayout.Button("Teleport Loot", Array.Empty<GUILayoutOption>()))
				{
					Settings.TeleportItems = true;
				}
				GUILayout.Label(string.Format("Teleport Item Minimum Value: {0}", Settings.LootMinimumValue), Array.Empty<GUILayoutOption>());
				Settings.LootMinimumValue = GUILayout.HorizontalSlider(Settings.LootMinimumValue, 0f, 1000000f, Array.Empty<GUILayoutOption>());
				if (GUILayout.Button("Teleport All Enemies", Array.Empty<GUILayoutOption>()))
				{
					Settings.TeleportAllEnemies = true;
				}
				if (GUILayout.Button("Teleport Bosses", Array.Empty<GUILayoutOption>()))
				{
					Settings.TeleportBosses = true;
				}
				if (GUILayout.Button("Max Skills", Array.Empty<GUILayoutOption>()))
				{
					Settings.MaxSkills = true;
				}
				if (GUILayout.Button("Increase Trader Rep", Array.Empty<GUILayoutOption>()))
				{
					Settings.IncreaseTraderStanding = true;
				}
				if (GUILayout.Button("Edit Skills", Array.Empty<GUILayoutOption>()))
				{
					this._skillsWindowVisible = !this._skillsWindowVisible;
				}
				if (GUILayout.Button("Boss Spawner", Array.Empty<GUILayoutOption>()))
				{
					this._bossSpawnerVisible = !this._bossSpawnerVisible;
				}
				GUI.DragWindow();
				break;
			}
			GUI.DragWindow();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003954 File Offset: 0x00001B54
		private void RenderAimbotMenu(int id)
		{
			Settings.Aimbot = GUILayout.Toggle(Settings.Aimbot, "Aimbot", Array.Empty<GUILayoutOption>());
			Settings.SilentAim = GUILayout.Toggle(Settings.SilentAim, "Silent Aim", Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("Aimbot Smooth {0}", (int)Settings.AimbotSmooth), Array.Empty<GUILayoutOption>());
			Settings.AimbotSmooth = GUILayout.HorizontalSlider(Settings.AimbotSmooth, 0f, 100f, Array.Empty<GUILayoutOption>());
			Settings.AimbotDrawFOV = GUILayout.Toggle(Settings.AimbotDrawFOV, "Draw Fov", Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("Aimbot FOV {0}", (int)Settings.AimbotFOV), Array.Empty<GUILayoutOption>());
			Settings.AimbotFOV = GUILayout.HorizontalSlider(Settings.AimbotFOV, 0f, 180f, Array.Empty<GUILayoutOption>());
			GUI.DragWindow();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003A2C File Offset: 0x00001C2C
		private void RenderItemMenu(int id)
		{
			GUILayout.Label("--- Item Spawner ---", Array.Empty<GUILayoutOption>());
			GUILayout.Label("ID Search", Array.Empty<GUILayoutOption>());
			this._itemFeatures.SetSearchQuery(GUILayout.TextField(this._itemFeatures.GetSearchQuery(), new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			}));
			if (GUILayout.Button("Get Items from Backpack", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(4);
			}
			if (GUILayout.Button("Get Items from Secured Container", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(5);
			}
			if (GUILayout.Button("Get Items from First Primary Weapon", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(0);
			}
			if (GUILayout.Button("Get Items from Second Primary Weapon", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(1);
			}
			if (GUILayout.Button("Get Items from Scabbard", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(3);
			}
			if (GUILayout.Button("Get Items from Earpiece", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(12);
			}
			if (GUILayout.Button("Get Items from ArmBand", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(14);
			}
			if (GUILayout.Button("Get Items from ArmorVest", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(7);
			}
			if (GUILayout.Button("Get Items from Eyewear", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(9);
			}
			if (GUILayout.Button("Get Items from Face Cover", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(10);
			}
			if (GUILayout.Button("Get Items from Headwear", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(11);
			}
			if (GUILayout.Button("Get Items from Holster", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(2);
			}
			if (GUILayout.Button("Get Items from Pockets", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(8);
			}
			if (GUILayout.Button("Get Items from Tactical Vest", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.GetItemsInInventory(6);
			}
			GUILayout.Label("Item Strings", Array.Empty<GUILayoutOption>());
			GUILayout.TextArea(this._itemFeatures.ItemStringText, new GUILayoutOption[]
			{
				GUILayout.Height(100f)
			});
			GUILayout.Label("_id", Array.Empty<GUILayoutOption>());
			this._itemFeatures.SetNewValues(GUILayout.TextField(this._itemFeatures.NewValue1, new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			}), GUILayout.TextField(this._itemFeatures.NewValue2, new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			}), GUILayout.TextField(this._itemFeatures.NewValueToWrite3, new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			}));
			if (GUILayout.Button("Spawn Item", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.SetItemsInInventory();
			}
			if (GUILayout.Button("Set Whole Inventory FiR", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.FoundInRaidInventory();
			}
			GUILayout.Label("--- Item Dupe ---", Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("Dupe Stack Value: {0}", Settings.DupeStackValue), Array.Empty<GUILayoutOption>());
			Settings.DupeStackValue = (int)GUILayout.HorizontalSlider((float)Settings.DupeStackValue, 1f, 100f, Array.Empty<GUILayoutOption>());
			if (GUILayout.Button("Dupe Items", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.DupeItemsInInventory(Settings.DupeStackValue);
			}
			if (GUILayout.Button("Reset Stack", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.ResetItemsInInventory();
			}
			if (GUILayout.Button("Dupe Rubel", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.DupeRubles();
			}
			if (GUILayout.Button("Dupe Dollars/Euros", Array.Empty<GUILayoutOption>()))
			{
				this._itemFeatures.DupeDollarsEuros();
			}
			GUI.DragWindow();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003DD8 File Offset: 0x00001FD8
		private void RenderRageFeatures(int id)
		{
			Settings.GodMode = GUILayout.Toggle(Settings.GodMode, "GodMode", Array.Empty<GUILayoutOption>());
			Settings.NoRecoil = GUILayout.Toggle(Settings.NoRecoil, "No Recoil", Array.Empty<GUILayoutOption>());
			Settings.InfiniteStamina = GUILayout.Toggle(Settings.InfiniteStamina, "Infinite Stamina", Array.Empty<GUILayoutOption>());
			Settings.Speedhack = GUILayout.Toggle(Settings.Speedhack, "Speedhack", Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("Speed Multiplier {0}x", (int)Settings.SpeedMultiplier), Array.Empty<GUILayoutOption>());
			Settings.SpeedMultiplier = GUILayout.HorizontalSlider(Settings.SpeedMultiplier, 1f, 10f, Array.Empty<GUILayoutOption>());
			if (GUILayout.Button("Teleport Loot", Array.Empty<GUILayoutOption>()))
			{
				Settings.TeleportItems = true;
			}
			GUILayout.Label(string.Format("Teleport Item Minimum Value: {0}", Settings.LootMinimumValue), Array.Empty<GUILayoutOption>());
			Settings.LootMinimumValue = GUILayout.HorizontalSlider(Settings.LootMinimumValue, 0f, 1000000f, Array.Empty<GUILayoutOption>());
			if (GUILayout.Button("Teleport All Enemies", Array.Empty<GUILayoutOption>()))
			{
				Settings.TeleportAllEnemies = true;
			}
			if (GUILayout.Button("Teleport Bosses", Array.Empty<GUILayoutOption>()))
			{
				Settings.TeleportBosses = true;
			}
			if (GUILayout.Button("Max Skills", Array.Empty<GUILayoutOption>()))
			{
				Settings.MaxSkills = true;
			}
			if (GUILayout.Button("Increase Trader Rep", Array.Empty<GUILayoutOption>()))
			{
				Settings.IncreaseTraderStanding = true;
			}
			if (GUILayout.Button("Edit Skills", Array.Empty<GUILayoutOption>()))
			{
				this._skillsWindowVisible = !this._skillsWindowVisible;
			}
			if (GUILayout.Button("Boss Spawner", Array.Empty<GUILayoutOption>()))
			{
				this._bossSpawnerVisible = !this._bossSpawnerVisible;
			}
			GUI.DragWindow();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003F7C File Offset: 0x0000217C
		private void RenderMiscMenu(int id)
		{
			GUILayout.Label("--- Misc Features ---", Array.Empty<GUILayoutOption>());
			Settings.ForceThermal = GUILayout.Toggle(Settings.ForceThermal, "Thermal Vision", Array.Empty<GUILayoutOption>());
			Settings.FullBright = GUILayout.Toggle(Settings.FullBright, "FullBright Vision", Array.Empty<GUILayoutOption>());
			Settings.DrawExfiltrationPoints = GUILayout.Toggle(Settings.DrawExfiltrationPoints, "Draw Exits", Array.Empty<GUILayoutOption>());
			Settings.FOVToggle = GUILayout.Toggle(Settings.FOVToggle, "Enable FOV Setting", Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("Field of View: {0}", Settings.FieldOfView), Array.Empty<GUILayoutOption>());
			Settings.FieldOfView = GUILayout.HorizontalSlider(Settings.FieldOfView, 60f, 120f, Array.Empty<GUILayoutOption>());
			if (GUILayout.Button("Call Airdrop", Array.Empty<GUILayoutOption>()))
			{
				Settings.CallAirdrop = true;
			}
			GUI.DragWindow();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00004054 File Offset: 0x00002254
		private void RenderSkillsWindow(int id)
		{
			GUILayout.Label("--- Skills Editor ---", Array.Empty<GUILayoutOption>());
			foreach (string text in this._skillsLevels.Keys.ToList<string>())
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.Label(text, Array.Empty<GUILayoutOption>());
				this._skillsLevels[text] = (int)GUILayout.HorizontalSlider((float)this._skillsLevels[text], 0f, 51f, Array.Empty<GUILayoutOption>());
				GUILayout.Label(this._skillsLevels[text].ToString(), new GUILayoutOption[]
				{
					GUILayout.Width(30f)
				});
				if (GUILayout.Button("Set", new GUILayoutOption[]
				{
					GUILayout.Width(50f)
				}))
				{
					this.SetSkillLevel(text, this._skillsLevels[text]);
				}
				GUILayout.EndHorizontal();
			}
			if (GUILayout.Button("Close", Array.Empty<GUILayoutOption>()))
			{
				this._skillsWindowVisible = false;
			}
			GUI.DragWindow();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004184 File Offset: 0x00002384
		private void SetSkillLevel(string skillName, int level)
		{
			Player localPlayer = Main.LocalPlayer;
			if (localPlayer != null && skillName != null)
			{
				switch (skillName.Length)
				{
				case 3:
				{
					char c = skillName[0];
					if (c <= 'H')
					{
						if (c != 'D')
						{
							if (c != 'H')
							{
								return;
							}
							if (!(skillName == "HMG"))
							{
								return;
							}
							localPlayer.Skills.HMG.SetLevel(level);
							return;
						}
						else
						{
							if (!(skillName == "DMR"))
							{
								return;
							}
							localPlayer.Skills.DMR.SetLevel(level);
							return;
						}
					}
					else if (c != 'L')
					{
						if (c != 'S')
						{
							return;
						}
						if (!(skillName == "SMG"))
						{
							return;
						}
						localPlayer.Skills.SMG.SetLevel(level);
						return;
					}
					else
					{
						if (!(skillName == "LMG"))
						{
							return;
						}
						localPlayer.Skills.LMG.SetLevel(level);
						return;
					}
					break;
				}
				case 4:
				case 11:
				case 12:
					break;
				case 5:
					if (!(skillName == "Melee"))
					{
						return;
					}
					localPlayer.Skills.Melee.SetLevel(level);
					return;
				case 6:
				{
					char c = skillName[3];
					if (c != 'l')
					{
						switch (c)
						{
						case 'p':
							if (!(skillName == "Sniper"))
							{
								return;
							}
							localPlayer.Skills.Sniper.SetLevel(level);
							return;
						case 'q':
						case 's':
							break;
						case 'r':
							if (!(skillName == "Search"))
							{
								return;
							}
							localPlayer.Skills.Search.SetLevel(level);
							return;
						case 't':
							if (!(skillName == "Pistol"))
							{
								return;
							}
							localPlayer.Skills.Pistol.SetLevel(level);
							return;
						default:
							return;
						}
					}
					else
					{
						if (!(skillName == "Health"))
						{
							return;
						}
						localPlayer.Skills.Health.SetLevel(level);
						return;
					}
					break;
				}
				case 7:
				{
					char c = skillName[1];
					if (c <= 'n')
					{
						if (c != 'h')
						{
							if (c != 'n')
							{
								return;
							}
							if (!(skillName == "Sniping"))
							{
								return;
							}
							localPlayer.Skills.Sniping.SetLevel(level);
							return;
						}
						else
						{
							if (!(skillName == "Shotgun"))
							{
								return;
							}
							localPlayer.Skills.Shotgun.SetLevel(level);
							return;
						}
					}
					else if (c != 's')
					{
						if (c != 'u')
						{
							return;
						}
						if (!(skillName == "Surgery"))
						{
							return;
						}
						localPlayer.Skills.Surgery.SetLevel(level);
						return;
					}
					else
					{
						if (!(skillName == "Assault"))
						{
							return;
						}
						localPlayer.Skills.Assault.SetLevel(level);
						return;
					}
					break;
				}
				case 8:
				{
					char c = skillName[0];
					if (c <= 'F')
					{
						if (c != 'C')
						{
							if (c != 'F')
							{
								return;
							}
							if (!(skillName == "FirstAid"))
							{
								return;
							}
							localPlayer.Skills.FirstAid.SetLevel(level);
							return;
						}
						else
						{
							if (skillName == "Crafting")
							{
								localPlayer.Skills.Crafting.SetLevel(level);
								return;
							}
							if (!(skillName == "Charisma"))
							{
								return;
							}
							localPlayer.Skills.Charisma.SetLevel(level);
							return;
						}
					}
					else if (c != 'I')
					{
						if (c != 'L')
						{
							switch (c)
							{
							case 'R':
								if (!(skillName == "Revolver"))
								{
									return;
								}
								localPlayer.Skills.Revolver.SetLevel(level);
								return;
							case 'S':
								if (!(skillName == "Strength"))
								{
									return;
								}
								localPlayer.Skills.Strength.SetLevel(level);
								return;
							case 'T':
								if (!(skillName == "Throwing"))
								{
									return;
								}
								localPlayer.Skills.Throwing.SetLevel(level);
								return;
							case 'U':
								break;
							case 'V':
								if (!(skillName == "Vitality"))
								{
									return;
								}
								localPlayer.Skills.Vitality.SetLevel(level);
								return;
							default:
								return;
							}
						}
						else
						{
							if (!(skillName == "Launcher"))
							{
								return;
							}
							localPlayer.Skills.Launcher.SetLevel(level);
							return;
						}
					}
					else
					{
						if (!(skillName == "Immunity"))
						{
							return;
						}
						localPlayer.Skills.Immunity.SetLevel(level);
						return;
					}
					break;
				}
				case 9:
				{
					char c = skillName[0];
					switch (c)
					{
					case 'A':
						if (skillName == "Attention")
						{
							localPlayer.Skills.Attention.SetLevel(level);
							return;
						}
						if (!(skillName == "AimDrills"))
						{
							return;
						}
						localPlayer.Skills.AimDrills.SetLevel(level);
						return;
					case 'B':
						if (!(skillName == "BotReload"))
						{
							return;
						}
						localPlayer.Skills.BotReload.SetLevel(level);
						return;
					case 'C':
					case 'D':
						break;
					case 'E':
						if (!(skillName == "Endurance"))
						{
							return;
						}
						localPlayer.Skills.Endurance.SetLevel(level);
						return;
					default:
						if (c != 'I')
						{
							if (c != 'M')
							{
								return;
							}
							if (!(skillName == "MagDrills"))
							{
								return;
							}
							localPlayer.Skills.MagDrills.SetLevel(level);
							return;
						}
						else
						{
							if (!(skillName == "Intellect"))
							{
								return;
							}
							localPlayer.Skills.Intellect.SetLevel(level);
							return;
						}
						break;
					}
					break;
				}
				case 10:
				{
					char c = skillName[0];
					if (c != 'H')
					{
						switch (c)
						{
						case 'L':
							if (!(skillName == "LightVests"))
							{
								return;
							}
							localPlayer.Skills.LightVests.SetLevel(level);
							return;
						case 'M':
							if (!(skillName == "Metabolism"))
							{
								return;
							}
							localPlayer.Skills.Metabolism.SetLevel(level);
							return;
						case 'N':
						case 'O':
							break;
						case 'P':
							if (!(skillName == "Perception"))
							{
								return;
							}
							localPlayer.Skills.Perception.SetLevel(level);
							return;
						default:
							return;
						}
					}
					else
					{
						if (!(skillName == "HeavyVests"))
						{
							return;
						}
						localPlayer.Skills.HeavyVests.SetLevel(level);
						return;
					}
					break;
				}
				case 13:
				{
					char c = skillName[0];
					if (c != 'F')
					{
						if (c != 'R')
						{
							return;
						}
						if (!(skillName == "RecoilControl"))
						{
							return;
						}
						localPlayer.Skills.RecoilControl.SetLevel(level);
						return;
					}
					else
					{
						if (!(skillName == "FieldMedicine"))
						{
							return;
						}
						localPlayer.Skills.FieldMedicine.SetLevel(level);
						return;
					}
					break;
				}
				case 14:
					if (!(skillName == "CovertMovement"))
					{
						return;
					}
					localPlayer.Skills.CovertMovement.SetLevel(level);
					return;
				case 15:
				{
					char c = skillName[0];
					if (c != 'T')
					{
						if (c != 'W')
						{
							return;
						}
						if (!(skillName == "WeaponTreatment"))
						{
							return;
						}
						localPlayer.Skills.WeaponTreatment.SetLevel(level);
						return;
					}
					else
					{
						if (!(skillName == "TroubleShooting"))
						{
							return;
						}
						localPlayer.Skills.TroubleShooting.SetLevel(level);
						return;
					}
					break;
				}
				case 16:
				{
					char c = skillName[0];
					if (c != 'A')
					{
						if (c != 'S')
						{
							return;
						}
						if (!(skillName == "StressResistance"))
						{
							return;
						}
						localPlayer.Skills.StressResistance.SetLevel(level);
						return;
					}
					else
					{
						if (!(skillName == "AttachedLauncher"))
						{
							return;
						}
						localPlayer.Skills.AttachedLauncher.SetLevel(level);
					}
					break;
				}
				case 17:
					if (!(skillName == "HideoutManagement"))
					{
						return;
					}
					localPlayer.Skills.HideoutManagement.SetLevel(level);
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000048F4 File Offset: 0x00002AF4
		private void RenderBossSpawnerMenu(int id)
		{
			GUILayout.Label("--- Boss Spawner ---", Array.Empty<GUILayoutOption>());
			if (GUILayout.Button("Spawn Killa", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(6);
			}
			if (GUILayout.Button("Spawn Reshala", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(3);
			}
			if (GUILayout.Button("Spawn Glukhar", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(11);
			}
			if (GUILayout.Button("Spawn Shturman", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(7);
			}
			if (GUILayout.Button("Spawn Sanitar", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(17);
			}
			if (GUILayout.Button("Spawn Tagilla", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(22);
			}
			if (GUILayout.Button("Spawn Knight", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(26);
			}
			if (GUILayout.Button("Spawn Big Pipe", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(27);
			}
			if (GUILayout.Button("Spawn Birdeye", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(28);
			}
			if (GUILayout.Button("Spawn Zryachiy", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(29);
			}
			if (GUILayout.Button("Spawn Kaban", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(32);
			}
			if (GUILayout.Button("Spawn Cultist Leader", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(21);
			}
			if (GUILayout.Button("Spawn Cultist", Array.Empty<GUILayoutOption>()))
			{
				this.bossSpawner.SpawnBoss(20);
			}
			GUI.DragWindow();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00004A98 File Offset: 0x00002C98
		private void RenderWatchListWindow(int windowID)
		{
			GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
			this._watchListSearchTerm = GUILayout.TextField(this._watchListSearchTerm, new GUILayoutOption[]
			{
				GUILayout.Width(380f)
			});
			this._watchListScrollPosition = GUILayout.BeginScrollView(this._watchListScrollPosition, new GUILayoutOption[]
			{
				GUILayout.Height(520f)
			});
			foreach (KeyValuePair<string, ValueTuple<string, int, int, int, string[]>> keyValuePair in from i in PredefinedItems.Items
			orderby i.Value.Item4 descending
			where string.IsNullOrEmpty(this._watchListSearchTerm) || i.Value.Item1.ToLower().Contains(this._watchListSearchTerm.ToLower())
			select i)
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				bool flag = Settings.WatchedItems.Contains(keyValuePair.Key);
				bool flag2 = GUILayout.Toggle(flag, "", new GUILayoutOption[]
				{
					GUILayout.Width(20f)
				});
				if (flag2 != flag)
				{
					if (flag2)
					{
						Settings.WatchedItems.Add(keyValuePair.Key);
					}
					else
					{
						Settings.WatchedItems.Remove(keyValuePair.Key);
					}
				}
				GUILayout.Label(string.Format("{0} - {1:N0}/slot", keyValuePair.Value.Item1, keyValuePair.Value.Item4), new GUILayoutOption[]
				{
					GUILayout.Width(340f)
				});
				GUILayout.EndHorizontal();
			}
			GUILayout.EndScrollView();
			if (GUILayout.Button("Close", Array.Empty<GUILayoutOption>()))
			{
				this._showWatchListWindow = false;
			}
			GUILayout.EndVertical();
			GUI.DragWindow();
		}

		// Token: 0x04000013 RID: 19
		private Rect _mainWindow;

		// Token: 0x04000014 RID: 20
		private Rect _playerVisualWindow;

		// Token: 0x04000015 RID: 21
		private Rect _miscVisualWindow;

		// Token: 0x04000016 RID: 22
		private Rect _noRecoilVisualWindow;

		// Token: 0x04000017 RID: 23
		private Rect _itemMenuWindow;

		// Token: 0x04000018 RID: 24
		private Rect _aimbotVisualWindow;

		// Token: 0x04000019 RID: 25
		private Rect _rageFeaturesWindow;

		// Token: 0x0400001A RID: 26
		private Rect _miscMenuWindow;

		// Token: 0x0400001B RID: 27
		private Rect _skillsWindow;

		// Token: 0x0400001C RID: 28
		private Rect _bossSpawnerWindow;

		// Token: 0x0400001D RID: 29
		private bool _visible = true;

		// Token: 0x0400001E RID: 30
		private bool _playerEspVisualVisible;

		// Token: 0x0400001F RID: 31
		private bool _miscVisualVisible;

		// Token: 0x04000020 RID: 32
		private bool _itemMenuVisible;

		// Token: 0x04000021 RID: 33
		private bool _aimbotVisualVisible;

		// Token: 0x04000022 RID: 34
		private bool _rageFeaturesVisible;

		// Token: 0x04000023 RID: 35
		private bool _miscMenuVisible;

		// Token: 0x04000024 RID: 36
		private bool _skillsWindowVisible;

		// Token: 0x04000025 RID: 37
		private bool _bossSpawnerVisible;

		// Token: 0x04000026 RID: 38
		private ItemFeatures _itemFeatures;

		// Token: 0x04000027 RID: 39
		private BossSpawner bossSpawner;

		// Token: 0x04000028 RID: 40
		private Vector2 _lootTagScrollPosition;

		// Token: 0x04000029 RID: 41
		private bool _showLootTagFilters;

		// Token: 0x0400002A RID: 42
		private HashSet<string> _uniqueTags = new HashSet<string>();

		// Token: 0x0400002B RID: 43
		private bool _showWatchListWindow;

		// Token: 0x0400002C RID: 44
		private Vector2 _watchListScrollPosition;

		// Token: 0x0400002D RID: 45
		private string _watchListSearchTerm = "";

		// Token: 0x0400002E RID: 46
		private float _watermarkXPosition;

		// Token: 0x0400002F RID: 47
		private bool _movingRight = true;

		// Token: 0x04000030 RID: 48
		private readonly float _watermarkSpeed = 50f;

		// Token: 0x04000031 RID: 49
		private Dictionary<string, int> _skillsLevels;

		// Token: 0x04000032 RID: 50
		private bool _streetsModeEnabled;
	}
}
