using UnityEngine;
using System.Collections;

public class cubeController : MonoBehaviour {

	float warningDistance = 100f;

	Rigidbody RB;

	bool kinematic = false;

	int nonMovingCount = 0;

	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
		Vector3 myVel = new Vector3 (0f, -10f, 0f);
		RB.velocity = myVel;
	}
	
	void FixedUpdate(){
		if (kinematic == false) {

			RaycastHit hit;
			Physics.Raycast (this.transform.position, -Vector3.up, out hit, warningDistance);

			if (hit.collider != null) {
				
				if (hit.transform.tag == "Stone") {
					foreach (Transform child in hit.transform)
					{
						child.GetComponent<Renderer>().material.color = new Color(1.0f - ((this.transform.position.y - hit.transform.position.y)/60f), 0.0f, 0.0f);
					}
				} 
			}

			if (RB.velocity.y <= 0f && RB.velocity.y > -0.01f) {

				nonMovingCount++;

				if (nonMovingCount > 15){
					RB.isKinematic = true;
					kinematic = true;

					Destroy (RB);

					Vector3 adjustedPosition = new Vector3(Mathf.RoundToInt(this.transform.position.x), 
					                                Mathf.RoundToInt(this.transform.position.y),  
					                                Mathf.RoundToInt(this.transform.position.z));

					this.transform.position = adjustedPosition;
				}
			}

			else {
				nonMovingCount = 0;
			}


		
		}
	}

	/*
	void OnCollisionEnter(Collision collision) {
	    foreach (ContactPoint contact in collision.contacts) {
	        Debug.DrawRay(contact.point, contact.normal, Color.white);
	    }
	    if (collision.relativeVelocity.magnitude > 2)
	        audio.Play();
    }
	 */
}