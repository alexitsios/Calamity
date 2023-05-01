using Calamity.Primitives;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	#region Editor Variables
	[SerializeField]
	[Tooltip("Rotation speed when turning left/right")]
	private float turnSpeed = 2f;

	//[SerializeField]
	//[Tooltip("Forward speed when walking")]
	//private float walkSpeed = 10f;

	[SerializeField] private FloatReference[] movementSpeeds;
	#endregion

	#region Private Variables
	private CharacterController characterController;
	private PlayerInput playerInput;
	private float movement;
	private float turn;
	#endregion

	public Animator Animator { get; set; }

	private void Start()
	{
		if(!TryGetComponent(out characterController))
		{
			throw new Exception($"The PlayerMovement script requires a CharacterController attached to the same object. Please attach one to [{gameObject.name}] before running the scene");
		}
		playerInput = GetComponent<PlayerInput>();
	}

	private void FixedUpdate()
	{
		var moveInput = playerInput.actions["Move"].ReadValue<Vector2>();

		float speedState = 0f;
		var speed = movementSpeeds[(int)SpeedStates.Walk];
		if (playerInput.actions["Run"].IsPressed())
		{
			speed = movementSpeeds[(int)SpeedStates.Run];
			speedState = 1f;
        }

		movement = moveInput.y;
		turn = moveInput.x;

		if(movement != 0f)
		{
			speedState = 0.5f;
			var moveRate = movement * speed * transform.forward;

			characterController.Move(Time.fixedDeltaTime * moveRate);

			//SetAnimatorMoving(true);
		}
		else
		{
            //SetAnimatorMoving(false);
        }

		if(turn != 0f)
		{
			var turnRate = 100 * turnSpeed * new Vector3(0, turn, 0);

			transform.Rotate(Time.fixedDeltaTime * turnRate);
		}

        SetAnimatorParameters(speedState, moveInput.x, moveInput.y);
    }

	private void SetAnimatorParameters(float speedState, float horizontal, float vertical)
	{
        if (Animator == null)
            Debug.LogError("Your player is missing an animator or an animator subscription script");
		Animator.SetFloat("speed", speedState);
		Animator.SetFloat("horizontal", horizontal);
		Animator.SetFloat("vertical", vertical);

    }
	private void SetAnimatorMoving(bool moving)
	{
		if (Animator == null)
			Debug.LogError("Your player is missing an animator or an animator subscription script");
		Animator.SetBool("Moving", moving);
	}
}

public enum SpeedStates
{
	Walk,
	Run
}