using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputTesting : MonoBehaviour
{
	void Start()
	{
		var inputAction = new PlayerInputActions();
		inputAction.Enable();
		inputAction.Player.Move.performed += LogInput;
		inputAction.Player.Run.performed += LogInput;
		inputAction.Player.Pause.performed += LogInput;
		inputAction.Player.Aim.performed += LogInput;
		inputAction.Player.ChangeTarget.performed += LogInput;
		inputAction.Player.Action.performed += LogInput;
		inputAction.Player.Inventory.performed += LogInput;
		inputAction.Player.Map.performed += LogInput;

		inputAction.Player.Inventory.performed += delegate 
		{
			GetComponent<PlayerInventory>().ToggleInventoryDisplay();
		};
	}

	private void LogInput(CallbackContext obj)
	{
		Debug.Log($"Action performed: {obj.action.name} [{obj.control.displayName}]");
	}
}
