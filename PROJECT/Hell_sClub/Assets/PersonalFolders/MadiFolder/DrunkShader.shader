Shader "Custom/DrunkCameraShader"
{
    Properties
    {
        // Remove _MainTex property if no texture is needed
        // _MainTex ("Base Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue" = "Overlay" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0

            // Include unity shader libraries
            #include "UnityCG.cginc"

            // No need for a texture if you don't want one
            // sampler2D _MainTex;

            // Vertex shader
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // Fragment (pixel) shader
            float4 frag(v2f i) : SV_Target
            {
                // Get the original UV coordinates
                float2 uv = i.uv;

                // Apply some random shake based on sine and cosine functions
                uv.x += cos(uv.y * 2.0 + _Time.y) * 0.05;
                uv.y += sin(uv.x * 2.0 + _Time.y) * 0.05;

                // Add some sinusoidal offset for additional shake effect
                float offset = sin(_Time.y * 0.5) * 0.01;

                // Generate a simple color pattern for the drunk effect
                float4 color = float4(1.0, 0.5 + sin(_Time.y) * 0.5, 0.5 + cos(_Time.y) * 0.5, 1.0);

                // Return the color with shake effect (no texture sampling)
                return color;
            }
            ENDCG
        }
    }
}