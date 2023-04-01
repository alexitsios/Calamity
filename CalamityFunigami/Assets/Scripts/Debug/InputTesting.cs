using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputTesting : MonoBehaviour
{
	void Start()
	{
		var playerInput = GetComponent<PlayerInput>();
		playerInput.actions["Move"].performed += LogInput;
		playerInput.actions["Run"].performed += LogInput;
		playerInput.actions["Pause"].performed += LogInput;
		playerInput.actions["Aim"].performed += LogInput;
		playerInput.actions["Change Target"].performed += LogInput;
		playerInput.actions["Action"].performed += LogInput;
		playerInput.actions["Inventory"].performed += LogInput;
		playerInput.actions["Map"].performed += LogInput;
	}

	private void LogInput(CallbackContext obj)
	{
		Debug.Log($"Action performed: {obj.action.name} [{obj.control.displayName}]");
	}
}
