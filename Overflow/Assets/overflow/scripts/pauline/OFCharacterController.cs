using UnityEngine;
using System.Collections;
using InControl;

public class OFCharacterController : MonoBehaviour 
{
	public Animator animator;

	public AudioSource jumpAS;

	public float MoveSpeed = 0;
	public float TurnSpeed = 2;
	public float GravityScale = 1;
	public float JumpLeap = 4;
	public float JumpLifeTime = 2;

	CharacterController motionController;
	float jumpTime = 0;
	bool isJumping = false;

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
		Vector3 jump = Vector3.zero;

		if(motionController.isGrounded)
		{
			isJumping = false;
			jumpTime = 0;

			if(inputDevice.Action1)
			{
				isJumping = true;
				jumpAS.Play();
			}

			animator.SetBool("jumping", isJumping);
		}

		if(isJumping)
		{
			jumpTime += Time.deltaTime;
			jump = Vector3.up * JumpLeap * Mathf.Exp(-jumpTime / JumpLifeTime);
		}

		Vector3 forward = inputDevice.LeftStickY * transform.TransformDirection(Vector3.forward) * MoveSpeed;
		Vector3 gravity = -Vector3.up * GravityScale;
		transform.Rotate(new Vector3(0,(inputDevice.LeftStickX + inputDevice.RightStickX) * TurnSpeed, 0));
		motionController.Move((forward + gravity + jump)*Time.deltaTime);
	}
}
