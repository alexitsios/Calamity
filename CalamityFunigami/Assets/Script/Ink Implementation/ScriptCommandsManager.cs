using System;
using UnityEngine;

public class ScriptCommandsManager : MonoBehaviour
{
	/// <summary>
	///		Executes the command specified in the script, starting with '>>'
	/// </summary>
	/// <param name="command">The command to execute, with all parameters necessary</param>
	public void RunCommand(string command)
	{
		var temp = command.Replace(">>", "").Split(' ');
		var action = (InkCommandEnum) Enum.Parse(typeof(InkCommandEnum), temp[0]);
		var args = temp[1..];

		switch(action)
		{
			case InkCommandEnum.MoveTo:
				MoveTo(args);
				break;
		}
	}

	private void MoveTo(string[] args)
	{
		// TODO: implement code to move one object towards another
	}
}
