using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
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

	public Animator Animator { get; set; }

	private void Start()
	{
		if(!TryGetComponent(out characterController))
		{
			Debug.LogError($"The PlayerMovement script requires a CharacterController attached to the same object. Please attach one to [{gameObject.name}] before running the scene");
		}

		inputActions = new PlayerInputActions();

		inputActions.Enable();
	}

	private void FixedUpdate()
	{
		var moveInput = inputActions.Player.Move.ReadValue<Vector2>();

		if(PlayerStateManager.Instance.GetCurrentPlayerState() <= PlayerState.Running)
		{
			movement = moveInput.y;
			turn = moveInput.x;
		}

		if(movement != 0f)
		{
			var moveRate = movement * walkSpeed * transform.forward;

			characterController.Move(Time.fixedDeltaTime * moveRate);

			SetAnimatorMoving(true);
		}
		else
		{
			SetAnimatorMoving(false);
		}

		if(turn != 0f)
		{
			var turnRate = 100 * turnSpeed * new Vector3(0, turn, 0);

			transform.Rotate(Time.fixedDeltaTime * turnRate);
		}

		if(movement == 0f && turn == 0f)
		{
			PlayerStateManager.Instance.RemovePendingState(PlayerState.Walking);
		}
		else
		{ 
			PlayerStateManager.Instance.TrySetCurrentPlayerState(PlayerState.Walking);
		}
	}

	private void SetAnimatorMoving(bool moving)
	{
		if(Animator == null)
		{
			Debug.LogError("Your player is missing an animator or an animator subscription script");
		}

		Animator.SetBool("Moving", moving);
	}
}
