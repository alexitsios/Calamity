using Ink.Runtime;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
	#region Public Variables
	public static StoryManager Instance { get; private set; }
	#endregion

	#region Editor Variables
	[SerializeField]
	[Obsolete("This field will be removed in the future. The script of the scene should be loaded automatically")]
	private TextAsset script;

	[SerializeField]
	[Tooltip("The Prefab of the button used to display choices during dialog")]
	private GameObject choiceButton;
	#endregion

	#region Private Variables
	private Story inkStory;
	private ScriptCommandsManager commandsManager;
	private ScriptDialogManager dialogManager;
	private List<GameObject> activeChoiceButtons = new();
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
		// TODO: improve this. The story should load only once, when the scene loads
		if(inkStory == null)
		{
			LoadInkStory();
		}

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

			if(string.IsNullOrWhiteSpace(currentLine))
			{
				continue;
			}

			if(currentLine.StartsWith(">>"))
			{
				commandsManager.RunCommand(currentLine);
			}
			else
			{
				dialogManager.DisplayDialog(currentLine, tags);
			}

		}

		if(inkStory.currentChoices.Count > 0)
		{
			for(var i = 0; i < inkStory.currentChoices.Count; i++)
			{
				var choice = inkStory.currentChoices[i];
				var parent = GameObject.FindGameObjectWithTag("ButtonParent");
				var button = Instantiate(choiceButton, parent.transform);

				button.GetComponentInChildren<TMP_Text>().text = choice.text;
				button.GetComponent<Button>().onClick.AddListener(() => SelectChoice(choice.index));
				activeChoiceButtons.Add(button);
			}
		}
	}

	/// <summary>
	///		Deletes all of the option buttons, sets the choice in the script, then continue the story
	/// </summary>
	/// <param name="index">The 0-based index of the selected choice</param>
	private void SelectChoice(int index)
	{
		foreach(var button in activeChoiceButtons)
		{
			Destroy(button);
		}

		inkStory.ChooseChoiceIndex(index);
		ProcessStory();
	}
}
