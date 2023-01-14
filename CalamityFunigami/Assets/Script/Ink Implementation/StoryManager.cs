using Ink.Runtime;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
	#region Public Variables
	public static ScriptManager Instance { get; private set; }
	#endregion

	#region Private Variables
	private TextAsset script;
	private Story inkStory;
	private ScriptCommandsManager commandsManager;
	private ScriptDialogManager dialogManager;
	#endregion

	private void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(this);
		}

		Instance = this;

		commandsManager = GetComponent<ScriptCommandsManager>();
		dialogManager = GetComponent<ScriptDialogManager>();
	}

	/// <summary>
	///		Loads the script and creates a Story to control the dialog flow
	/// </summary>
	public void LoadInkStory()
	{
		inkStory = new Story(script.text);
	}

	/// <summary>
	///		Jumps to a selected knot in the script
	/// </summary>
	/// <param name="knotName">The knot's name</param>
	public void JumpToKnot(string knotName)
	{
		inkStory.ChoosePathString(knotName);
	}

	/// <summary>
	///		Processes the Story, flowing line by line, writing dialog and executing commands
	/// </summary>
	public void ProcessStory()
	{
		while(inkStory.canContinue)
		{
			var currentLine = inkStory.Continue();
			var tags = inkStory.currentTags;

			if(currentLine.StartsWith(">>"))
			{
				commandsManager.RunCommand(currentLine);
			}
			else
			{
				dialogManager.DisplayDialog(currentLine, tags);
			}
		}
	}
}
