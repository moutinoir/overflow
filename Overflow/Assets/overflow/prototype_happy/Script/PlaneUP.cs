using UnityEngine;
using System.Collections;

public class PlaneUP : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {

		// Plane UP moving
		transform.Translate (0.0f,  speed * 0.01f, 0.0f, Space.World);

	}

	void OnCollisionEnter (Collision collision){

		// collision
		Debug.Log ("collision OK!!");
		// only "Player" destroy
		if(collision.gameObject.CompareTag("Player")){
			Destroy(collision.gameObject);
		}
	}
}
