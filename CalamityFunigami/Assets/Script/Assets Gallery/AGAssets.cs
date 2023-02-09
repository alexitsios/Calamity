using UnityEngine;

public class AGAssets : MonoBehaviour
{
	#region Private Variables
	private Renderer meshRenderer;
	#endregion

	// Start is called before the first frame update
	void Start()
	{
		meshRenderer = GetComponentInChildren<Renderer>();

		var size = meshRenderer.bounds.size;
		var actualsize = new Vector3(size.x / transform.localScale.x, size.y / transform.localScale.y, size.z / transform.localScale.z);

		GetComponentInChildren<AGNotes>().SetSizeText(actualsize, transform.localScale);
	}
}
