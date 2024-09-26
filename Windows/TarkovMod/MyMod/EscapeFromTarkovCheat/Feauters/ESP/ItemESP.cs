using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Comfort.Common;
using EFT;
using EFT.Interactive;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using JsonType;
using UnityEngine;

namespace EscapeFromTarkovCheat.Feauters.ESP
{
    public class ItemESP : MonoBehaviour
    {
        private static readonly float CacheLootItemsInterval = 4f;
        private float _nextLootItemCacheTime;

        //private static readonly Color SpecialColor = new Color(1f, 0.2f, 0.09f);
        private static readonly Color QuestColor = Color.yellow;
        private static readonly Color CommonColor = Color.white;
        private static readonly Color RareColor = new Color(0.38f, 0.43f, 1f);
        private static readonly Color SuperRareColor = new Color(1f, 0.29f, 0.36f);
        private static readonly Color TargetColor = new Color(1f, 0.6f, 0f);

        private List<GameLootItem> _gameLootItems = new List<GameLootItem>();
        private List<GameLootItem> _gameLootItemsCommon = new List<GameLootItem>();
        private Stopwatch _stopwatch = new Stopwatch();
        public void Update()
        {
            if (!Settings.DrawLootItems)
                return;

            if (Time.time >= _nextLootItemCacheTime)
            {
                if ((Main.GameWorld != null) && (Main.GameWorld.LootItems != null))
                {
                    _gameLootItems.Clear();
                    _gameLootItemsCommon.Clear();

                    for (int i = 0; i < Main.GameWorld.LootItems.Count; i++)
                    {
                        LootItem lootItem = Main.GameWorld.LootItems.GetByIndex(i);

                        if (!GameUtils.IsLootItemValid(lootItem))
                        {
                            continue;
                        }
                        if (Vector3.Distance(Main.MainCamera.transform.position, lootItem.transform.position) > Settings.DrawLootItemsDistance)
                        {
                            if (!lootItem.Item.Template.QuestItem)
                                continue;
                            //(Settings.DrawNearbyLootItems && Vector3.Distance(Main.MainCamera.transform.position, lootItem.transform.position) < 10f)
                        }
                        if ((!lootItem.Item.Template.QuestItem && Main.CheckLootItem(lootItem.Item,false)) || Main.CheckWishList(lootItem.Item))
                        {
                            if (!Settings.DrawDeadBodyItems && (lootItem.Item.ShortName.Localized() == "默认物品栏" || lootItem.Item.ShortName.Localized() == "Default Inventory"))
                            {
                                continue;
                            }
                            _gameLootItems.Add(new GameLootItem(lootItem));
                        }
                        else if(!lootItem.Item.Template.QuestItem && Settings.DrawNearbyLootItems && Vector3.Distance(Main.MainCamera.transform.position, lootItem.transform.position) < 7f)
                        {
                            _gameLootItemsCommon.Add(new GameLootItem(lootItem));
                        }
                        
                    }

                    _nextLootItemCacheTime = (Time.time + CacheLootItemsInterval);
                }
            }

            foreach (GameLootItem gameLootItem in _gameLootItems)
                gameLootItem.RecalculateDynamics();

            foreach (GameLootItem gameLootItem in _gameLootItemsCommon)
                gameLootItem.RecalculateDynamics();
        }

        private void OnGUI()
        {
            if (Settings.DrawLootItems)
            {
                foreach (var gameLootItem in _gameLootItems)
                {
                    if (!GameUtils.IsLootItemValid(gameLootItem.LootItem) || !gameLootItem.IsOnScreen)
                        continue;
                    if(gameLootItem.Distance > Settings.DrawLootItemsDistance)
                    {
                        if (!gameLootItem.LootItem.Item.Template.QuestItem)
                            continue;
                    }

                    string lootItemName = $"{gameLootItem.LootItem.Item.ShortName.Localized()} [{gameLootItem.FormattedDistance}]";

                    if (gameLootItem.LootItem.Item.Template.Rarity == ELootRarity.Common)
                        Render.DrawString(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), lootItemName, TargetColor);
                    if (gameLootItem.LootItem.Item.Template.Rarity == ELootRarity.Rare)
                        Render.DrawString(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), lootItemName, TargetColor);
                    if (gameLootItem.LootItem.Item.Template.Rarity == ELootRarity.Superrare)
                        Render.DrawString(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), lootItemName, TargetColor);
                    if (gameLootItem.LootItem.Item.Template.QuestItem)
                        Render.DrawString(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), lootItemName, QuestColor);
                }
            }
            foreach (var gameLootItem in _gameLootItemsCommon)
            {
                if (!GameUtils.IsLootItemValid(gameLootItem.LootItem) || !gameLootItem.IsOnScreen)
                    continue;
                if (gameLootItem.Distance > Settings.DrawLootItemsDistance)
                {
                    if (!gameLootItem.LootItem.Item.Template.QuestItem)
                        continue;
                }

                string lootItemName = $"{gameLootItem.LootItem.Item.ShortName.Localized()} [{gameLootItem.FormattedDistance}]";

                Render.DrawString(new Vector2(gameLootItem.ScreenPosition.x - 50f, gameLootItem.ScreenPosition.y), lootItemName, CommonColor);
            }
        }
    }
}
