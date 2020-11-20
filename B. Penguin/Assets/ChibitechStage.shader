﻿Shader "Custom/ChibitechStage"
{
    Properties
    {
        _MainTex1 ("ChibitechSet1", 2D) = "white" {}
        _MainTex2 ("ChibitechSet2", 2D) = "white" {}
        _MainTex3 ("ChibitechSet3", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Speed1 ("Speed1", float) = 1.0
        _Scale1 ("Scale1", float) = 1.0        
        _Speed2 ("Speed2", float) = 1.0
        _Scale2 ("Scale2", float) = 1.0        
        _Speed3 ("Speed3", float) = 1.0
        _Scale3 ("Scale3", float) = 1.0
        _Octave1 ("Octave1", Range(0,1)) = 0.0
        _Octave2 ("Octave2", Range(0,1)) = 0.0
        _Octave3 ("Octave3", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM

        float Random1D(float seed) { return frac(sin(seed) * 100000.0); }
        float Random2D(float2 seed) { return frac(sin(dot(seed, float2(12.9898, 78.233))) * 43758.5453123); }
        float Random3D(float3 seed) { return frac(sin(dot(seed, float3(12.9898, 78.233, 45.5432))) * 43758.5453); }

        float Cubic1D(float value) { return value * value * (3.0 - 2.0 * value); }
        float2 Cubic2D(float2 value) { return value * value * (3.0 - 2.0 * value); }
        float3 Cubic3D(float3 value) { return value * value * (3.0 - 2.0 * value); }

        float Noise1D(float seed)
        {
            float integer = floor(seed);
            float fraction = frac(seed);
            float noise = lerp(Random1D(integer), Random1D(integer + 1.0), Cubic1D(fraction));

            return noise;
        }

        float Noise2D(float2 seed)
        {
            float2 integer = floor(seed);
            float2 fraction = frac(seed);

            float cornerA = Random2D(integer);
            float cornerB = Random2D(integer + float2(1.0, 0.0));
            float cornerC = Random2D(integer + float2(0.0, 1.0));
            float cornerD = Random2D(integer + float2(1.0, 1.0));

            float2 interpolatedFraction = Cubic2D(fraction);

            return lerp(cornerA, cornerB, interpolatedFraction.x) +
                (cornerC - cornerA) * interpolatedFraction.y * (1.0 - interpolatedFraction.x) +
                (cornerD - cornerB) * interpolatedFraction.x * interpolatedFraction.y;
        }

        float Noise3D(float3 seed)
        {
            float3 integer = floor(seed);
            float3 fraction = frac(seed);

            float cornerA1 = Random3D(integer);
            float cornerB1 = Random3D(integer + float3(1.0, 0.0, 0.0));
            float cornerC1 = Random3D(integer + float3(0.0, 1.0, 0.0));
            float cornerD1 = Random3D(integer + float3(1.0, 1.0, 0.0));
            float cornerA2 = Random3D(integer + float3(0.0, 0.0, 1.0));
            float cornerB2 = Random3D(integer + float3(1.0, 0.0, 1.0));
            float cornerC2 = Random3D(integer + float3(0.0, 1.0, 1.0));
            float cornerD2 = Random3D(integer + float3(1.0, 1.0, 1.0));

            float3 interpolatedFraction = Cubic3D(fraction);

            float2 noiseA = lerp(cornerA1, cornerB1, interpolatedFraction.x) +
                (cornerC1 - cornerA1) * interpolatedFraction.y * (1.0 - interpolatedFraction.x) +
                (cornerD1 - cornerB1) * interpolatedFraction.x * interpolatedFraction.y;

            float2 noiseB = lerp(cornerA2, cornerB2, interpolatedFraction.x) +
                (cornerC2 - cornerA2) * interpolatedFraction.y * (1.0 - interpolatedFraction.x) +
                (cornerD2 - cornerB2) * interpolatedFraction.x * interpolatedFraction.y;

            return lerp(noiseA, noiseB, interpolatedFraction.z);
        }

        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex1;
        sampler2D _MainTex2;
        sampler2D _MainTex3;

        struct Input
        {
            float2 uv_MainTex;
            float4 color:COLOR;
            float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
        float _Speed1;
        float _Speed2;
        float _Speed3;
        float _Scale1;
        float _Scale2;
        float _Scale3;
        float _Octave1;
        float _Octave2;
        float _Octave3;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float noise1 = Noise3D(IN.worldPos * _Scale1 + _Time.y * _Speed1);
            float noise2 = Noise3D(IN.worldPos * _Scale2 + _Time.y * _Speed2);
            float noise3 = Noise3D(IN.worldPos * _Scale3 + _Time.y * _Speed3);       
            float combinednoise = noise1 * _Octave1 + noise2 * _Octave2 + noise3 * _Octave3;
            o.Albedo = tex2D(_MainTex1, float2(combinednoise, 0));
            //o.Albedo = combinednoise < 0.5 ? 0:1;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = 1;
        }
        
        ENDCG
    }
    FallBack "Diffuse"
}
