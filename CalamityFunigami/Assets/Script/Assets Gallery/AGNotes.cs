using TMPro;
using UnityEngine;

public class AGNotes : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	private string customNotes;
	#endregion

	private void Start()
	{
		var text = GetComponent<TMP_Text>();

		text.alignment = TextAlignmentOptions.BottomLeft;
		text.fontSize = 20;
	}

	void Update()
	{
		transform.LookAt(Camera.main.transform, -Vector3.up);
	}

	public void SetSizeText(Vector3 size, Vector3 scale)
	{
		var sizeText = $"Original Size:\n  - {size.x} m (X)\n  - {size.y} m (Y)\n  - {size.z} m (Z)";
		var scaleText = $"Current Scale:\n  - {scale.x} (X)\n  - {scale.y} (Y)\n  - {scale.z} (Z)";

		GetComponent<TMP_Text>().text = $"{sizeText}\n\n{scaleText}";
	}

	private void LateUpdate()
	{
		transform.forward = new Vector3(Camera.main.transform.forward.x, transform.forward.y, Camera.main.transform.forward.z);
	}
}
