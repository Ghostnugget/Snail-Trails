Shader "Sprites/EditorStyleOutlineThick"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineThickness ("Outline Thickness", Range(1, 20)) = 4
    }

    SubShader
    {
        Tags
        { 
            "Queue"="Transparent" 
            "RenderType"="Transparent" 
            "DisableBatching" = "True"
        }

        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            fixed4 _Color;

            fixed4 _OutlineColor;
            float _OutlineThickness;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color * _Color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 originalColor = tex2D(_MainTex, i.uv);
                
                if (originalColor.a > 0.1) 
                {
                    return originalColor * i.color;
                }

                float2 texel = _MainTex_TexelSize.xy;
                float threshold = 0.1;
                bool isOutline = false;
                int searchRadius = (int)ceil(_OutlineThickness);

                // Pass 1: Check horizontally for any opaque pixels within the thickness range
                for (int x = -searchRadius; x <= searchRadius; x++)
                {
                    float2 sampleCoord = i.uv + float2(x * texel.x, 0);
                    float4 lodCoord = float4(sampleCoord, 0, 0);
                    if (tex2Dlod(_MainTex, lodCoord).a > threshold)
                    {
                        isOutline = true;
                        break;
                    }
                }

                // Pass 2: Check vertically if not already found
                if (!isOutline)
                {
                    for (int y = -searchRadius; y <= searchRadius; y++)
                    {
                        float2 sampleCoord = i.uv + float2(0, y * texel.y);
                        float4 lodCoord = float4(sampleCoord, 0, 0);
                        if (tex2Dlod(_MainTex, lodCoord).a > threshold)
                        {
                            isOutline = true;
                            break;
                        }
                    }
                }

                if (isOutline)
                {
                    return fixed4(_OutlineColor.rgb, _OutlineColor.a);
                }

                return fixed4(0,0,0,0);
            }
            ENDCG
        }
    }
}