using System;
using UnityEngine;
using InControl;



		public class PlayerControl : MonoBehaviour
		{
			void Update()
			{
				// Use last device which provided input.
				var inputDevice = InputManager.ActiveDevice;
				
				// Rotate target object with left stick.
				transform.Translate( Vector3.down,  500.0f * Time.deltaTime * inputDevice.LeftStickX, Space.World );
				transform.Translate( Vector3.right, 500.0f * Time.deltaTime * inputDevice.LeftStickY, Space.World );
			}
		}


