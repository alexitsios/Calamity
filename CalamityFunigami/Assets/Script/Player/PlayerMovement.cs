using UnityEngine;

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
	private float movement;
	private float turn;
	#endregion

	private void Start()
	{
		characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		// TODO: maybe use absolute values, so the character is either standing still or walking at full speeed
		movement = Input.GetAxis("Vertical");
		turn = Input.GetAxis("Horizontal");
	}

	private void FixedUpdate()
	{
		if(movement != 0f)
		{
			var moveRate = movement * walkSpeed * transform.forward;

			characterController.Move(Time.fixedDeltaTime * moveRate);
		}
		else
		{
			var turnRate = 100 * turnSpeed * new Vector3(0, turn, 0);

			transform.Rotate(Time.fixedDeltaTime * turnRate);
		}
	}
}
