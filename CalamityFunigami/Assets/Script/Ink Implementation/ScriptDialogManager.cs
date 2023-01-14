using System.Collections.Generic;
using UnityEngine;

public class ScriptDialogManager : MonoBehaviour
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="message"></param>
	public void DisplayDialog(string message, List<string> tags)
	{
		var temp = message.Split(":");
		var character = temp[0];
		var text = temp[1];

		Debug.Log($"{character} said: {text} (with tags {string.Join(", ", tags)})");
	}
}
