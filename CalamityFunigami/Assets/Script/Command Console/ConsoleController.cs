using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConsoleController : MonoBehaviour
{
	public static ConsoleController Instance { get; private set; }

	private bool showConsole = false;
	private bool showHelp = false;
	private string inputCommand;
	private Vector2 scroll;
	private List<string> history = new();

	public List<ConsoleCommandBase> commandList;

	#region - Commands -
	//All of the commands which will be availble during runtime

	public static ConsoleCommand<string> HELP; //display all available commands
	public static ConsoleCommand<int> SET_INT; //This is just an example placeholder for now
	public static ConsoleCommand<bool> DRAW_RAYCASTS;
	public static ConsoleCommand<bool> LOG_ACTIONS;
	public static ConsoleCommand<bool> DRAW_HITBOXES;

	#endregion

	private void Awake()
	{
		Instance = this;

		//Create the list of commands and add them to the list
		HELP = new ConsoleCommand<string>("help", "Shows list of commands.", "help", (args) =>
		{
			history.AddRange(commandList.Select(c => $"{c.CommandFormat} - {c.CommandDescription}"));
		});

		SET_INT = new ConsoleCommand<int>("set_int", "Sets an int to the given value.", "set_int <value>", (x) =>
		{
			Debug.Log("Value has been set to " + x);
		});

		DRAW_RAYCASTS = new ConsoleCommand<bool>("draw_raycasts", "Draws each raycast used by the game", "draw_raycasts <true|false>", (x) =>
		{
			DebugController.Instance.drawRaycasts = x;
		});

		LOG_ACTIONS = new ConsoleCommand<bool>("log_actions", "Logs some actions performed during gameplay", "log_actions <true|false>", (x) =>
		{
			DebugController.Instance.logActions = x;
		});

		DRAW_HITBOXES = new ConsoleCommand<bool>("draw_hitboxes", "Draws each hitbox used by the game", "draw_hitboxes <true|false>", (drawHitboxes) =>
		{
			if(drawHitboxes)
			{
				DebugController.Instance.DrawHitboxes();
			}
			else
			{
				DebugController.Instance.HideHitboxes();
			}
		});

		commandList = new List<ConsoleCommandBase>()
		{
			HELP,
			SET_INT,
			DRAW_RAYCASTS,
			LOG_ACTIONS,
			DRAW_HITBOXES
		};
	}

	//This can be used for testing until the inputs have been added to the input system
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.BackQuote))
			OnToggleConsole();

		if(Input.GetKeyDown(KeyCode.Return))
			OnReturn();
	}

	//This method should be called from wherever input is being handled
	public static void OnToggleConsole()
	{
		Instance.OnToggleConsoleMenu();
	}

	//Toggles the console window on or off
	private void OnToggleConsoleMenu()
	{
		//Debug.Log("OnToggleConsole");
		showConsole = !showConsole;
		//showHelp = false;

		//if(showConsole)
		//{
		//	//Time.timeScale = 0;
		//	//Cursor.lockState = CursorLockMode.None;
		//	Cursor.visible = true;
		//}
		//else
		//{
		//	//Time.timeScale = 1;
		//	//Cursor.lockState = CursorLockMode.Confined;
		//	Cursor.visible = false;
		//}
	}

	//This method should be called from wherever input is being handled
	public static void OnReturn()
	{
		Instance.OnReturnInput();
	}

	//Triggers this controller to read the input string
	private void OnReturnInput()
	{
		//Debug.Log("OnReturn");
		if(showConsole)
		{
			HandleInput();
			inputCommand = "";
		}
	}

	//Read the text in the input line and if it matches a ConsoleCommand, invokes it
	private void HandleInput()
	{
		var properties = inputCommand.Split(' ');

		for(int i = 0; i < commandList.Count; i++)
		{
			if(properties[0] == commandList[i].CommandID)
			{
				commandList[i].Invoke(properties);
			}
		}
	}

	private void OnGUI()
	{
		if(!showConsole)
		{
			return;
		}

		var y = 0f;
		var viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);
		var i = 0;

		GUI.Box(new Rect(0, y, Screen.width, 100), "");
		scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

		history.ForEach(h =>
		{
			Rect labelRect = new Rect(5, 20 * i++, viewport.width - 100, 20);
			GUI.Label(labelRect, h + "\n");
		});

		GUI.EndScrollView();

		y += 100;

		//Creates a text field for inputting commands
		GUI.Box(new Rect(0, y, Screen.width, 30), "");
		GUI.backgroundColor = new Color(0, 0, 0, 0);

		inputCommand = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), inputCommand);
	}

	public void LogString(string message)
	{
		history.Add(message);
	}
}
