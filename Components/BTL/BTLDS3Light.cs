﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SoulsFormats;

class BTLDS3Light : MonoBehaviour
{
    /// <summary>
    /// Unknown.
    /// </summary>
    public int Unk00;

    /// <summary>
    /// Unknown.
    /// </summary>
    public int Unk04;

    /// <summary>
    /// Unknown.
    /// </summary>
    public int Unk08;

    /// <summary>
    /// Unknown.
    /// </summary>
    public int Unk0C;

    /// <summary>
    /// Unknown.
    /// </summary>
    public BTL.LightType LightType;

    /// <summary>
    /// Unknown.
    /// </summary>
    public bool Unk1C;

    /// <summary>
    /// Color of the light on diffuse surfaces.
    /// </summary>
    public Color DiffuseColor;

    /// <summary>
    /// Intensity of diffuse lighting.
    /// </summary>
    public float DiffusePower;

    /// <summary>
    /// Color of the light on reflective surfaces.
    /// </summary>
    public Color SpecularColor;

    /// <summary>
    /// Unknown.
    /// </summary>
    public bool CastsShadows;

    /// <summary>
    /// Intensity of specular lighting.
    /// </summary>
    public float SpecularPower;

    /// <summary>
    /// Tightness of the spot light beam.
    /// </summary>
    public float ConeAngle;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float Unk30;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float Unk34;

    /// <summary>
    /// Rotation of a spot light.
    /// </summary>
    public Vector3 Rotation;

    /// <summary>
    /// Unknown.
    /// </summary>
    public int Unk50;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float Unk54;

    /// <summary>
    /// Distance the light shines.
    /// </summary>
    public float Radius;

    /// <summary>
    /// Unknown.
    /// </summary>
    public int Unk5C;

    /// <summary>
    /// Unknown.
    /// </summary>
    public byte[] Unk64;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float Unk68;

    /// <summary>
    /// Unknown.
    /// </summary>
    public Color ShadowColor;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float Unk70;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float FlickerIntervalMin;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float FlickerIntervalMax;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float FlickerBrightnessMult;

    /// <summary>
    /// Unknown.
    /// </summary>
    public int Unk80;

    /// <summary>
    /// Unknown; 4 bytes.
    /// </summary>
    public byte[] Unk84;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float Unk88;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float Unk90;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float ConeAngleWidthDS2;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float NearPlane;

    /// <summary>
    /// Unknown.
    /// </summary>
    public byte[] UnkA0;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float Sharpness;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float UnkAC;

    /// <summary>
    /// Stretches the spot light beam.
    /// </summary>
    public float Width;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float UnkBC;

    /// <summary>
    /// Unknown.
    /// </summary>
    public byte[] UnkC0;

    /// <summary>
    /// Unknown.
    /// </summary>
    public float UnkC4;

    // Live connection to DS2
    private DS2GXLightBase ConnectedLightDS2 = null;
    private DS3GXLightBase ConnectedLightDS3 = null;

    public virtual void SetFromLight(BTL.Light l)
    {
        Unk00 = l.Unk00;
        Unk04 = l.Unk04;
        Unk08 = l.Unk08;
        Unk0C = l.Unk0C;
        LightType = l.Type;
        Unk1C = l.Unk1C;
        DiffuseColor = new Color((float)l.DiffuseColor.R / 255.0f, (float)l.DiffuseColor.G / 255.0f, (float)l.DiffuseColor.B / 255.0f, (float)l.DiffuseColor.A / 255.0f);
        DiffusePower = l.DiffusePower;
        SpecularColor = new Color((float)l.SpecularColor.R / 255.0f, (float)l.SpecularColor.G / 255.0f, (float)l.SpecularColor.B / 255.0f, (float)l.SpecularColor.A / 255.0f);
        SpecularPower = l.SpecularPower;
        ConeAngle = l.ConeAngle;
        CastsShadows = l.CastShadows;
        Unk30 = l.Unk30;
        Unk34 = l.Unk34;
        Rotation = new Vector3(l.Rotation.X * Mathf.Rad2Deg, l.Rotation.Y * Mathf.Rad2Deg, l.Rotation.Z * Mathf.Rad2Deg);
        Unk50 = l.Unk50;
        Unk54 = l.Unk54;
        Radius = l.Radius;
        Unk5C = l.Unk5C;
        Unk64 = l.Unk64;
        Unk68 = l.Unk68;
        ShadowColor = new Color((float)l.ShadowColor.R / 255.0f, (float)l.ShadowColor.G / 255.0f, (float)l.ShadowColor.B / 255.0f, (float)l.ShadowColor.A / 255.0f);
        Unk70 = l.Unk70;
        FlickerIntervalMin = l.FlickerIntervalMin;
        FlickerIntervalMax = l.FlickerIntervalMax;
        FlickerBrightnessMult = l.FlickerBrightnessMult;
        Unk80 = l.Unk80;
        Unk84 = l.Unk84;
        Unk88 = l.Unk88;
        Unk90 = l.Unk90;
        ConeAngleWidthDS2 = l.Unk98;
        NearPlane = l.Unk9C;
        UnkA0 = l.UnkA0;
        Sharpness = l.Sharpness;
        UnkAC = l.UnkAC;
        Width = l.Width;
        UnkBC = l.UnkBC;
        UnkC0 = l.UnkC0;
        UnkC4 = l.UnkC4;
    }

