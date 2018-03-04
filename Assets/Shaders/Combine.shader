Shader "TeamBridge-Game/Combine"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Original ("Original", 2D) = "white" {}
		_BloomIntensity ("Bloom Intensity", Range(0, 10)) = 0.8
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
			sampler2D _Original;
			float _BloomIntensity;

			fixed3 addBlend(fixed3 blend, fixed3 base)
			{
				return min(blend + base, fixed3(1., 1., 1.));
			}

			float blendColorBurn(float base, float blend) {
				return (blend == 0.0) ? blend : max((1.0 - ((1.0 - base) / blend)), 0.0);
			}

			float3 burnBlend(float3 blend, float3 base)
			{
				return float3(blendColorBurn(blend.r, base.r), blendColorBurn(blend.g, base.g), blendColorBurn(blend.b, base.b));
			}

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 base = tex2D(_Original, i.uv);
				fixed4 blend = tex2D(_MainTex, i.uv);
				// just invert the colors
				
				return base + blend*_BloomIntensity;
			}
			ENDCG
		}
	}
}
