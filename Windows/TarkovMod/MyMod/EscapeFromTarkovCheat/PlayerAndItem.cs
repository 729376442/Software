using System;
using System.Collections.Generic;
using EFT;
using EscapeFromTarkovCheat.Data;
using UnityEngine;
namespace EscapeFromTarkovCheat
{
    public class PlayerAndItem
    {
        public List<string> NameList { get; set; }
        public GamePlayer PlayerRef { get; set; }
        public PlayerAndItem(GamePlayer player, List<string> nameList)
        {
            this.PlayerRef = player;
            this.NameList = nameList;
        }
    }
}