    static System.Numerics.Vector3 ConvertEuler(UnityEngine.Vector3 r)
    {
        // ZXY Euler to rot matrix

        var x = (r.x > 180.0f ? r.x - 360.0f : r.x) * Mathf.Deg2Rad;
        var y = (r.y > 180.0f ? r.y - 360.0f : r.y) * Mathf.Deg2Rad;
        var z = (r.z > 180.0f ? r.z - 360.0f : r.z) * Mathf.Deg2Rad;

        System.Numerics.Matrix4x4 mat2 = System.Numerics.Matrix4x4.CreateRotationZ(z)
            * System.Numerics.Matrix4x4.CreateRotationX(x) * System.Numerics.Matrix4x4.CreateRotationY(y);

        // XYZ
        if (Mathf.Abs(mat2.M13) < 0.99999f)
        {
            //z = (float)((r.z >= 90.0f && r.z < 270.0f) ? Math.PI + Math.Asin(Math.Max(Math.Min((double)mat2.M21, 1.0), -1.0)) : -Math.Asin(Math.Max(Math.Min((double)mat2.M21, 1.0), -1.0)));
            //x = (float)Math.Atan2(mat2.M23 / Math.Cos(z), mat2.M22 / Math.Cos(z));
            //y = (float)Math.Atan2(mat2.M31 / Math.Cos(z), mat2.M11 / Math.Cos(z));
            y = (float)((r.y >= 90.0f && r.y < 270.0f) ? Math.PI + Math.Asin(Math.Max(Math.Min((double)mat2.M31, 1.0), -1.0)) : -Math.Asin(Math.Max(Math.Min((double)mat2.M31, 1.0), -1.0)));
            x = (float)Math.Atan2(mat2.M23 / Math.Cos(y), mat2.M33 / Math.Cos(y));
            z = (float)Math.Atan2(mat2.M12 / Math.Cos(y), mat2.M11 / Math.Cos(y));
        }
        else
        {
            if (mat2.M13 > 0)
            {
                y = -Mathf.PI / 2.0f;
                x = (float)Math.Atan2(-mat2.M21, -mat2.M31);
                z = 0.0f;
            }
            else
            {
                y = Mathf.PI / 2.0f;
                x = (float)Math.Atan2(mat2.M21, mat2.M31);
                z = 0.0f;
            }
        }

        return new System.Numerics.Vector3(x, y, z);
    }

    public virtual BTL.Light Serialize(GameObject parent, BTL.Light light = null)
    {
        BTL.Light l = light;
        if (light == null)
        {
            l = new BTL.Light();
        }
        l.Name = parent.name;
        l.Position = new System.Numerics.Vector3(parent.transform.localPosition.x, parent.transform.localPosition.y, parent.transform.localPosition.z);
        l.Unk00 = Unk00;
        l.Unk04 = Unk04;
        l.Unk08 = Unk08;
        l.Unk0C = Unk0C;
        l.Type = LightType;
        l.Unk1C = Unk1C;
        l.DiffuseColor = System.Drawing.Color.FromArgb((byte)(DiffuseColor.a * 255.0f), (byte)(DiffuseColor.r * 255.0f), (byte)(DiffuseColor.g * 255.0f), (byte)(DiffuseColor.b * 255.0f));
        l.DiffusePower = DiffusePower;
        l.SpecularColor = System.Drawing.Color.FromArgb((byte)(SpecularColor.a * 255.0f), (byte)(SpecularColor.r * 255.0f), (byte)(SpecularColor.g * 255.0f), (byte)(SpecularColor.b * 255.0f));
        l.SpecularPower = SpecularPower;
        l.ConeAngle = ConeAngle;
        l.CastShadows = CastsShadows;
        l.Unk30 = Unk30;
        l.Unk34 = Unk34;
        //l.Rotation = new System.Numerics.Vector3(Rotation.x * Mathf.Deg2Rad, Rotation.y * Mathf.Deg2Rad, Rotation.z * Mathf.Deg2Rad);
        //l.Rotation = ConvertEuler(parent.transform.localEulerAngles);
        l.Rotation = new System.Numerics.Vector3(parent.transform.eulerAngles.x * Mathf.Deg2Rad, parent.transform.eulerAngles.y * Mathf.Deg2Rad, parent.transform.eulerAngles.z * Mathf.Deg2Rad);
        print($@"{l.Name}: {Rotation}, {parent.transform.eulerAngles} -> {l.Rotation * Mathf.Rad2Deg}");
        l.Unk50 = Unk50;
        l.Unk54 = Unk54;
        l.Radius = Radius;
        l.Unk5C = Unk5C;
        l.Unk64 = Unk64;
        l.Unk68 = Unk68;
        l.ShadowColor = System.Drawing.Color.FromArgb((byte)(ShadowColor.a * 255.0f), (byte)(ShadowColor.r * 255.0f), (byte)(ShadowColor.g * 255.0f), (byte)(ShadowColor.b * 255.0f));
        l.Unk70 = Unk70;
        l.FlickerIntervalMin = FlickerIntervalMin;
        l.FlickerIntervalMax = FlickerIntervalMax;
        l.FlickerBrightnessMult = FlickerBrightnessMult;
        l.Unk98 = ConeAngleWidthDS2;
        l.Unk9C = NearPlane;
        l.UnkA0 = UnkA0;
        l.Sharpness = Sharpness;
        l.UnkAC = UnkAC;
        l.Width = Width;
        l.UnkBC = UnkBC;
        l.UnkC0 = UnkC0;
        l.UnkC4 = UnkC4;
        return l;
    }

