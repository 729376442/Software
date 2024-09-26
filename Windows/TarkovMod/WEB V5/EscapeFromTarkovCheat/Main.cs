using System;
using System.Collections.Generic;
using System.Linq;
using Comfort.Common;
using EFT;
using EFT.Interactive;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Features;
using EscapeFromTarkovCheat.Feauters.ESP;
using EscapeFromTarkovCheat.Utils;
using Menu.UI;
using UnityEngine;

namespace EscapeFromTarkovCheat
{
	// Token: 0x02000006 RID: 6
	public class Main : MonoBehaviour
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00004CAC File Offset: 0x00002EAC
		private void Awake()
		{
			Debug.Log("Main Awake called");
			GameObject gameObject = new GameObject();
			gameObject.AddComponent<Menu>();
			gameObject.AddComponent<PlayerESP>();
			gameObject.AddComponent<ItemESP>();
			gameObject.AddComponent<LootableContainerESP>();
			gameObject.AddComponent<ExfiltrationPointsESP>();
			gameObject.AddComponent<NoRecoil>();
			gameObject.AddComponent<SilentAimbot>();
			gameObject.AddComponent<Aimbot>();
			gameObject.AddComponent<locationsfixer>();
			Object.DontDestroyOnLoad(gameObject);
			GlobalHook.Initialize(Object.FindObjectOfType<TarkovApplication>());
			Main.ItemFeatures = new ItemFeatures();
			Debug.Log("ItemFeatures initialized");
			foreach (ExfiltrationPoint exfiltrationPoint in Object.FindObjectsOfType<ExfiltrationPoint>())
			{
				this._exfiltrationPoints.Add(new GameExfiltrationPoint(exfiltrationPoint));
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00004D54 File Offset: 0x00002F54
		public void Update()
		{
			if (Main.MainCamera != null && Settings.FOVToggle)
			{
				Main.MainCamera.fieldOfView = Settings.FieldOfView;
			}
			if (Settings.GodMode && !this.isGodModeActive)
			{
				this.GodMode();
				this.isGodModeActive = true;
			}
			else if (!Settings.GodMode && this.isGodModeActive)
			{
				this.ResetGodMode();
				this.isGodModeActive = false;
			}
			if (Input.GetKeyDown(260))
			{
				Settings.ToggleStreetsFix();
			}
			if (Settings.DrawPlayers)
			{
				if (Time.time >= this._nextPlayerCacheTime)
				{
					Main.GameWorld = Singleton<GameWorld>.Instance;
					Main.MainCamera = Camera.main;
					if (Main.GameWorld != null && Main.GameWorld.RegisteredPlayers != null)
					{
						Main.GamePlayers.Clear();
						foreach (IPlayer player in Main.GameWorld.RegisteredPlayers)
						{
							Player player2 = (Player)player;
							if (player2.IsYourPlayer)
							{
								Main.LocalPlayer = player2;
								Debug.Log("LocalPlayer set");
							}
							else if (GameUtils.IsPlayerAlive(player2) && Vector3.Distance(Main.MainCamera.transform.position, player2.Transform.position) <= Settings.DrawPlayersDistance)
							{
								Main.GamePlayers.Add(new GamePlayer(player2));
							}
						}
						this._nextPlayerCacheTime = Time.time + Main._cachePlayersInterval;
					}
				}
				foreach (GamePlayer gamePlayer in Main.GamePlayers)
				{
					gamePlayer.RecalculateDynamics();
				}
			}
			if (Input.GetKeyDown(Settings.UnlockDoors))
			{
				foreach (Door door in Object.FindObjectsOfType<Door>())
				{
					if (door.DoorState != 4 && Vector3.Distance(door.transform.position, Main.LocalPlayer.Position) <= 20f)
					{
						door.DoorState = 2;
					}
				}
			}
			if (Input.GetKeyDown(Settings.KillAll))
			{
				GameWorld instance = Singleton<GameWorld>.Instance;
				if (instance != null)
				{
					foreach (Player player3 in from x in instance.AllAlivePlayersList
					where !x.IsYourPlayer
					select x)
					{
						if (!player3.IsYourPlayer)
						{
							player3.ActiveHealthController.Kill(2048);
						}
					}
				}
			}
			if (Settings.IncreaseTraderStanding)
			{
				Player localPlayer = Main.LocalPlayer;
				if (localPlayer != null)
				{
					foreach (KeyValuePair<string, Profile.TraderInfo> keyValuePair in localPlayer.Profile.TradersInfo)
					{
						string text;
						Profile.TraderInfo traderInfo;
						\uE3A7.Deconstruct<string, Profile.TraderInfo>(keyValuePair, ref text, ref traderInfo);
						string text2 = text;
						traderInfo.Init(text2, localPlayer.Profile.Info);
						double standing = traderInfo.Standing + 0.10000000149011612;
						traderInfo.SetStanding(standing);
					}
					Settings.IncreaseTraderStanding = false;
				}
			}
			if (Settings.FullBright && !this.FullbrightCalled)
			{
				Light light = new GameObject("Fullbright").AddComponent<Light>();
				light.color = new Color(1f, 0.839f, 0.66f, 1f);
				light.range = 2000f;
				light.intensity = 0.6f;
				this.FullbrightCalled = true;
			}
			if (Settings.Speedhack)
			{
				Player localPlayer2 = Main.LocalPlayer;
				float speedMultiplier = Settings.SpeedMultiplier;
				localPlayer2.MovementContext.CharacterMovementSpeed = speedMultiplier;
				localPlayer2.MovementContext.InertiaSettings.MinDirectionBlendTime = 0f;
				localPlayer2.MovementContext.InertiaSettings.PenaltyPower = 0f;
				localPlayer2.MovementContext.InertiaSettings.BaseJumpPenalty = 0f;
				localPlayer2.MovementContext.InertiaSettings.DurationPower = 0f;
				localPlayer2.MovementContext.InertiaSettings.BaseJumpPenaltyDuration = 0f;
				localPlayer2.MovementContext.InertiaSettings.FallThreshold = 99999f;
				if (localPlayer2 != null && localPlayer2.MovementContext != null)
				{
					Vector3 vector = localPlayer2.MovementContext.VelocityProjectionOnRealForward();
					Vector3 vector2 = vector * speedMultiplier;
					localPlayer2.MovementContext.PlayerAnimatorSetAbsoluteForwardVelocity(vector2.magnitude);
					localPlayer2.Transform.position += (vector2 - vector) * Time.deltaTime;
				}
			}
			if (Settings.TeleportItems)
			{
				this.TeleportItemsToPlayer();
				Settings.TeleportItems = false;
			}
			if (Settings.TeleportAllEnemies)
			{
				this.TeleportAllEnemies();
				Settings.TeleportAllEnemies = false;
			}
			if (Settings.TeleportBosses)
			{
				this.TeleportBosses();
				Settings.TeleportBosses = false;
			}
			if (Settings.CallAirdrop)
			{
				this.CallAirdrop(false, default(Vector3));
				Settings.CallAirdrop = false;
			}
			if (Settings.InfiniteStamina)
			{
				this.InfiniteStamina();
			}
			if (Settings.MaxSkills)
			{
				this.Skillhack();
				Settings.MaxSkills = false;
			}
			if (Main.MainCamera != null && Main.MainCamera.GetComponent<ThermalVision>() != null)
			{
				Main.MainCamera.GetComponent<ThermalVision>().IsNoisy = false;
				Main.MainCamera.GetComponent<ThermalVision>().IsFpsStuck = false;
				Main.MainCamera.GetComponent<ThermalVision>().IsMotionBlurred = false;
				Main.MainCamera.GetComponent<ThermalVision>().IsPixelated = false;
				Main.MainCamera.GetComponent<ThermalVision>().IsGlitch = false;
				Main.MainCamera.GetComponent<ThermalVision>().ChromaticAberrationThermalShift = 0f;
				Main.MainCamera.GetComponent<ThermalVision>().On = Settings.ForceThermal;
			}
			foreach (GameExfiltrationPoint gameExfiltrationPoint in this._exfiltrationPoints)
			{
				gameExfiltrationPoint.RecalculateDynamics();
			}
			if (Settings.SetExperience)
			{
				ExperienceManager.SetExperience(Main.LocalPlayer, Settings.ExperienceAmount);
				Settings.SetExperience = false;
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00005384 File Offset: 0x00003584
		public void Spawn()
		{
			IBotGame instance = Singleton<IBotGame>.Instance;
			if (instance == null)
			{
				Debug.LogWarning("Bot game instance is not available.");
				return;
			}
			instance.BotsController.SpawnBotDebugServer(4, false, 6, 1, true);
			Debug.Log("Spawned a Killa bot.");
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000053C0 File Offset: 0x000035C0
		public void GodMode()
		{
			EFTHardSettings.Instance.LOOT_RAYCAST_DISTANCE = 6f;
			EFTHardSettings.Instance.DOOR_RAYCAST_DISTANCE = 6f;
			Player localPlayer = Main.LocalPlayer;
			if (localPlayer != null && localPlayer.ActiveHealthController != null && Settings.GodMode)
			{
				if (localPlayer.ActiveHealthController.DamageCoeff != -1f)
				{
					localPlayer.ActiveHealthController.SetDamageCoeff(-1f);
					localPlayer.ActiveHealthController.RemoveNegativeEffects(7);
					localPlayer.ActiveHealthController.RestoreFullHealth();
					localPlayer.ActiveHealthController.ChangeEnergy(999f);
					localPlayer.ActiveHealthController.ChangeHydration(999f);
					localPlayer.ActiveHealthController.DoPermanentHealthBoost(25f);
					localPlayer.ActiveHealthController.RemoveMedEffect();
				}
				if (localPlayer.ActiveHealthController.FallSafeHeight != 9999999f)
				{
					localPlayer.ActiveHealthController.FallSafeHeight = 9999999f;
				}
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000054A8 File Offset: 0x000036A8
		private void ResetGodMode()
		{
			Player localPlayer = Main.LocalPlayer;
			if (localPlayer != null && localPlayer.ActiveHealthController != null)
			{
				localPlayer.ActiveHealthController.SetDamageCoeff(1f);
				localPlayer.ActiveHealthController.FallSafeHeight = 1f;
				localPlayer.ActiveHealthController.ChangeEnergy(100f);
				localPlayer.ActiveHealthController.ChangeHydration(100f);
				localPlayer.ActiveHealthController.RemoveMedEffect();
				localPlayer.ActiveHealthController.DoPermanentHealthBoost(0f);
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00005528 File Offset: 0x00003728
		private void TeleportItemsToPlayer()
		{
			Debug.Log("Starting TeleportItemsToPlayer function");
			LootItem[] array = Object.FindObjectsOfType<LootItem>();
			if (array == null)
			{
				Debug.Log("FindObjectsOfType<LootItem>() returned null");
				return;
			}
			Debug.Log(string.Format("Found {0} LootItems in the scene", array.Length));
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			foreach (LootItem lootItem in array)
			{
				if (lootItem == null)
				{
					Debug.Log("Encountered a null LootItem, skipping");
				}
				else
				{
					string text;
					try
					{
						text = (lootItem.TemplateId ?? "Unknown");
					}
					catch (Exception)
					{
						text = "Inaccessible";
					}
					int num4 = 0;
					bool flag = false;
					try
					{
						ValueTuple<string, int, int, int, string[]> valueTuple;
						if (PredefinedItems.Items != null && !string.IsNullOrEmpty(lootItem.TemplateId) && PredefinedItems.Items.TryGetValue(lootItem.TemplateId, out valueTuple))
						{
							num4 = valueTuple.Item4;
							flag = true;
							Debug.Log(string.Format("Item {0} found in PredefinedItems, value: {1}", text, num4));
						}
						else
						{
							Item item = lootItem.Item;
							if (((item != null) ? item.Template : null) != null)
							{
								num4 = lootItem.Item.Template.CreditsPrice;
								flag = true;
								Debug.Log(string.Format("Item {0} not in PredefinedItems, using game price: {1}", text, num4));
							}
						}
					}
					catch (Exception ex)
					{
						Debug.Log("Error accessing item " + text + " properties: " + ex.Message);
					}
					if (!flag)
					{
						Debug.Log("Item " + text + " has no valid price information, skipping");
					}
					else
					{
						if ((float)num4 >= Settings.LootMinimumValue)
						{
							if (Camera.main == null)
							{
								Debug.Log("Main camera is null, cannot teleport items");
								return;
							}
							Vector3 vector;
							vector..ctor(Camera.main.transform.position.x + num, Camera.main.transform.position.y, Camera.main.transform.position.z + num2);
							Debug.Log(string.Format("Attempting to teleport item {0} to position: {1}", text, vector));
							try
							{
								lootItem.transform.position = vector;
								num += 0.1f;
								num2 += 0.1f;
								num3++;
								Debug.Log("Successfully teleported item " + text);
								goto IL_264;
							}
							catch (Exception ex2)
							{
								Debug.Log("Failed to teleport item " + text + ": " + ex2.Message);
								goto IL_264;
							}
						}
						Debug.Log(string.Format("Item {0} value ({1}) is below minimum ({2}), not teleporting", text, num4, Settings.LootMinimumValue));
					}
				}
				IL_264:;
			}
			Debug.Log(string.Format("TeleportItemsToPlayer completed. Teleported {0} items.", num3));
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000057E8 File Offset: 0x000039E8
		private void TeleportAllEnemies()
		{
			Vector3 targetPosition = this.GetTargetPosition();
			GameWorld instance = Singleton<GameWorld>.Instance;
			if (instance != null)
			{
				foreach (Player player in from x in instance.AllAlivePlayersList
				where !x.IsYourPlayer
				select x)
				{
					player.Teleport(targetPosition, false);
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00005870 File Offset: 0x00003A70
		public void InfiniteStamina()
		{
			EFTHardSettings.Instance.LOOT_RAYCAST_DISTANCE = 6f;
			EFTHardSettings.Instance.DOOR_RAYCAST_DISTANCE = 6f;
			Player localPlayer = Main.LocalPlayer;
			\uE340 physical = Main.LocalPlayer.Physical;
			\uE33F stamina = physical.Stamina;
			\uE33F handsStamina = physical.HandsStamina;
			\uE33F oxygen = physical.Oxygen;
			if (stamina.Current < 99f)
			{
				stamina.Current = stamina.TotalCapacity.Value;
			}
			if (handsStamina.Current < 99f)
			{
				handsStamina.Current = handsStamina.TotalCapacity.Value;
			}
			if (oxygen.Current < 99f)
			{
				oxygen.Current = oxygen.TotalCapacity.Value;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000591C File Offset: 0x00003B1C
		private void TeleportBosses()
		{
			Vector3 targetPosition = this.GetTargetPosition();
			GameWorld instance = Singleton<GameWorld>.Instance;
			if (instance != null)
			{
				foreach (Player player in from x in instance.AllAlivePlayersList
				where !x.IsYourPlayer && PlayerESP.IsBossByName(x.Profile.Info.Nickname)
				select x)
				{
					player.Teleport(targetPosition, false);
				}
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000059A4 File Offset: 0x00003BA4
		public void CallAirdrop(bool takeNearbyPoint = false, Vector3 position = default(Vector3))
		{
			GameWorld gameWorld = Main.GameWorld;
			if (gameWorld != null)
			{
				gameWorld.InitAirdrop(takeNearbyPoint, position);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000059C8 File Offset: 0x00003BC8
		private Vector3 GetTargetPosition()
		{
			if (!(Main.LocalPlayer != null))
			{
				return Vector3.zero;
			}
			return Main.LocalPlayer.Transform.position;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000059EC File Offset: 0x00003BEC
		public void Skillhack()
		{
			Player localPlayer = Main.LocalPlayer;
			if (localPlayer != null)
			{
				localPlayer.Skills.Strength.SetLevel(51);
				localPlayer.Skills.StressResistance.SetLevel(51);
				localPlayer.Skills.MagDrills.SetLevel(51);
				localPlayer.Skills.Melee.SetLevel(51);
				localPlayer.Skills.HideoutManagement.SetLevel(50);
				localPlayer.Skills.Crafting.SetLevel(51);
				localPlayer.Skills.HeavyVests.SetLevel(51);
				localPlayer.Skills.LightVests.SetLevel(51);
				localPlayer.Skills.RecoilControl.SetLevel(51);
				localPlayer.Skills.LMG.SetLevel(51);
				localPlayer.Skills.Assault.SetLevel(51);
				localPlayer.Skills.Pistol.SetLevel(51);
				localPlayer.Skills.Perception.SetLevel(51);
				localPlayer.Skills.Sniper.SetLevel(51);
				localPlayer.Skills.Sniping.SetLevel(51);
				localPlayer.Skills.Endurance.SetLevel(51);
				localPlayer.Skills.Throwing.SetLevel(51);
				localPlayer.Skills.Charisma.SetLevel(51);
				localPlayer.Skills.BotReload.SetLevel(0);
				localPlayer.Skills.TroubleShooting.SetLevel(51);
				localPlayer.Skills.Health.SetLevel(51);
				localPlayer.Skills.Vitality.SetLevel(51);
				localPlayer.Skills.Metabolism.SetLevel(51);
				localPlayer.Skills.Immunity.SetLevel(51);
				localPlayer.Skills.Intellect.SetLevel(51);
				localPlayer.Skills.Attention.SetLevel(51);
				localPlayer.Skills.Shotgun.SetLevel(51);
				localPlayer.Skills.HMG.SetLevel(51);
				localPlayer.Skills.Launcher.SetLevel(51);
				localPlayer.Skills.DMR.SetLevel(51);
				localPlayer.Skills.AimDrills.SetLevel(51);
				localPlayer.Skills.Surgery.SetLevel(51);
				localPlayer.Skills.CovertMovement.SetLevel(51);
				localPlayer.Skills.Search.SetLevel(51);
				localPlayer.Skills.FieldMedicine.SetLevel(0);
				localPlayer.Skills.FirstAid.SetLevel(0);
				localPlayer.Skills.SMG.SetLevel(51);
				localPlayer.Skills.WeaponTreatment.SetLevel(51);
				localPlayer.Skills.Revolver.SetLevel(51);
				localPlayer.Skills.AttachedLauncher.SetLevel(51);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00005CD8 File Offset: 0x00003ED8
		public static bool IsPlayerVisible(Player player)
		{
			if (player == null || Camera.main == null)
			{
				return false;
			}
			foreach (BifacialTransform bifacialTransform in new BifacialTransform[]
			{
				player.PlayerBones.Head
			})
			{
				if (bifacialTransform != null)
				{
					Vector3 vector = Camera.main.transform.position;
					Vector3 position = bifacialTransform.position;
					vector += (position - vector).normalized * 0.1f;
					bifacialTransform.position - Camera.main.transform.position;
					RaycastHit raycastHit;
					if (Physics.Linecast(vector, position, ref raycastHit, Main._layerMask) && raycastHit.transform.position == bifacialTransform.position)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00005DB8 File Offset: 0x00003FB8
		public bool IsExfiltrationPointEnabled()
		{
			foreach (GameExfiltrationPoint gameExfiltrationPoint in this._exfiltrationPoints)
			{
				string[] eligibleEntryPoints = gameExfiltrationPoint.ExfiltrationPoint.EligibleEntryPoints;
				for (int i = 0; i < eligibleEntryPoints.Length; i++)
				{
					string a = eligibleEntryPoints[i].ToLower();
					Player localPlayer = Main.LocalPlayer;
					string b;
					if (localPlayer == null)
					{
						b = null;
					}
					else
					{
						Profile profile = localPlayer.Profile;
						if (profile == null)
						{
							b = null;
						}
						else
						{
							\uE7E1 info = profile.Info;
							if (info == null)
							{
								b = null;
							}
							else
							{
								string entryPoint = info.EntryPoint;
								b = ((entryPoint != null) ? entryPoint.ToLower() : null);
							}
						}
					}
					if (a == b && (gameExfiltrationPoint.ExfiltrationPoint.Status == 3 || gameExfiltrationPoint.ExfiltrationPoint.Status == 4))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x04000033 RID: 51
		public static List<GamePlayer> GamePlayers = new List<GamePlayer>();

		// Token: 0x04000034 RID: 52
		public static Player LocalPlayer;

		// Token: 0x04000035 RID: 53
		public static GameWorld GameWorld;

		// Token: 0x04000036 RID: 54
		public static Camera MainCamera;

		// Token: 0x04000037 RID: 55
		private float _nextPlayerCacheTime;

		// Token: 0x04000038 RID: 56
		private static readonly float _cachePlayersInterval = 4f;

		// Token: 0x04000039 RID: 57
		public static ItemFeatures ItemFeatures;

		// Token: 0x0400003A RID: 58
		private bool FullbrightCalled;

		// Token: 0x0400003B RID: 59
		private List<GameExfiltrationPoint> _exfiltrationPoints = new List<GameExfiltrationPoint>();

		// Token: 0x0400003C RID: 60
		private bool isGodModeActive;

		// Token: 0x0400003D RID: 61
		private BossSpawner _bossSpawner;

		// Token: 0x0400003E RID: 62
		private static readonly LayerMask _layerMask = 71636992;
	}
}
