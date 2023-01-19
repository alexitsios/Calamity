using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("Rotation speed when turning left/right")]
	private float turnSpeed = 2f;

	[SerializeField]
	[Tooltip("Forward speed when walking")]
	private float walkSpeed = 10f;
	#endregion

	#region Private Variables
	private CharacterController characterController;
	private PlayerInputActions inputActions;
	private float movement;
	private float turn;
	#endregion

	private void Start()
	{
		if(!TryGetComponent(out characterController))
		{
			throw new Exception($"The PlayerMovement script requires a CharacterController attached to the same object. Please attach one to [{gameObject.name}] before running the scene");
		}

		inputActions = new PlayerInputActions();

		inputActions.Enable();
	}

	private void FixedUpdate()
	{
		var moveInput = inputActions.Player.Move.ReadValue<Vector2>();

		movement = moveInput.y;
		turn = moveInput.x;

		if(movement != 0f)
		{
			var moveRate = movement * walkSpeed * transform.forward;

			characterController.Move(Time.fixedDeltaTime * moveRate);
		}

		if(turn != 0f)
		{
			var turnRate = 100 * turnSpeed * new Vector3(0, turn, 0);

			transform.Rotate(Time.fixedDeltaTime * turnRate);
		}
	}
}
