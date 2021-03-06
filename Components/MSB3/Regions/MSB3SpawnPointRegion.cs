﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulsFormats;

[AddComponentMenu("Dark Souls 3/Regions/Spawn Point")]
public class MSB3SpawnPointRegion : MSB3Region
{
    /// <summary>
    /// Unknown; seems kind of like a region index, but also kind of doesn't.
    /// </summary>
    public int UnkT00;

    public override void SetRegion(MSB3.Region bregion)
    {
        var region = (MSB3.Region.SpawnPoint)bregion;
        setBaseRegion(region);
        UnkT00 = region.UnkT00;
    }

    public override MSB3.Region Serialize(GameObject parent)
    {
        var part = new MSB3.Region.SpawnPoint(parent.name);
        _Serialize(part, parent);
        part.UnkT00 = UnkT00;
        return part;
    }
}
