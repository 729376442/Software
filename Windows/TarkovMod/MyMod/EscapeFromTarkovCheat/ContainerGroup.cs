using System;
using System.Collections.Generic;
using EscapeFromTarkovCheat.Data;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class ContainerGroup
{
    // Token: 0x17000001 RID: 1
    // (get) Token: 0x06000005 RID: 5 RVA: 0x00002194 File Offset: 0x00000394
    // (set) Token: 0x06000006 RID: 6 RVA: 0x0000219C File Offset: 0x0000039C
    public string ContainerName { get; set; }

    // Token: 0x17000002 RID: 2
    // (get) Token: 0x06000007 RID: 7 RVA: 0x000021A5 File Offset: 0x000003A5
    // (set) Token: 0x06000008 RID: 8 RVA: 0x000021AD File Offset: 0x000003AD
    public Vector3 Position { get; set; }

    // Token: 0x17000003 RID: 3
    // (get) Token: 0x06000009 RID: 9 RVA: 0x000021B6 File Offset: 0x000003B6
    // (set) Token: 0x0600000A RID: 10 RVA: 0x000021BE File Offset: 0x000003BE
    internal List<GameLootContainer> Containers { get; set; }

    // Token: 0x17000004 RID: 4
    // (get) Token: 0x0600000B RID: 11 RVA: 0x000021C7 File Offset: 0x000003C7
    // (set) Token: 0x0600000C RID: 12 RVA: 0x000021CF File Offset: 0x000003CF
    public float TotalWorth { get; set; }
    
    public List<string> NameList { get; set; }
    // Token: 0x0600000D RID: 13 RVA: 0x000021D8 File Offset: 0x000003D8
    public ContainerGroup(string name, Vector3 position)
    {
        this.ContainerName = name;
        this.Position = position;
        this.Containers = new List<GameLootContainer>();
        this.TotalWorth = 0f;
        this.NameList = new List<string> { };
    }
}
