using System;
using EFT;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Features
{
	// Token: 0x02000011 RID: 17
	public class Aimbot : MonoBehaviour
	{
		// Token: 0x06000080 RID: 128 RVA: 0x00007D5F File Offset: 0x00005F5F
		public void Update()
		{
			if (Main.GameWorld != null && Settings.Aimbot && Input.GetKey(Settings.AimbotKey))
			{
				this.Aim();
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00007D88 File Offset: 0x00005F88
		private void Aim()
		{
			Vector3 vector = Vector3.zero;
			float num = 9999f;
			this.currentTarget = vector;
			foreach (GamePlayer gamePlayer in Main.GamePlayers)
			{
				if (gamePlayer != null && Aimbot.IsPlayerVisible(gamePlayer.Player))
				{
					if (!(Main.LocalPlayer.HandsController == null))
					{
						Weapon weapon = Main.LocalPlayer.HandsController.Item as Weapon;
						if (weapon != null)
						{
							AmmoTemplate currentAmmoTemplate = weapon.CurrentAmmoTemplate;
							if (currentAmmoTemplate != null)
							{
								Vector3 bonePosByID = GameUtils.GetBonePosByID(gamePlayer.Player, 133);
								float num2 = Vector3.Distance(Main.MainCamera.transform.position, gamePlayer.Player.Transform.position);
								if (num2 <= 200f && bonePosByID != Vector3.zero && Aimbot.CalculateInFov(bonePosByID) <= Settings.AimbotFOV && num > num2)
								{
									num = num2;
									float num3 = num2 / currentAmmoTemplate.InitialSpeed;
									bonePosByID.x += gamePlayer.Player.Velocity.x * num3;
									bonePosByID.y += gamePlayer.Player.Velocity.y * num3;
									vector = bonePosByID;
									continue;
								}
								continue;
							}
						}
					}
					return;
				}
			}
			if (vector != Vector3.zero)
			{
				Aimbot.AimAtPos(vector);
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00007F14 File Offset: 0x00006114
		public void OnGUI()
		{
			if (Settings.AimbotDrawFOV)
			{
				float aimbotFOV = Settings.AimbotFOV;
				int numSides = 64;
				Color red = Color.red;
				float thickness = 1f;
				Render.DrawCircle(new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f), aimbotFOV, numSides, red, true, thickness);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00007F64 File Offset: 0x00006164
		public static float CalculateInFov(Vector3 position1)
		{
			Vector3 position2 = Main.MainCamera.transform.position;
			Vector3 forward = Main.MainCamera.transform.forward;
			Vector3 normalized = (position1 - position2).normalized;
			return Mathf.Acos(Mathf.Clamp(Vector3.Dot(forward, normalized), -1f, 1f)) * 57.29578f;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00007FC0 File Offset: 0x000061C0
		public static void AimAtPos(Vector3 position)
		{
			Vector3 vector = Main.LocalPlayer.Fireport.position - Main.LocalPlayer.Fireport.up * 1f;
			Vector3 eulerAngles = Quaternion.LookRotation((position - vector).normalized).eulerAngles;
			if (eulerAngles.x > 180f)
			{
				eulerAngles.x -= 360f;
			}
			Main.LocalPlayer.MovementContext.Rotation = new Vector2(eulerAngles.y, eulerAngles.x);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00008058 File Offset: 0x00006258
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
					if (Physics.Linecast(vector, position, ref raycastHit, Aimbot._layerMask) && raycastHit.transform.position == bifacialTransform.position)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0400008B RID: 139
		private Vector3 currentTarget = Vector3.zero;

		// Token: 0x0400008C RID: 140
		private static readonly LayerMask _layerMask = 71636992;
	}
}
