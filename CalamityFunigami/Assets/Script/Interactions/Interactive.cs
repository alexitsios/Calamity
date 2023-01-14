using UnityEngine;

public class Interactive : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("Name of the knot to execute when interacting with this object")]
	private string inkKnotName;
	#endregion

	#region Private Variables
	private ScriptManager scriptManager;
	#endregion

	private void Start()
	{
		scriptManager = ScriptManager.Instance;
	}

	/// <summary>
	///		Basic implementation of the Interact method, called whenever an object is interacted with
	///		To change the functionality, create a new class inherited from Interactive and override this method
	/// </summary>
	public virtual void Interact()
	{
		scriptManager.JumpToKnot(inkKnotName);
		scriptManager.ProcessStory();
	}
}
