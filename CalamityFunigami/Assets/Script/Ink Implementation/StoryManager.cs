using Ink.Runtime;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
	#region Private Variables
	private TextAsset script;
	private Story inkStory;
	private ScriptCommandsManager commandsManager;
	private ScriptDialogManager dialogManager;
	#endregion

	private void Awake()
	{
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
