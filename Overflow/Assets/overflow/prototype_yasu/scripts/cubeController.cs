using UnityEngine;
using System.Collections;

public class cubeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rigidbody RB = GetComponent<Rigidbody> ();
		Vector3 myVel = new Vector3 (0f, -10f, 0f);
		RB.velocity = myVel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
