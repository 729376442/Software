using System;
using EFT;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Data
{
	// Token: 0x02000019 RID: 25
	public class GamePlayer
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x0000905D File Offset: 0x0000725D
		public Player Player { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00009065 File Offset: 0x00007265
		public Vector3 ScreenPosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000906D File Offset: 0x0000726D
		public Vector3 HeadScreenPosition
		{
			get
			{
				return this.headScreenPosition;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00009075 File Offset: 0x00007275
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x0000907D File Offset: 0x0000727D
		public bool IsOnScreen { get; private set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00009086 File Offset: 0x00007286
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x0000908E File Offset: 0x0000728E
		public bool IsVisible { get; private set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00009097 File Offset: 0x00007297
		// (set) Token: 0x060000CB RID: 203 RVA: 0x0000909F File Offset: 0x0000729F
		public float Distance { get; private set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000CC RID: 204 RVA: 0x000090A8 File Offset: 0x000072A8
		// (set) Token: 0x060000CD RID: 205 RVA: 0x000090B0 File Offset: 0x000072B0
		public bool IsAI { get; private set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000CE RID: 206 RVA: 0x000090B9 File Offset: 0x000072B9
		public string FormattedDistance
		{
			get
			{
				return string.Format("{0}m", (int)Math.Round((double)this.Distance));
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000090D8 File Offset: 0x000072D8
		public GamePlayer(Player player)
		{
			if (player == null)
			{
				throw new ArgumentNullException("player");
			}
			this.Player = player;
			this.screenPosition = default(Vector3);
			this.headScreenPosition = default(Vector3);
			this.IsOnScreen = false;
			this.Distance = 0f;
			this.IsAI = true;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00009138 File Offset: 0x00007338
		public void RecalculateDynamics()
		{
			if (!GameUtils.IsPlayerValid(this.Player))
			{
				return;
			}
			this.screenPosition = GameUtils.WorldPointToScreenPoint(this.Player.Transform.position);
			if (this.Player.PlayerBones != null)
			{
				this.headScreenPosition = GameUtils.WorldPointToScreenPoint(this.Player.PlayerBones.Head.position);
			}
			this.IsOnScreen = GameUtils.IsScreenPointVisible(this.screenPosition);
			this.Distance = Vector3.Distance(Main.MainCamera.transform.position, this.Player.Transform.position);
			if (this.Player.Profile != null && this.Player.Profile.Info != null)
			{
				this.IsAI = (this.Player.Profile.Info.RegistrationDate <= 0);
			}
		}

		// Token: 0x040000A1 RID: 161
		private Vector3 screenPosition;

		// Token: 0x040000A2 RID: 162
		private Vector3 headScreenPosition;
	}
}
