Shader "Custom/Mode7"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ScrollSpeed ("Scroll Speed", Range(0, 1)) = 0.1
        _Perspective ("Perspective", Range(0, 1)) = 0.5
        _PlaneRotation ("Plane Rotation", Range(-180, 180)) = 0
    }
 
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
 
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
            float _ScrollSpeed;
            float _Perspective;
            float _PlaneRotation;
 
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            fixed4 frag (v2f i) : SV_Target
            {
                float4 color = tex2D(_MainTex, i.uv);
                float2 scrollOffset = i.uv * _ScrollSpeed;
                float2 perspectiveOffset = i.uv * _Perspective;
                
                // Rotate UV coordinates based on plane rotation
                float angle = radians(_PlaneRotation);
                float2 rotUV = float2(cos(angle)*i.uv.x + sin(angle)*i.uv.y,
                                      -sin(angle)*i.uv.x + cos(angle)*i.uv.y);
                
                rotUV.x *= (1.0 - i.uv.y);
                rotUV += scrollOffset - perspectiveOffset;
                color = tex2D(_MainTex, rotUV);
                return color;
            }
            ENDCG
        }
    }
}
