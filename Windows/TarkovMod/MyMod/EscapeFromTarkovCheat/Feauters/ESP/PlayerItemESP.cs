using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Comfort.Common;
using EFT;
using EFT.Interactive;
using EFT.InventoryLogic;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;
using JsonType;
using UnityEngine;
using Object = UnityEngine.Object;
namespace EscapeFromTarkovCheat.Feauters.ESP
{
    public class PlayerItemESP : MonoBehaviour
    {
	    private static readonly float CacheLootItemsInterval = 30;
	    private float _nextLootContainerCacheTime;
	    
	    public void Start()
	    {
		    _containerGroups = new List<ContainerGroup>();
	    }
	    public void Update()
	    {
		    if (!Settings.DrawLootableContainers)
			    return;

		    if (Time.time >= this._nextLootContainerCacheTime && Main.GameWorld != null && Main.GameWorld.LootItems != null)
		    {
			    _containerGroups.Clear();
			    SetLootableContainers();
			    _nextLootContainerCacheTime = (Time.time + CacheLootItemsInterval);
		    }

		    foreach (ContainerGroup a in _containerGroups)
		    {
			    foreach (GameLootContainer gameLootContainer in a.Containers)
				    gameLootContainer.RecalculateDynamics();
		    }
	    }
    }
}