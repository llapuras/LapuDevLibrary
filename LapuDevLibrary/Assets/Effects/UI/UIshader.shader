Shader "Custom/UIshader" 
{
    Properties  
    {
		_MainTex("Texture", 2D) = "white" {}
		_NoiseTex("Extra Wave Noise", 2D) = "white" {}
		_Color("Color", Color) = (1, 0, 0, 0)
		_Trasparence("Trasnparence", Range(0,1)) = 0.5
		_TextureDistort("Texture Wobble", range(0,1)) = 0.2
		_Speed("Wave Speed", Range(0,1)) = 0.5
		_Height("Wave Height", Range(0,1)) = 0.5
	    _Amount("Wave Amount", Range(0,10)) = 0.5
		
		_Test01("_Test01", Range(0,10)) = 0.5
		_Test02("_Test02", Range(0,10)) = 0.5
	}
		
	SubShader 
	{
			
		//Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
			
		Pass 
		{
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex, _NoiseTex;
			float4 _Color, _MainTex_ST;
			float _Trasparence, _TextureDistort, _Speed, _Height, _Amount;
			float _Test01, _Test02;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 texcoord : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;

				float4 tex = tex2Dlod(_NoiseTex, float4(v.texcoord.xy, 0, 0));//extra noise tex				
				v.vertex.y += sin(_Time.z * _Speed + (v.vertex.x * v.vertex.z * tex * _Amount)) * _Height;

				o.pos = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = _Color * tex2D(_MainTex, i.texcoord + (_TextureDistort));
				col.a = _Trasparence;
				return col;
			}

			ENDCG
		}
	}
}
