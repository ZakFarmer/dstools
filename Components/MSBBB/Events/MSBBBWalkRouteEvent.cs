﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulsFormats;

[AddComponentMenu("Bloodborne/Events/Walk Route")]
public class MSBBBWalkRouteEvent : MSBBBEvent
{
    /// <summary>
    /// Unknown; probably some kind of route type.
    /// </summary>
    public int UnkT00;

    /// <summary>
    /// List of points in the route.
    /// </summary>
    public string[] WalkPointNames;

    public override void SetEvent(MSBBB.Event bevt)
    {
        setBaseEvent(bevt);
        var evt = (MSBBB.Event.WalkRoute)bevt;
        UnkT00 = evt.UnkT00;
        WalkPointNames = evt.WalkPointNames;
    }

    public override MSBBB.Event Serialize(GameObject parent)
    {
        var evt = new MSBBB.Event.WalkRoute(parent.name);
        _Serialize(evt, parent);
        evt.UnkT00 = UnkT00;
        for (int i = 0; i < 32; i++)
        {
            if (i >= WalkPointNames.Length)
                break;
            evt.WalkPointNames[i] = (WalkPointNames[i] == "") ? null : WalkPointNames[i];
        }
        return evt;
    }
}
