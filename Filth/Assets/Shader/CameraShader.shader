Shader "Hidden/CameraShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Factor ("Factor", Range(0, 1)) = 1
		_TimeShift ("Time Shift", Range(0, 6.3)) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			uniform float _Factor;
			uniform float _TimeShift;

			fixed4 frag (v2f_img i) : SV_Target
			{
				float shift = 0.01 * sin(20.0 * i.uv.y + _TimeShift) * (1.0 - _Factor);
				fixed4 col = tex2D(_MainTex, i.uv + float2(shift, 0));
				return (0.25 + 0.75 * _Factor) * col;
			}
			ENDCG
		}
	}
}