    public void SetConnectedLight(DS2GXLightBase light)
    {
        ConnectedLightDS2 = light;
    }

    public void SetConnectedLight(DS3GXLightBase light)
    {
        ConnectedLightDS3 = light;
    }

    public void OnDrawGizmosSelected()
    {
        if (ConnectedLightDS2 != null && ConnectedLightDS2.IsValid())
        {
            if (ConnectedLightDS2 is DS2GXSpotLight)
            {
                ((DS2GXSpotLight)ConnectedLightDS2).Transform = gameObject.transform.localToWorldMatrix;
                float angle2 = (ConeAngleWidthDS2 == 0.0f) ? ConeAngle : ConeAngleWidthDS2;
                Matrix4x4 projection = Matrix4x4.zero;
                float S1 = 1.0f / Mathf.Tan((ConeAngle / 2.0f) * Mathf.Deg2Rad);
                float S2 = 1.0f / Mathf.Tan((angle2 / 2.0f) * Mathf.Deg2Rad);
                projection.m00 = S2;
                projection.m11 = S1;
                projection.m22 = Radius / (Radius - NearPlane);
                projection.m23 = -Radius * NearPlane / (Radius - NearPlane);
                projection.m32 = 1.0f;
                ((DS2GXSpotLight)ConnectedLightDS2).Projection = projection;
                ((DS2GXSpotLight)ConnectedLightDS2).NearClip = NearPlane;
                ((DS2GXSpotLight)ConnectedLightDS2).FieldOfView = ConeAngle * Mathf.Deg2Rad;
                ((DS2GXSpotLight)ConnectedLightDS2).FieldOfViewWidth = angle2 * Mathf.Deg2Rad;
                ((DS2GXSpotLight)ConnectedLightDS2).FieldOfViewRatio = Mathf.Tan(angle2 * Mathf.Deg2Rad * 0.5f) / Mathf.Tan(ConeAngle * Mathf.Deg2Rad *0.5f);
            }
            else
            {
                ConnectedLightDS2.Position = gameObject.transform.position;
            }
            ConnectedLightDS2.Diffuse = DiffuseColor;
            ConnectedLightDS2.DiffusePower = DiffusePower;
            ConnectedLightDS2.Specular = new Color(DiffuseColor.r * SpecularColor.r,
                                                DiffuseColor.g * SpecularColor.g,
                                                DiffuseColor.b * SpecularColor.b);
            ConnectedLightDS2.SpecularPower = SpecularPower;
            ConnectedLightDS2.Radius = Radius;
            ConnectedLightDS2.EnableShadows = CastsShadows;
            ConnectedLightDS2.FlickerMin = FlickerIntervalMin;
            ConnectedLightDS2.FlickerMax = FlickerIntervalMax;
            ConnectedLightDS2.FlickerMult = FlickerBrightnessMult;
        }
        else
        {
            ConnectedLightDS2 = null;
        }

        if (ConnectedLightDS3 != null && ConnectedLightDS3.IsValid())
        {
            if (ConnectedLightDS3 is DS3GXSpotLight)
            {
                ((DS3GXSpotLight)ConnectedLightDS3).Transform = gameObject.transform.localToWorldMatrix;
            }
            else
            {
                ConnectedLightDS3.Position = gameObject.transform.position;
            }
            ConnectedLightDS3.Diffuse = DiffuseColor;
            ConnectedLightDS3.DiffusePower = DiffusePower;
            ConnectedLightDS3.Specular = new Color(DiffuseColor.r * SpecularColor.r,
                                                DiffuseColor.g * SpecularColor.g,
                                                DiffuseColor.b * SpecularColor.b);
            ConnectedLightDS3.SpecularPower = SpecularPower;
            ConnectedLightDS3.Radius = Radius;
            ConnectedLightDS3.EnableShadows = CastsShadows;
            ConnectedLightDS3.FlickerMin = FlickerIntervalMin;
            ConnectedLightDS3.FlickerMax = FlickerIntervalMax;
            ConnectedLightDS3.FlickerMult = FlickerBrightnessMult;
        }
        else
        {
            ConnectedLightDS3 = null;
        }
    }
}
