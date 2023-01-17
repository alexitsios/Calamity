using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInteraction : MonoBehaviour
{
	#region Private Variables
	private PlayerInputActions input;
	#endregion

	private void Start()
	{
		input = new PlayerInputActions();
		input.Player.Enable();
		input.Player.Interact.performed += InteractWith;
	}

	// Update is called once per frame
	private void InteractWith(CallbackContext obj)
	{
		var forward = transform.TransformDirection(Vector3.forward);

		DebugController.Instance.DrawRaycast(transform.position, forward, Color.red, 5);

		if(Physics.Raycast(transform.position, forward, out var objectHit, 1))
		{
			if(objectHit.collider.gameObject.TryGetComponent<Interactive>(out var interactiveTarget))
			{
				interactiveTarget.Interact();
			}
		}
	}
}
