using UnityEngine;
using System.Collections;

public class OFcubeController : MonoBehaviour {

	public GameObject prefabWarning;
	public LayerMask mask;
	public GameObject prefabHit;

	float warningDistance = 100f;

	Rigidbody RB;

	bool kinematic = false;

	bool warned = false;

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
			Physics.Raycast (this.transform.position, -Vector3.up, out hit, warningDistance, mask);

			if (hit.collider != null) {
				
				//if (hit.transform.tag == "Stone") {

					foreach (Transform child in hit.transform)
					{
						child.GetComponent<Renderer>().material.color = new Color(1.0f - ((this.transform.position.y - hit.transform.position.y)/60f), 0.0f, 0.0f);
					}

					/*
					if (warned == false){
						warned = true;
						Instantiate(prefabWarning, new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, hit.transform.position.z), Quaternion.identity);
					}
					*/
				//} 
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

	void OnCollisionEnter (Collision collision)
	{
		// only "Player" destroy
		if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			// collision
			Debug.Log ("rock collides with player !");
			//if (!(RB.velocity.y <= 0f && RB.velocity.y > -0.01f)) 
			if(collision.gameObject.transform.position.y < transform.position.y)
			{
				Destroy(collision.gameObject);
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