/*using UnityEngine;

public class Interactive : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("Name of the knot to execute when interacting with this object")]
	private string inkKnotName;
	#endregion

	//private StoryManager scriptManager;	

	private void Start()
	{
		scriptManager = StoryManager.Instance;
	}

	/// <summary>
	///		Basic implementation of the Interact method, called whenever an object is interacted with
	///		To change the functionality, create a new class inherited from Interactive and override this method
	/// </summary>
	[System.Obsolete]
	public virtual void Interact()
	{
		scriptManager.JumpToKnot(inkKnotName);
		scriptManager.ProcessStory();
	}
}
*/