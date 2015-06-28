Shader "Custom/Shader_Blend" 
{
	Properties 
	{
		_Blend ("Blend", Range(0,1)) = 0.5
		_MainTex ("Main Texture", 2D) = ""
		_DetectTex ("Detect Texture", 2D) = ""
	}

	SubShader 
	{
		Pass
		{
			SetTexture[_MainTex]
			SetTexture[_DetectTex]
			{
				ConstantColor(0, 0, 0, [_Blend])
				Combine texture Lerp(constant) previous
			}
		}
	}
}
