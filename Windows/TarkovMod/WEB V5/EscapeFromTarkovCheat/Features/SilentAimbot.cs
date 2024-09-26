using System;
using EFT;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Features
{
	// Token: 0x02000015 RID: 21
	public class SilentAimbot : MonoBehaviour
	{
		// Token: 0x0600009C RID: 156 RVA: 0x00008580 File Offset: 0x00006780
		public void Update()
		{
			if (Main.GameWorld != null && Settings.SilentAim && Input.GetKey(Settings.AimbotKey))
			{
				this.Aim();
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000085A8 File Offset: 0x000067A8
		private void Aim()
		{
			Vector3 vector = Vector3.zero;
			float num = 9999f;
			this.currentTarget = vector;
			foreach (GamePlayer gamePlayer in Main.GamePlayers)
			{
				if (gamePlayer != null && SilentAimbot.IsPlayerVisible(gamePlayer.Player))
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
								if (num2 <= 200f && bonePosByID != Vector3.zero && SilentAimbot.CalculateInFov(bonePosByID) <= Settings.AimbotFOV && num > num2)
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
				SilentAimbot.AimAtPos(vector);
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00008734 File Offset: 0x00006934
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

		// Token: 0x0600009F RID: 159 RVA: 0x00008784 File Offset: 0x00006984
		public static float CalculateInFov(Vector3 position1)
		{
			Vector3 position2 = Main.MainCamera.transform.position;
			Vector3 forward = Main.MainCamera.transform.forward;
			Vector3 normalized = (position1 - position2).normalized;
			return Mathf.Acos(Mathf.Clamp(Vector3.Dot(forward, normalized), -1f, 1f)) * 57.29578f;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000087E0 File Offset: 0x000069E0
		public static void AimAtPos(Vector3 position)
		{
			if (Settings.SilentAim)
			{
				Main.LocalPlayer.ProceduralWeaponAnimation.ShotNeedsFovAdjustments = false;
				Vector3 normalized = (position - Main.LocalPlayer.Fireport.position).normalized;
				Vector3 shotDirection = Main.LocalPlayer.Fireport.InverseTransformVector(normalized);
				Main.LocalPlayer.ProceduralWeaponAnimation._shotDirection = shotDirection;
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00008844 File Offset: 0x00006A44
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
					if (Physics.Linecast(vector, position, ref raycastHit, SilentAimbot._layerMask) && raycastHit.transform.position == bifacialTransform.position)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0400008D RID: 141
		private Vector3 currentTarget = Vector3.zero;

		// Token: 0x0400008E RID: 142
		private static readonly LayerMask _layerMask = 71636992;
	}
}
