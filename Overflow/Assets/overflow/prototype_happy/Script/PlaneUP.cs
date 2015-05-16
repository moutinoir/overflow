using UnityEngine;
using System.Collections;

public class PlaneUP : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// Plane UP moving
		transform.Translate (0.0f,  speed * 0.01f, 0.0f, Space.World);

	}

	private void OnCollisionEnter (Collision collision){

		// collision
		print ("collision OK!! \n");
		// only "Player" destroy
		if(collision.gameObject.CompareTag("Player")){
			Destroy(collision.gameObject);
		}

	}

}
