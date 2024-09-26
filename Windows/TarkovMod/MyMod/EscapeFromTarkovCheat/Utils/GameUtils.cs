using System;
using System.Linq;
using Diz.Skinning;
using EFT;
using EFT.Interactive;
using EFT.InventoryLogic;
using UnityEngine;

namespace EscapeFromTarkovCheat.Utils
{

    public static class GameUtils
    {
        public static float Map(float value, float sourceFrom, float sourceTo, float destinationFrom, float destinationTo)
        {
            return (value - sourceFrom) / (sourceTo - sourceFrom) * (destinationTo - destinationFrom) + destinationFrom;
        }
        public static bool IsPlayerVisible(Player player)
        {
            if (player == null || Camera.main == null)
                return false;

            // Liste des points importants à vérifier pour la visibilité
            BifacialTransform[] pointsToCheck = {
            player.PlayerBones.Head,
            player.PlayerBones.Spine3,
            player.PlayerBones.Pelvis
        };

            foreach (BifacialTransform point in pointsToCheck)
            {
                if (point == null)
                    continue;

                // Direction du raycast de la caméra vers le point
                Vector3 direction = point.position - Camera.main.transform.position;

                // Effectuez un raycast
                if (!Physics.Raycast(Camera.main.transform.position, direction, out RaycastHit hit, direction.magnitude))
                {
                    continue;
                }

                // Si le raycast touche le joueur, il est visible
                if (hit.collider.gameObject == player.gameObject)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool IsPlayerValid(Player player)
        {
            return player != null && player.Transform != null && player.PlayerBones != null && player.PlayerBones.transform != null;
        }
        public static bool IsExfiltrationPointValid(ExfiltrationPoint lootItem)
        {
            return lootItem != null;
        }
        public static bool IsLootItemValid(LootItem lootItem)
        {
            return lootItem != null && lootItem.Item != null && lootItem.Item.Template != null;
        }

        public static bool IsLootableContainerValid(LootableContainer lootableContainer)
        {
            return lootableContainer != null && lootableContainer.Template != null;
        }

        public static bool IsPlayerAlive(Player player)
        {
            if (!IsPlayerValid(player))
                return false;

            if (player.HealthController == null)
                return false;

            return player.HealthController.IsAlive;
        }

        public static Vector3 WorldPointToScreenPoint(Vector3 worldPoint)
        {
            var screenPoint = Main.MainCamera.WorldToScreenPoint(worldPoint);
            var scale = Screen.height / (float)Main.MainCamera.scaledPixelHeight;
            screenPoint.y = Screen.height - screenPoint.y * scale;
            screenPoint.x *= scale;
            return screenPoint;
        }

        public static bool IsScreenPointVisible(Vector3 screenPoint)
        {
            return screenPoint.z > 0.01f && screenPoint.x > -5f && screenPoint.y > -5f && screenPoint.x < Screen.width && screenPoint.y < Screen.height;
        }
        public static bool IsInventoryItemValid(Item item)
        {
            return item != null && item.Template != null;
        }
    }

}