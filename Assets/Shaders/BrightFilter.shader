Shader "TeamBridge-Game/BrightFilter"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			// RGB <-> HSV tutorial https://www.laurivan.com/rgb-to-hsv-to-rgb-for-shaders/
			// http://acegikmo.com/shaderforge/wiki/index.php?title=RGB_to_HSV_to_RGB_Color_Space_conversion
			float3 RGB2HSV(float3 RGB)
			{
				float4 k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
				float4 p = RGB.g < RGB.b ? float4(RGB.b, RGB.g, k.w, k.z) : float4(RGB.gb, k.xy);
				float4 q = RGB.r < p.x ? float4(p.x, p.y, p.w, RGB.r) : float4(RGB.r, p.yzx);
				float d = q.x - min(q.w, q.y);
				float e = 1.0e-10;
				return float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
			}

			float3 HSV2RGB(float3 HSV)
			{
				float4 k = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
				float3 p = abs(frac(HSV.xxx + k.xyz) * 6.0 - k.www);
				return HSV.z * lerp(k.xxx, clamp(p - k.xxx, 0.0, 1.0), HSV.y);
			}

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				float bright = (col.r*0.2126) + (col.g*0.7152) + (col.b*0.0722);
				
				// Outs color only if bright is greater or equal to 0.9
				col = (bright < 0.7) ? half4(0, 0, 0, 1) : col;

				// just invert the colors
				
				return col;
			}
			
			
			ENDCG
		}
	}
}
