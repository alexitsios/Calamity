using System.Collections.Generic;
using UnityEngine;

public class ConsoleController : MonoBehaviour
{
    private static ConsoleController instance;

    private bool showConsole = false;
    private bool showHelp = false;

    private string inputCommand;
    private Vector2 scroll;

    public List<object> commandList;

    #region - Commands -
    //All of the commands which will be availble during runtime

    public static ConsoleCommand HELP; //display all available commands

    public static ConsoleCommand<int> SET_INT; //This is just an example placeholder for now

    #endregion

    private void Awake()
    {
        instance = this;

        //Create the list of commands and add them to the list
        HELP = new ConsoleCommand("help", "Shows list of commands.", "help", () =>
        {
            showHelp = true;
        });

        SET_INT = new ConsoleCommand<int>("set_int", "Sets an int to the given value.", "set_int <value>", (x) =>
        {
            Debug.Log("Value has been set to " + x);
        });

        commandList = new List<object>
        {
            HELP,
            SET_INT
        };
    }

    //This can be used for testing until the inputs have been added to the input system
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote)) OnToggleConsole();

        if (Input.GetKeyDown(KeyCode.Return)) OnReturn();
    }*/

    //This method should be called from wherever input is being handled
    public static void OnToggleConsole()
    {
        instance.OnToggleConsoleMenu();
    }

    //Toggles the console window on or off
    private void OnToggleConsoleMenu()
    {
        //Debug.Log("OnToggleConsole");
        showConsole = !showConsole;
        showHelp = false;

        if (showConsole)
        {
            //Time.timeScale = 0;
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            //Time.timeScale = 1;
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

    }

    //This method should be called from wherever input is being handled
    public static void OnReturn()
    {
        instance.OnReturnInput();
    }

    //Triggers this controller to read the input string
    private void OnReturnInput()
    {
        //Debug.Log("OnReturn");
        if (showConsole)
        {
            HandleInput();
            inputCommand = "";
        }
    }

    //Read the text in the input line and if it matches a ConsoleCommand, invokes it
    private void HandleInput()
    {
        string[] properties = inputCommand.Split(' ');

        for (int i = 0; i < commandList.Count; i++)
        {
            ConsoleCommandBase commandBase = commandList[i] as ConsoleCommandBase;

            if (inputCommand.Contains(commandBase.CommandID))
            {
                if (commandList[i] as ConsoleCommand != null)
                {
                    (commandList[i] as ConsoleCommand).Invoke();
                }
                else if (commandList[i] as ConsoleCommand<int> != null)
                {
                    (commandList[i] as ConsoleCommand<int>).Invoke(int.Parse(properties[1]));
                }
            }
        }
    }

    private void OnGUI()
    {
        if (!showConsole) return;

        float y = 0f;

        //Create a scroll view at the top of the command window to list all commands
        if (showHelp)
        {
            GUI.Box(new Rect(0, y, Screen.width, 100), "");

            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);

            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

            for (int i = 0; i < commandList.Count; i++)
            {
                ConsoleCommandBase command = commandList[i] as ConsoleCommandBase;

                string label = $"{command.CommandFormat} - {command.CommandDescription}";

                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);

                GUI.Label(labelRect, label);
            }

            GUI.EndScrollView();

            y += 100;
        }

        //Creates a text field for inputting commands
        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        inputCommand = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), inputCommand);
    }
}
