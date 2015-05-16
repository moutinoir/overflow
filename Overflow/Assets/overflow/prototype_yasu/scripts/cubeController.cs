using UnityEngine;
using System.Collections;

public class cubeController : MonoBehaviour {

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
			if (RB.velocity == Vector3.zero) {
				nonMovingCount++;

				if (nonMovingCount > 5){
					RB.isKinematic = true;
					kinematic = true;

					Destroy (RB);

					Vector3 adjustedPosition = new Vector3(Mathf.RoundToInt(this.transform.position.x), 
					                                Mathf.RoundToInt(this.transform.position.y),  
					                                Mathf.RoundToInt(this.transform.position.z));

					this.transform.position = adjustedPosition;

					Color myColor = new Color(0f, 0f, Random.value);
					foreach (Transform child in this.transform)
					{
						child.GetComponent<Renderer>().material.color = Color.green;
					}
				}
			}

			else nonMovingCount = 0;
		}
	}
}