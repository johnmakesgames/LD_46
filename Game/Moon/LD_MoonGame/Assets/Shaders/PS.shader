Shader "Hidden/PS"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_PixelateAmount("Pixelate Amount", Range(0, 1024)) = 10
		_ColourDepth("Colour Depth", Range(0, 1024)) = 100
		_Blueness("Overlay Colour", Color) = (0.17,0.19,0.47,0)
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

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			float _PixelateAmount;
			float _ColourDepth;
			sampler2D _OverlayImage;

			fixed4 frag(v2f i) : SV_Target
			{
				float2 uv = i.uv;
				uv.x *= _PixelateAmount;
				uv.x = round(uv.x);
				uv.x /= _PixelateAmount;
				uv.y *= _PixelateAmount;
				uv.y = round(uv.y);
				uv.y /= _PixelateAmount;
				fixed4 col = tex2D(_MainTex, uv);
				col *= _ColourDepth;
				col = round(col);
				col /= _ColourDepth;
				return col;
			}
			ENDCG
		}
	}
}
