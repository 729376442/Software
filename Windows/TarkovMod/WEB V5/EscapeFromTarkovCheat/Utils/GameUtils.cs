using System;
using System.Collections.Generic;
using System.Linq;
using Diz.Skinning;
using EFT;
using EFT.Interactive;
using EFT.InventoryLogic;
using UnityEngine;

namespace EscapeFromTarkovCheat.Utils
{
	// Token: 0x0200000E RID: 14
	public static class GameUtils
	{
		// Token: 0x0600005F RID: 95 RVA: 0x0000754E File Offset: 0x0000574E
		public static float Map(float value, float sourceFrom, float sourceTo, float destinationFrom, float destinationTo)
		{
			return (value - sourceFrom) / (sourceTo - sourceFrom) * (destinationTo - destinationFrom) + destinationFrom;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000755E File Offset: 0x0000575E
		public static bool IsPlayerValid(Player player)
		{
			return player != null && player.Transform != null && player.PlayerBones != null && player.PlayerBones.transform != null;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00007592 File Offset: 0x00005792
		public static bool IsExfiltrationPointValid(ExfiltrationPoint exfiltrationPoint)
		{
			return exfiltrationPoint != null;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000759B File Offset: 0x0000579B
		public static bool IsLootItemValid(LootItem lootItem)
		{
			return lootItem != null && lootItem.Item != null && lootItem.Item.Template != null;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000075BE File Offset: 0x000057BE
		public static bool IsLootableContainerValid(LootableContainer lootableContainer)
		{
			return lootableContainer != null && lootableContainer.Template != null;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000075D4 File Offset: 0x000057D4
		public static bool IsPlayerAlive(Player player)
		{
			return GameUtils.IsPlayerValid(player) && player.HealthController != null && player.HealthController.IsAlive;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000075F8 File Offset: 0x000057F8
		public static Vector3 WorldPointToScreenPoint(Vector3 worldPoint)
		{
			Vector3 vector = Main.MainCamera.WorldToScreenPoint(worldPoint);
			float num = (float)Screen.height / (float)Main.MainCamera.scaledPixelHeight;
			vector.y = (float)Screen.height - vector.y * num;
			vector.x *= num;
			return vector;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00007648 File Offset: 0x00005848
		public static bool IsScreenPointVisible(Vector3 screenPoint)
		{
			return screenPoint.z > 0.01f && screenPoint.x > -5f && screenPoint.y > -5f && screenPoint.x < (float)Screen.width && screenPoint.y < (float)Screen.height;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000769C File Offset: 0x0000589C
		public static Vector3 GetBonePosByID(Player player, int id)
		{
			Vector3 result;
			try
			{
				result = GameUtils.SkeletonBonePos(player.PlayerBones.AnimatedTransform.Original.gameObject.GetComponent<PlayerBody>().SkeletonRootJoint, id);
			}
			catch (Exception)
			{
				result = Vector3.zero;
			}
			return result;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000076EC File Offset: 0x000058EC
		public static Vector3 SkeletonBonePos(Skeleton skeleton, int id)
		{
			return skeleton.Bones.ElementAt(id).Value.position;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00007712 File Offset: 0x00005912
		public static bool IsInventoryItemValid(Item item)
		{
			return item != null && item.Template != null;
		}
	}
}
