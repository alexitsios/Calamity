using UnityEngine;

public class DebugController : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("Material used for Trigger Colliders")]
	private Material triggerMaterial;

	[SerializeField]
	[Tooltip("Material used for Regular Colliders")]
	private Material colliderMaterial;
	#endregion

	#region Public Variables
	public static DebugController Instance { get; private set; }

	[Header(" === Collision and HitBoxes ===")]

	[Tooltip("Draws each raycast when they are created")]
	public bool drawRaycasts;

	[Tooltip("Draws the HitBoxes of each object")]
	public bool drawHitBoxes;

	[Space]
	[Header(" === Log ===")]

	[Tooltip("Log actions performed during gameplay")]
	public bool logActions;

	#endregion

	private void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}

	public void DrawRaycast(Vector3 start, Vector3 dir, Color color, float duration)
	{
		if(drawRaycasts)
		{
			Debug.DrawRay(start, dir, color, duration);
		}
	}

	public void LogAction(string message)
	{
		if(logActions)
		{
			ConsoleController.Instance.LogString(message);
		}
	}

	/// <summary>
	///		Creates a colored, transluscent mesh representing each collider in the scene
	/// </summary>
	public void DrawHitboxes()
	{
		foreach(var obj in FindObjectsOfType<Collider>())
		{
			var script = obj.gameObject.AddComponent<HitBoxRenderer>();
			var material = obj.isTrigger ? triggerMaterial : colliderMaterial;

			script.RenderHitbox(material);
		}
	}

	/// <summary>
	///		Destroys each mesh representing the hitboxes of colliders in the scene
	/// </summary>
	public void HideHitboxes()
	{
		foreach(var obj in GameObject.FindGameObjectsWithTag("VisibleHitbox"))
		{
			Destroy(obj);
		}
	}
}
