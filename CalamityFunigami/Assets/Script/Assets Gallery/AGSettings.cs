using UnityEngine;
using UnityEngine.UI;

public class AGSettings : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	private Toggle retroLightingToggle;

	[SerializeField]
	private Slider textureWarpingSlider;

	[SerializeField]
	private Slider vertexGridResolutionSlider;

	[SerializeField]
	private Slider lightFalloffSlider;
	#endregion

	public void ToggleVertexLighting()
	{
		var value = retroLightingToggle.isOn;

		if(value)
		{
			Shader.EnableKeyword("PSX_ENABLE_CUSTOM_VERTEX_LIGHTING");
		}
		else
		{
			Shader.DisableKeyword("PSX_ENABLE_CUSTOM_VERTEX_LIGHTING");
		}
	}

	public void UpdateTextureWarping()
	{
		var value = textureWarpingSlider.value;

		Shader.SetGlobalFloat("_PSX_TextureWarpingFactor", value);
	}

	public void UpdateVertexGridResolution()
	{
		var value = vertexGridResolutionSlider.value;

		Shader.SetGlobalFloat("_PSX_GridSize", value);
	}

	public void UpdateLightFalloff()
	{
		var value = lightFalloffSlider.value;

		Shader.SetGlobalFloat("_PSX_LightFalloffPercent", value);
	}
}
