Shader "Custom/Mode7" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Angle ("Angle", Range(0.0, 360.0)) = 315.0
        _Scale ("Scale", Range(0.0, 100.0)) = 10.0
        _ScrollSpeed ("Scroll Speed", Range(0.0, 10.0)) = 0.05
    }
 
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            sampler2D _MainTex;
            float _Angle;
            float _Scale;
            float _ScrollSpeed;
 
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float2 rotated = float2(v.vertex.x, v.vertex.z) * _Scale;
                float s = sin(_Angle * 3.14159 / 180.0);
                float c = cos(_Angle * 3.14159 / 180.0);
                float2 rotated2 = float2(rotated.x * c + rotated.y * s, -rotated.x * s + rotated.y * c);
                o.uv = v.uv + rotated2 * _ScrollSpeed;
                return o;
            }
 
            fixed4 frag (v2f i) : SV_Target {
                return tex2D(_MainTex, i.uv);
            }
 
            ENDCG
        }
    }
 
    FallBack "Diffuse"
}
