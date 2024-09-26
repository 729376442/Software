using System;
using EFT;
using EFT.Animations;
using EFT.Animations.Recoil;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Features
{
	// Token: 0x02000014 RID: 20
	internal class NoRecoil : MonoBehaviour
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00008285 File Offset: 0x00006485
		public void Update()
		{
			if (Settings.NoRecoil)
			{
				this.ApplyNoRecoil();
				return;
			}
			this.ResetRecoil();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000829C File Offset: 0x0000649C
		private void ApplyNoRecoil()
		{
			if (Main.LocalPlayer == null)
			{
				return;
			}
			Player localPlayer = Main.LocalPlayer;
			if (localPlayer.ProceduralWeaponAnimation == null)
			{
				return;
			}
			ShotEffector shootingg = localPlayer.ProceduralWeaponAnimation.Shootingg;
			IRecoilShotEffect recoilShotEffect = (shootingg != null) ? shootingg.CurrentRecoilEffect : null;
			if (recoilShotEffect == null)
			{
				return;
			}
			recoilShotEffect.CameraRotationRecoilEffect.Intensity = 0f;
			recoilShotEffect.HandPositionRecoilEffect.Intensity = 0f;
			recoilShotEffect.HandRotationRecoilEffect.Intensity = 0f;
			localPlayer.ProceduralWeaponAnimation.HandsContainer.HandsRotation.Current.x = 0f;
			localPlayer.ProceduralWeaponAnimation.HandsContainer.HandsRotation.Current.y = 0f;
			localPlayer.ProceduralWeaponAnimation.HandsContainer.HandsRotation.Current.z = 0f;
			localPlayer.ProceduralWeaponAnimation.HandsContainer.HandsPosition.Current.x = 0f;
			localPlayer.ProceduralWeaponAnimation.HandsContainer.HandsPosition.Current.y = 0f;
			localPlayer.ProceduralWeaponAnimation.HandsContainer.HandsPosition.Current.z = 0f;
			if (localPlayer.HandsController == null || !(localPlayer.HandsController.Item is Weapon))
			{
				return;
			}
			Player.FirearmController firearmController = localPlayer.HandsController as Player.FirearmController;
			if (firearmController == null)
			{
				return;
			}
			Weapon item = firearmController.Item;
			WeaponTemplate weaponTemplate = (item != null) ? item.Template : null;
			if (weaponTemplate == null)
			{
				return;
			}
			weaponTemplate.AllowFeed = false;
			weaponTemplate.AllowJam = false;
			weaponTemplate.AllowMisfire = false;
			weaponTemplate.AllowOverheat = false;
			weaponTemplate.AllowSlide = false;
			weaponTemplate.BoltAction = false;
			weaponTemplate.bFirerate = 500;
			weaponTemplate.DefAmmoTemplate.PenetrationPower = 100000;
			weaponTemplate.DefAmmoTemplate.PenetrationChanceObstacle = 100f;
			ProceduralWeaponAnimation proceduralWeaponAnimation = localPlayer.ProceduralWeaponAnimation;
			MotionEffector motionReact = proceduralWeaponAnimation.MotionReact;
			motionReact.Intensity = 0f;
			motionReact.SwayFactors = Vector3.zero;
			motionReact.Velocity = Vector3.zero;
			proceduralWeaponAnimation.Breath.Intensity = 0f;
			proceduralWeaponAnimation.Breath.HipPenalty = 0f;
			proceduralWeaponAnimation.Breath.Overweight = 0f;
			proceduralWeaponAnimation.Walk.Intensity = 0f;
			proceduralWeaponAnimation.AimingDisplacementStr = 0f;
			proceduralWeaponAnimation.ForceReact.Intensity = 0f;
			proceduralWeaponAnimation.WalkEffectorEnabled = false;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000084FC File Offset: 0x000066FC
		private void ResetRecoil()
		{
			if (Main.LocalPlayer == null)
			{
				return;
			}
			Player localPlayer = Main.LocalPlayer;
			if (localPlayer.ProceduralWeaponAnimation == null)
			{
				return;
			}
			ShotEffector shootingg = localPlayer.ProceduralWeaponAnimation.Shootingg;
			IRecoilShotEffect recoilShotEffect = (shootingg != null) ? shootingg.CurrentRecoilEffect : null;
			if (recoilShotEffect == null)
			{
				return;
			}
			recoilShotEffect.CameraRotationRecoilEffect.Intensity = 1f;
			recoilShotEffect.HandPositionRecoilEffect.Intensity = 1f;
			recoilShotEffect.HandRotationRecoilEffect.Intensity = 1f;
		}
	}
}
