﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulsFormats;

[AddComponentMenu("Bloodborne/Parts/Enemy")]
public class MSBBBEnemyPart : MSBBBPart
{
    public MSBBBGParamConfig GParamConfig;

    /// <summary>
    /// Unknown.
    /// </summary>
    public string CollisionName;

    /// <summary>
    /// Controls enemy AI.
    /// </summary>
    public int ThinkParamID;

    /// <summary>
    /// Controls enemy stats.
    /// </summary>
    public int NPCParamID;

    /// <summary>
    /// Controls enemy speech.
    /// </summary>
    public int TalkID;

    /// <summary>
    /// Controls enemy equipment.
    /// </summary>
    public int CharaInitID;

    /// <summary>
    /// Unknown, probably more paramIDs.
    /// </summary>
    public int UnkT07, UnkT08, UnkT09;

    /// <summary>
    /// Unknown.
    /// </summary>
    public int UnkT10;

    /// <summary>
    /// Unknown.
    /// </summary>
    public int UnkT11, UnkT12, UnkT13, UnkT14, UnkT15;

    public override void SetPart(MSBBB.Part bpart)
    {
        var part = (MSBBB.Part.Enemy)bpart;
        setBasePart(part);
        GParamConfig = gameObject.AddComponent<MSBBBGParamConfig>();
        GParamConfig.setStruct(part.Gparam);
        CollisionName = part.CollisionName;
        ThinkParamID = part.ThinkParamID;
        NPCParamID = part.NPCParamID;
        TalkID = part.TalkID;
        CharaInitID = part.CharaInitID;
        UnkT07 = part.UnkT07;
        UnkT08 = part.UnkT08;
        UnkT09 = part.UnkT09;
        UnkT10 = part.UnkT10;
        UnkT11 = part.UnkT11;
        UnkT12 = part.UnkT12;
        UnkT13 = part.UnkT13;
        UnkT14 = part.UnkT14;
        UnkT15 = part.UnkT15;
    }

    public override MSBBB.Part Serialize(GameObject parent)
    {
        var part = new MSBBB.Part.Enemy(parent.name);

        _Serialize(part, parent);
        part.Gparam = GParamConfig.Serialize();
        part.CollisionName = (CollisionName == "") ? null : CollisionName;
        part.ThinkParamID = ThinkParamID;
        part.NPCParamID = NPCParamID;
        part.TalkID = TalkID;
        part.CharaInitID = CharaInitID;
        part.UnkT07 = UnkT07;
        part.UnkT08 = UnkT08;
        part.UnkT09 = UnkT09;
        part.UnkT10 = UnkT10;
        part.UnkT11 = UnkT11;
        part.UnkT12 = UnkT12;
        part.UnkT13 = UnkT13;
        part.UnkT14 = UnkT14;
        part.UnkT15 = UnkT15;
        return part;
    }
}
