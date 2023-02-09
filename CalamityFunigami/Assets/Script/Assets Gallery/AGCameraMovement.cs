using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class AGCameraMovement : MonoBehaviour
{
	#region Private Variables
	private AssetGalleryInputAction inputActions;
	#endregion

	private void Start()
	{
		inputActions = new AssetGalleryInputAction();

		inputActions.Enable();
	}

	private void Update()
	{
		var moveInput = inputActions.Camera.Move.ReadValue<Vector2>();
		var zoomInput = inputActions.Camera.Zoom.ReadValue<float>();

		transform.position += new Vector3(moveInput.x, moveInput.y, zoomInput) / 15;
	}
}
