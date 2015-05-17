using UnityEngine;
using System.Collections;

public class Waterfall : MonoBehaviour {

	//public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		print ("enter");
	}

	void OnTriggerExit(Collider other){
		print ("exit");
		//Instantiate (this.prefab, new Vector3(0, 0, 0), Quaternion.identity);
	}
}
