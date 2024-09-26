using System;
using System.Collections.Generic;
using EFT.Interactive;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Feauters.ESP
{
	// Token: 0x02000009 RID: 9
	public class ExfiltrationPointsESP : MonoBehaviour
	{
		// Token: 0x06000049 RID: 73 RVA: 0x000065A4 File Offset: 0x000047A4
		public void Update()
		{
			if (!Settings.DrawExfiltrationPoints)
			{
				return;
			}
			if (Time.time >= this._nextLootItemCacheTime && Main.GameWorld != null && Main.GameWorld.ExfiltrationController.ExfiltrationPoints != null)
			{
				this._gameExfiltrationPoints.Clear();
				foreach (ExfiltrationPoint exfiltrationPoint in Main.GameWorld.ExfiltrationController.ExfiltrationPoints)
				{
					if (GameUtils.IsExfiltrationPointValid(exfiltrationPoint))
					{
						this._gameExfiltrationPoints.Add(new GameExfiltrationPoint(exfiltrationPoint));
					}
				}
				this._nextLootItemCacheTime = Time.time + ExfiltrationPointsESP.CacheExfiltrationPointInterval;
			}
			foreach (GameExfiltrationPoint gameExfiltrationPoint in this._gameExfiltrationPoints)
			{
				gameExfiltrationPoint.RecalculateDynamics();
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00006680 File Offset: 0x00004880
		private void OnGUI()
		{
			if (Settings.DrawExfiltrationPoints)
			{
				foreach (GameExfiltrationPoint gameExfiltrationPoint in this._gameExfiltrationPoints)
				{
					if (GameUtils.IsExfiltrationPointValid(gameExfiltrationPoint.ExfiltrationPoint) && gameExfiltrationPoint.IsOnScreen)
					{
						string label = gameExfiltrationPoint.ExfiltrationPoint.Settings.Name + " [" + gameExfiltrationPoint.FormattedDistance + "]";
						Render.DrawString(new Vector2(gameExfiltrationPoint.ScreenPosition.x - 50f, gameExfiltrationPoint.ScreenPosition.y), label, ExfiltrationPointsESP.ExfiltrationPointColour, true);
					}
				}
			}
		}

		// Token: 0x04000046 RID: 70
		private List<GameExfiltrationPoint> _gameExfiltrationPoints = new List<GameExfiltrationPoint>();

		// Token: 0x04000047 RID: 71
		private static readonly float CacheExfiltrationPointInterval = 5f;

		// Token: 0x04000048 RID: 72
		private float _nextLootItemCacheTime;

		// Token: 0x04000049 RID: 73
		private static readonly Color ExfiltrationPointColour = Color.green;
	}
}
