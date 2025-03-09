Shader "Custom/SmokeShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Turbulence ("Turbulence", Range(0, 1)) = 0.5
        _Color ("Smoke Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Lighting Off
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;
            float _Turbulence;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 turbulenceEffect = i.uv + (_Turbulence * sin(i.uv.y * 3.1416));
                fixed4 col = tex2D(_MainTex, turbulenceEffect);
                col *= _Color;
                col.a *= 0.8; // Make it more transparent
                return col;
            }
            ENDCG
        }
    }
}
