using System;
using System.Collections.Generic;
using EFT;
using EFT.UI;
using EscapeFromTarkovCheat;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

// Token: 0x02000002 RID: 2
internal class locationsfixer : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		if (!this.streetsPatched)
		{
			if (Main.GameWorld != null)
			{
				return;
			}
			this.FixLocation();
			ConsoleScreen.Log("Fixing streets...");
		}
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002078 File Offset: 0x00000278
	private void Update()
	{
		if (!Settings.StreetsFixEnabled)
		{
			this.streetsPatched = false;
		}
		if (Settings.StreetsFixEnabled)
		{
			if (Main.GameWorld != null)
			{
				this.streetsPatched = false;
			}
			if (!this.streetsPatched)
			{
				if (Main.GameWorld != null)
				{
					return;
				}
				this.FixLocation();
				ConsoleScreen.Log("Fixing streets...");
			}
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020D4 File Offset: 0x000002D4
	public void FixLocation()
	{
		this._tarkovApplication = Object.FindObjectOfType<TarkovApplication>();
		Dictionary<string, \uE5CA.Location> locations = this._tarkovApplication.GetClientBackEndSession().LocationSettings.locations;
		if (locations == null)
		{
			return;
		}
		foreach (\uE5CA.Location location in locations.Values)
		{
			ConsoleScreen.Log(location.Name);
			if (location.Name.Contains("Streets"))
			{
				location.ForceOnlineRaidInPVE = false;
				location.MaxBotPerZone = 0;
				location.EscapeTimeLimit = 100000000;
				ConsoleScreen.Log("Streets fixed");
				this.streetsPatched = true;
			}
		}
	}

	// Token: 0x04000001 RID: 1
	private TarkovApplication _tarkovApplication;

	// Token: 0x04000002 RID: 2
	private bool streetsPatched;
}
