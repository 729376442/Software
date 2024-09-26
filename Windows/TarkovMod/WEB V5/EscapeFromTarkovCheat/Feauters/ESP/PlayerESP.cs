using System;
using EFT;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Feauters.ESP
{
	// Token: 0x0200000B RID: 11
	public class PlayerESP : MonoBehaviour
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00006BD4 File Offset: 0x00004DD4
		public static bool IsBossByName(string name)
		{
			return name == "Килла" || name == "Решала" || name == "Глухарь" || name == "Штурман" || name == "Санитар" || name == "Тагилла" || name == "Зрячий" || name == "Кабан" || name == "Big Pipe" || name == "Birdeye" || name == "Knight" || name == "Дед Мороз" || name == "Коллонтай";
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00006C94 File Offset: 0x00004E94
		public static string TranslateBossName(string name)
		{
			if (name != null)
			{
				switch (name.Length)
				{
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

		// Token: 0x06000055 RID: 85 RVA: 0x00006ED0 File Offset: 0x000050D0
		public static string PlayerName(Player player, ref PlayerESP.PlayerType playerType)
		{
			if (player.Profile.Info.RegistrationDate <= 0)
			{
				if (player.Profile.Info.Settings.Role.ToString().IndexOf("boss") != -1)
				{
					playerType = PlayerESP.PlayerType.Boss;
					return "BOSS";
				}
				if (player.Profile.Info.Settings.Role.ToString().IndexOf("follower") != -1)
				{
					playerType = PlayerESP.PlayerType.Follower;
					return "Follower";
				}
				if (player.Profile.Info.Settings.Role.ToString().ToLower().IndexOf("pmcbot") != -1)
				{
					playerType = PlayerESP.PlayerType.Scav;
					return "Raider";
				}
				playerType = PlayerESP.PlayerType.Scav;
				return "Scav";
			}
			else
			{
				if (player.Profile.Info.Side == 4)
				{
					playerType = PlayerESP.PlayerType.PlayerScav;
					return "Scav";
				}
				playerType = PlayerESP.PlayerType.Player;
				return player.Profile.Info.Side.ToString() + " [" + player.Profile.Info.Level.ToString() + "]";
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00007004 File Offset: 0x00005204
		public void OnGUI()
		{
			if (!Settings.DrawPlayers)
			{
				return;
			}
			foreach (GamePlayer gamePlayer in Main.GamePlayers)
			{
				if (gamePlayer.IsOnScreen && gamePlayer.Distance <= Settings.DrawPlayersDistance && !(gamePlayer.Player == Main.LocalPlayer))
				{
					Color color = gamePlayer.IsAI ? PlayerESP._botColor : PlayerESP._playerColor;
					float num = gamePlayer.HeadScreenPosition.y - 10f;
					float num2 = Math.Abs(gamePlayer.HeadScreenPosition.y - gamePlayer.ScreenPosition.y) + 10f;
					float num3 = num2 * 0.65f;
					if (Settings.DrawPlayerBox)
					{
						Render.DrawBox(gamePlayer.ScreenPosition.x - num3 / 2f, num, num3, num2, color);
					}
					if (Settings.DrawPlayerSkeleton)
					{
						this.DrawSkeleton(gamePlayer.Player);
					}
					if (Settings.DrawPlayerHealth && gamePlayer.Player.HealthController.IsAlive)
					{
						float current = gamePlayer.Player.HealthController.GetBodyPartHealth(7, false).Current;
						float maximum = gamePlayer.Player.HealthController.GetBodyPartHealth(7, false).Maximum;
						float num4 = GameUtils.Map(current, 0f, maximum, 0f, num2);
						Render.DrawLine(new Vector2(gamePlayer.ScreenPosition.x - num3 / 2f - 3f, num + num2 - num4), new Vector2(gamePlayer.ScreenPosition.x - num3 / 2f - 3f, num + num2), 3f, PlayerESP._healthColor);
					}
					if (Settings.DrawPlayerName)
					{
						WildSpawnType role = gamePlayer.Player.Profile.Info.Settings.Role;
						string text;
						if (\uE7D9.IsBoss(gamePlayer.Player.Profile.Info.Settings))
						{
							text = PlayerESP.TranslateBossName(gamePlayer.Player.Profile.Info.Nickname) + " [" + gamePlayer.FormattedDistance + "]";
							color = PlayerESP._bossColor;
						}
						else if (\uE7D9.IsFollower(gamePlayer.Player.Profile.Info.Settings))
						{
							text = string.Concat(new string[]
							{
								"Guard ",
								PlayerESP.TranslateBossName(gamePlayer.Player.Profile.Info.Nickname),
								" [",
								gamePlayer.FormattedDistance,
								"]"
							});
							color = PlayerESP._guardColor;
						}
						else if (gamePlayer.IsAI)
						{
							text = "Bot [" + gamePlayer.FormattedDistance + "]";
							color = PlayerESP._botColor;
						}
						else
						{
							text = "PMC [" + gamePlayer.FormattedDistance + "]";
							color = PlayerESP._playerColor;
						}
						Vector2 vector = GUI.skin.GetStyle(text).CalcSize(new GUIContent(text));
						Render.DrawString(new Vector2(gamePlayer.ScreenPosition.x - vector.x / 2f, gamePlayer.HeadScreenPosition.y - 20f), text, color, true);
					}
					if (Settings.DrawPlayerLine)
					{
						Render.DrawLine(new Vector2((float)(Screen.width / 2), (float)Screen.height), new Vector2(gamePlayer.ScreenPosition.x, gamePlayer.ScreenPosition.y), 1.5f, Color.red);
					}
				}
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000073B0 File Offset: 0x000055B0
		private void DrawSkeleton(Player player)
		{
			if (!GameUtils.IsPlayerValid(player))
			{
				return;
			}
			if (player.PlayerBones == null)
			{
				return;
			}
			int[,] array = new int[,]
			{
				{
					133,
					132
				},
				{
					132,
					37
				},
				{
					37,
					36
				},
				{
					36,
					29
				},
				{
					29,
					14
				},
				{
					37,
					90
				},
				{
					90,
					91
				},
				{
					91,
					92
				},
				{
					37,
					111
				},
				{
					111,
					112
				},
				{
					112,
					113
				},
				{
					14,
					17
				},
				{
					17,
					18
				},
				{
					14,
					22
				},
				{
					22,
					23
				}
			};
			for (int i = 0; i < array.GetLength(0); i++)
			{
				int id = array[i, 0];
				int id2 = array[i, 1];
				Vector3 bonePosByID = GameUtils.GetBonePosByID(player, id);
				Vector3 bonePosByID2 = GameUtils.GetBonePosByID(player, id2);
				if (bonePosByID != Vector3.zero && bonePosByID2 != Vector3.zero)
				{
					Vector3 vector = GameUtils.WorldPointToScreenPoint(bonePosByID);
					Vector3 vector2 = GameUtils.WorldPointToScreenPoint(bonePosByID2);
					if (GameUtils.IsScreenPointVisible(vector) && GameUtils.IsScreenPointVisible(vector2))
					{
						Render.DrawLine(vector, vector2, 1f, PlayerESP._skeletonColor);
					}
				}
			}
		}

		// Token: 0x04000052 RID: 82
		private static readonly Color _playerColor = Color.cyan;

		// Token: 0x04000053 RID: 83
		private static readonly Color _botColor = Color.yellow;

		// Token: 0x04000054 RID: 84
		private static readonly Color _healthColor = Color.green;

		// Token: 0x04000055 RID: 85
		private static readonly Color _bossColor = Color.red;

		// Token: 0x04000056 RID: 86
		private static readonly Color _cultistLeader = Color.red;

		// Token: 0x04000057 RID: 87
		private static readonly Color _cultistGuard = Color.red;

		// Token: 0x04000058 RID: 88
		private static readonly Color _guardColor = Color.red;

		// Token: 0x04000059 RID: 89
		private static readonly Color _skeletonColor = Color.cyan;

		// Token: 0x02000021 RID: 33
		public enum PlayerType
		{
			// Token: 0x040000BA RID: 186
			Scav,
			// Token: 0x040000BB RID: 187
			PlayerScav,
			// Token: 0x040000BC RID: 188
			Player,
			// Token: 0x040000BD RID: 189
			TeamMate,
			// Token: 0x040000BE RID: 190
			Follower,
			// Token: 0x040000BF RID: 191
			Boss
		}
	}
}
