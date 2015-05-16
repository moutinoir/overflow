using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cubeGeneration : MonoBehaviour {
	
	public GameObject cubePrefab;
	public float spawnRange = 2f;
	public int maxPrefabs = 100;

	GameObject[,] cubeArr = new GameObject[8,8];
	
	void Start(){
	}
	
	void Update() {
		if (Input.GetMouseButtonDown(0)){
			int x = Random.Range(0, 7);
			int y = Random.Range(0, 7);
			Debug.Log ("cubeGenerator wants to create new cube at: " + x + "," + y);

			Vector3 spawnPosition = new Vector3(x, 20f, y);
			
			GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity) as GameObject;
			cube.transform.SetParent(this.transform);
			
			cubeArr[x,y] = cube;

			Debug.Log ("cube created at: " + x + "," + y);
		}
	}
}