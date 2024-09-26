using System;
using EFT;
using EFT.Interactive;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Data
{
	// Token: 0x02000016 RID: 22
	internal class GameExfiltrationPoint
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00008947 File Offset: 0x00006B47
		public ExfiltrationPoint ExfiltrationPoint { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x0000894F File Offset: 0x00006B4F
		public Vector3 ScreenPosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00008957 File Offset: 0x00006B57
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x0000895F File Offset: 0x00006B5F
		public bool IsOnScreen { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00008968 File Offset: 0x00006B68
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00008970 File Offset: 0x00006B70
		public float Distance { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00008979 File Offset: 0x00006B79
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00008981 File Offset: 0x00006B81
		public string Name { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0000898A File Offset: 0x00006B8A
		public string FormattedDistance
		{
			get
			{
				return string.Format("{0}m", Math.Round((double)this.Distance));
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000089A8 File Offset: 0x00006BA8
		public GameExfiltrationPoint(ExfiltrationPoint exfiltrationPoint)
		{
			if (exfiltrationPoint == null)
			{
				throw new ArgumentNullException("exfiltrationPoint");
			}
			this.ExfiltrationPoint = exfiltrationPoint;
			this.screenPosition = default(Vector3);
			this.Distance = 0f;
			this.Name = this.ExtractionNameToSimpleName(exfiltrationPoint.name);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00008A00 File Offset: 0x00006C00
		public void RecalculateDynamics()
		{
			if (!GameUtils.IsExfiltrationPointValid(this.ExfiltrationPoint))
			{
				return;
			}
			this.screenPosition = GameUtils.WorldPointToScreenPoint(this.ExfiltrationPoint.transform.position);
			this.IsOnScreen = GameUtils.IsScreenPointVisible(this.screenPosition);
			this.Distance = Vector3.Distance(Main.MainCamera.transform.position, this.ExfiltrationPoint.transform.position);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00008A74 File Offset: 0x00006C74
		public bool IsEnabled()
		{
			string[] eligibleEntryPoints = this.ExfiltrationPoint.EligibleEntryPoints;
			for (int i = 0; i < eligibleEntryPoints.Length; i++)
			{
				string a = eligibleEntryPoints[i].ToLower();
				Player localPlayer = Main.LocalPlayer;
				string b;
				if (localPlayer == null)
				{
					b = null;
				}
				else
				{
					Profile profile = localPlayer.Profile;
					if (profile == null)
					{
						b = null;
					}
					else
					{
						\uE7E1 info = profile.Info;
						if (info == null)
						{
							b = null;
						}
						else
						{
							string entryPoint = info.EntryPoint;
							b = ((entryPoint != null) ? entryPoint.ToLower() : null);
						}
					}
				}
				if (a == b && (this.ExfiltrationPoint.Status == 3 || this.ExfiltrationPoint.Status == 4))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00008B00 File Offset: 0x00006D00
		private string ExtractionNameToSimpleName(string extractionName)
		{
			if (extractionName.Contains("exit (3)"))
			{
				return "Cellars";
			}
			if (extractionName.Contains("exit (1)"))
			{
				return "Gate 3";
			}
			if (extractionName.Contains("exit (2)"))
			{
				return "Gate 0";
			}
			if (extractionName.Contains("exit_scav_gate3"))
			{
				return "Gate 3";
			}
			if (extractionName.Contains("exit_scav_camer"))
			{
				return "Blinking Light";
			}
			if (extractionName.Contains("exit_scav_office"))
			{
				return "Office";
			}
			if (extractionName.Contains("eastg"))
			{
				return "East Gate";
			}
			if (extractionName.Contains("scavh"))
			{
				return "House";
			}
			if (extractionName.Contains("deads"))
			{
				return "Dead Mans Place";
			}
			if (extractionName.Contains("var1_1_constant"))
			{
				return "Outskirts";
			}
			if (extractionName.Contains("scav_outskirts"))
			{
				return "Outskirts";
			}
			if (extractionName.Contains("water"))
			{
				return "Outskirts Water";
			}
			if (extractionName.Contains("boat"))
			{
				return "The Boat";
			}
			if (extractionName.Contains("mountain"))
			{
				return "Mountain Stash";
			}
			if (extractionName.Contains("oldstation"))
			{
				return "Old Station";
			}
			if (extractionName.Contains("UNroad"))
			{
				return "UN Road Block";
			}
			if (extractionName.Contains("var2_1_const"))
			{
				return "UN Road Block";
			}
			if (extractionName.Contains("gatetofactory"))
			{
				return "Gate to Factory";
			}
			if (extractionName.Contains("RUAF"))
			{
				return "RUAF Gate";
			}
			if (extractionName.Contains("roadtoc"))
			{
				return "Road to Customs";
			}
			if (extractionName.Contains("lighthouse"))
			{
				return "Lighthouse";
			}
			if (extractionName.Contains("tunnel"))
			{
				return "Tunnel";
			}
			if (extractionName.Contains("wreckedr"))
			{
				return "Wrecked Road";
			}
			if (extractionName.Contains("deadend"))
			{
				return "Dead End";
			}
			if (extractionName.Contains("housefence"))
			{
				return "Ruined House Fence";
			}
			if (extractionName.Contains("gyment"))
			{
				return "Gym Entrance";
			}
			if (extractionName.Contains("southfence"))
			{
				return "South Fence Passage";
			}
			if (extractionName.Contains("adm_base"))
			{
				return "Admin Basement";
			}
			if (extractionName.Contains("administrationg"))
			{
				return "Administration Gate";
			}
			if (extractionName.Contains("factoryfar"))
			{
				return "Factory Far Corner";
			}
			if (extractionName.Contains("oldazs"))
			{
				return "Old Gate";
			}
			if (extractionName.Contains("milkp_sh"))
			{
				return "Shack";
			}
			if (extractionName.Contains("beyondfuel"))
			{
				return "Beyond Fuel Tank";
			}
			if (extractionName.Contains("railroadtom"))
			{
				return "Railroad to Mil Base";
			}
			if (extractionName.Contains("_pay_car"))
			{
				return "V-Exit";
			}
			if (extractionName.Contains("oldroadgate"))
			{
				return "Old Road Gate";
			}
			if (extractionName.Contains("sniperroad"))
			{
				return "Sniper Road Block";
			}
			if (extractionName.Contains("warehouse17"))
			{
				return "Warehouse 17";
			}
			if (extractionName.Contains("factoryshacks"))
			{
				return "Factory Shacks";
			}
			if (extractionName.Contains("railroadtotarkov"))
			{
				return "Railroad to Tarkov";
			}
			if (extractionName.Contains("trailerpark"))
			{
				return "Trailer Park";
			}
			if (extractionName.Contains("crossroads"))
			{
				return "Crossroads";
			}
			if (extractionName.Contains("railroadtoport"))
			{
				return "Railroad to Port";
			}
			if (extractionName.Contains("NW_Exfil"))
			{
				return "North West Extract";
			}
			if (extractionName.Contains("SE_Exfil"))
			{
				return "Emmercom";
			}
			return extractionName;
		}

		// Token: 0x04000093 RID: 147
		private Vector3 screenPosition;
	}
}
