using UnityEngine;
using System.Collections;

public class PlaneUP : MonoBehaviour {

	public GameObject gameOverPrefab;

	public float speed;

	// Update is called once per frame
	void Update () {
		// Plane UP moving
		transform.Translate (0.0f,  speed * 0.01f, 0.0f, Space.World);
	}

	void OnCollisionEnter (Collision collision){

		// collision
		Debug.Log ("PLAYER fell into the water!");
		// only "Player" destroy

		if(collision.gameObject.CompareTag("Player")){
			Destroy(collision.gameObject);

			Instantiate (gameOverPrefab, Vector3.zero, Quaternion.identity);
		}
	}
}
