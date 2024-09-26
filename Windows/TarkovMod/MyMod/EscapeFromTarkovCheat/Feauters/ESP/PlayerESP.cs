using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Comfort.Common;
using EFT;
using EFT.HealthSystem;
using EFT.Interactive;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Feauters.ESP;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Feauters.ESP
{


    public class PlayerESP : MonoBehaviour
    {
        private static readonly Color _playerColor = Color.cyan;
        private static readonly Color _botColor = Color.yellow;
        private static readonly Color _healthColor = Color.green;
        private static readonly Color _bossColor = Color.red;
        private static readonly Color _guardColor = Color.magenta;
        private static readonly Color _skeletonColor = Color.white;
        private static readonly Color _itemColor = new Color(1f, 0.6f, 0f);

        public static List<PlayerAndItem> PlayerItemsCombos= new List<PlayerAndItem>();

        internal static List<WildSpawnType> BossList = new List<WildSpawnType> {
            WildSpawnType.bossBully,
            WildSpawnType.bossKilla,
            WildSpawnType.bossKojaniy,
            WildSpawnType.bossGluhar,
            WildSpawnType.bossSanitar,
            WildSpawnType.sectantPriest,
            WildSpawnType.bossTagilla,
            WildSpawnType.bossKnight,
            WildSpawnType.followerBigPipe,
            WildSpawnType.followerBirdEye,
            WildSpawnType.bossZryachiy,
            WildSpawnType.bossBoar,
            WildSpawnType.bossPartisan,
            WildSpawnType.bossKolontay,
            WildSpawnType.ravangeZryachiyEvent,
        };

        internal static List<WildSpawnType> GuardList = new List<WildSpawnType> {
            WildSpawnType.followerBully,
            WildSpawnType.followerKojaniy,
            WildSpawnType.followerGluharAssault,
            WildSpawnType.followerGluharSecurity,
            WildSpawnType.followerGluharScout,
            WildSpawnType.followerGluharSnipe,
            WildSpawnType.followerSanitar,
            WildSpawnType.sectantWarrior,
            WildSpawnType.followerTagilla,
            WildSpawnType.followerZryachiy,
            WildSpawnType.followerBoar,
            WildSpawnType.bossBoarSniper,
            WildSpawnType.followerBoarClose1,
            WildSpawnType.followerBoarClose2,
            WildSpawnType.followerKolontayAssault,
            WildSpawnType.followerKolontaySecurity,
        };


        public static string TranslateBossName(string name)
        {
                
            if (name != null)
            {
                switch (name.Length)
                {

                    case 4:
                        {
                            if (name == "Жрец")
                            {
                                return "Priest";
                            }
                            break;
                        }
                    case 5:
                        {
                            char c = name[1];
                            if (c != 'а')
                            {
                                if (c == 'и')
                                {
                                    if (name == "Килла")
                                    {
                                        return "Killa";
                                    }
                                }
                            }
                            else if (name == "Кабан")
                            {
                                return "Kaban";
                            }
                            break;
                        }
                    case 6:
                        {
                            char c = name[0];
                            if (c != 'K')
                            {
                                if (c != 'З')
                                {
                                    if (c == 'Р')
                                    {
                                        if (name == "Решала")
                                        {
                                            return "Reshala";
                                        }
                                    }
                                }
                                else if (name == "Зрячий")
                                {
                                    return "Zryachiy";
                                }
                            }
                            else if (name == "Knight")
                            {
                                return "Knight";
                            }
                            break;
                        }
                    case 7:
                        {
                            char c = name[0];
                            if (c <= 'Г')
                            {
                                if (c != 'B')
                                {
                                    if (c == 'Г')
                                    {
                                        if (name == "Глухарь")
                                        {
                                            return "Gluhar";
                                        }
                                    }
                                }
                                else if (name == "Birdeye")
                                {
                                    return "Birdeye";
                                }
                            }
                            else if (c != 'С')
                            {
                                if (c != 'Т')
                                {
                                    if (c == 'Ш')
                                    {
                                        if (name == "Штурман")
                                        {
                                            return "Shturman";
                                        }
                                    }
                                }
                                else if (name == "Тагилла")
                                {
                                    return "Tagilla";
                                }
                            }
                            else if (name == "Санитар")
                            {
                                return "Sanitar";
                            }
                            break;
                        }
                    case 8:
                        if (name == "Big Pipe")
                        {
                            return "Big Pipe";
                        }
                        else if (name == "Партизан")
                        {
                            return "Partisan";
                        }
                        break;
                    case 9:
                        {
                            char c = name[0];
                            if (c != 'Д')
                            {
                                if (c == 'К')
                                {
                                    if (name == "Коллонтай")
                                    {
                                        return "Kollontay";
                                    }
                                }
                            }
                            else if (name == "Дед Мороз")
                            {
                                return "Santa";
                            }
                            break;
                        }
                }
            }
            return name;
        }

        public static string PlayerText(Player player, ref Color color)
        {
            if (BossList.Contains(player.Profile.Info.Settings.Role))
            {
                color = PlayerESP._bossColor;
                return PlayerESP.TranslateBossName(player.Profile.Info.Nickname);
            }
            if (GuardList.Contains(player.Profile.Info.Settings.Role))
            {
                color = PlayerESP._guardColor;
                return "Guard";
            }
            if (player.Profile.Info.Settings.Role == WildSpawnType.pmcBot)
            {
                color = PlayerESP._guardColor;
                return "Raider";
            }
            if (player.Profile.Info.Settings.Role == WildSpawnType.exUsec)
            {
                color = PlayerESP._guardColor;
                return "Rogue";
            }
            if (player.Profile.Info.Settings.Role == WildSpawnType.marksman)
            {
                color = PlayerESP._guardColor;
                return "Sniper";
            }
            if (player.Profile.Info.Settings.Role == WildSpawnType.shooterBTR)
            {
                color = PlayerESP._bossColor;
                return "BTR";
            }
            if ((player.Profile.Info.Settings.Role == WildSpawnType.pmcUSEC || player.Profile.Info.Settings.Role == WildSpawnType.pmcBEAR) && player.Profile.Info.Level >= 60)
            {
                color = PlayerESP._bossColor;
                return "Veteran PMC" + "[" + player.Profile.Info.Level.ToString() + "]";
            }
            if (player.Profile.Info.Settings.Role == WildSpawnType.pmcBEAR)
            {
                color = PlayerESP._playerColor;
                return "BEAR" + "[" + player.Profile.Info.Level.ToString() + "]";
            }
            if (player.Profile.Info.Settings.Role == WildSpawnType.pmcUSEC)
            {
                color = PlayerESP._playerColor;
                return "USEC" + "[" + player.Profile.Info.Level.ToString() + "]";
            }
            color = PlayerESP._botColor;
            return "Scav";
        }
        public void Start()
        {
            PlayerItemsCombos = new List<PlayerAndItem>();
        }

        public void OnGUI()
        {
            if (Settings.DrawPlayerLoots)
            {
                foreach (PlayerAndItem temp in PlayerItemsCombos)
                {
                    if (temp.PlayerRef.IsOnScreen && temp.PlayerRef.Distance < Settings.DrawPlayersDistance)
                    {
                        if (!Settings.DrawPlayers)
                        {
                            Color playerColor = ((temp.PlayerRef.IsAI) ? _botColor : _playerColor);
                            string text = PlayerText(temp.PlayerRef.Player, ref playerColor);
                            text = text + " [" + temp.PlayerRef.FormattedDistance + "]";
                            Vector2 vector = GUI.skin.GetStyle(text).CalcSize(new GUIContent(text));
                            Render.DrawString(new Vector2(temp.PlayerRef.ScreenPosition.x - vector.x / 2f, temp.PlayerRef.HeadScreenPosition.y - 20f), text, playerColor, true);
                        }
                        float num = -15f;
                        foreach (string itemName in temp.NameList)
                        {
                            string itemLabel = string.Format("{0}", itemName);
                            Color itemTextColor = _itemColor;
                            string itemText = PlayerText(temp.PlayerRef.Player, ref itemTextColor) + " [" + temp.PlayerRef.FormattedDistance + "]";
                            Vector2 vectorTemp = GUI.skin.GetStyle(itemText).CalcSize(new GUIContent(itemText));
                            Render.DrawString(new Vector2(temp.PlayerRef.ScreenPosition.x - vectorTemp.x / 2f, temp.PlayerRef.HeadScreenPosition.y - 20f + num), itemLabel, _itemColor, true);
                            num -= 15f;
                        }
                    }
                }
            }
            if (!Settings.DrawPlayers)
                return;
            foreach (GamePlayer gamePlayer in Main.GamePlayers)
            {
                if (!gamePlayer.IsOnScreen || gamePlayer.Distance > Settings.DrawPlayersDistance || gamePlayer.Player == Main.LocalPlayer)
                    continue;

                Color playerColor = ((gamePlayer.IsAI) ? _botColor : _playerColor);

                float boxPositionY = (gamePlayer.HeadScreenPosition.y - 10f);
                float boxHeight = (Math.Abs(gamePlayer.HeadScreenPosition.y - gamePlayer.ScreenPosition.y) + 10f);
                float boxWidth = (boxHeight * 0.65f);

                if (Settings.DrawPlayerBox)
                {
                    Render.DrawBox((gamePlayer.ScreenPosition.x - (boxWidth / 2f)), boxPositionY, boxWidth, boxHeight, playerColor);
                }

                if (Settings.DrawPlayerHealth)
                {
                    if (gamePlayer.Player.HealthController.IsAlive)
                    {
                        float currentPlayerHealth = gamePlayer.Player.HealthController.GetBodyPartHealth(EBodyPart.Common).Current;
                        float maximumPlayerHealth = gamePlayer.Player.HealthController.GetBodyPartHealth(EBodyPart.Common).Maximum;

                        float healthBarHeight = GameUtils.Map(currentPlayerHealth, 0f, maximumPlayerHealth, 0f, boxHeight);
                        Render.DrawLine(new Vector2((gamePlayer.ScreenPosition.x - (boxWidth / 2f) - 3f), (boxPositionY + boxHeight - healthBarHeight)), new Vector2((gamePlayer.ScreenPosition.x - (boxWidth / 2f) - 3f), (boxPositionY + boxHeight)), 3f, _healthColor);
                    }
                }

                if (Settings.DrawPlayerName)
                {
                    string text = PlayerText(gamePlayer.Player, ref playerColor);
                    text = text + " [" + gamePlayer.FormattedDistance + "]";
                    Vector2 vector = GUI.skin.GetStyle(text).CalcSize(new GUIContent(text));
                    Render.DrawString(new Vector2(gamePlayer.ScreenPosition.x - vector.x / 2f, gamePlayer.HeadScreenPosition.y - 20f), text, playerColor, true);
                }


                if (Settings.DrawPlayerLine)
                {
                    Render.DrawLine(new Vector2(Screen.width / 2, Screen.height), new Vector2(gamePlayer.ScreenPosition.x, gamePlayer.ScreenPosition.y), 1.5f, /*GameUtils.IsVisible(destination)*/false ? Color.green : Color.red);
                }
                
                // Draw skeleton

                if (Settings.DrawPlayerSkeleton)
                {
                    PlayerBones.DrawSkeleton(gamePlayer, _skeletonColor);
                }
            }
            
            
        }
    }
}