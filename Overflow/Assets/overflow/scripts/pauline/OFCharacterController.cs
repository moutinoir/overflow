using UnityEngine;
using System.Collections;
using InControl;

public class OFCharacterController : MonoBehaviour 
{
	public float MoveSpeed = 0;
	CharacterController motionController;
	// Use this for initialization
	void Awake () 
	{
		motionController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
	}

	void Move ()
	{
		InputDevice inputDevice = InputManager.ActiveDevice;
		Vector3 forward = inputDevice.LeftStickY * transform.TransformDirection(Vector3.forward) * MoveSpeed;
		transform.Rotate(new Vector3(0,inputDevice.LeftStickX, 0));
		motionController.Move(forward*Time.deltaTime);
	}
}
