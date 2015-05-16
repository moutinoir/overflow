using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cubeGeneration : MonoBehaviour {

	// load cubepresets, later different kinds
	public GameObject cubePrefab;

	[SerializeField]
	int cubeCount = 0;

	// setup cube generator grid 8x8
	GameObject[,] cubeArr = new GameObject[8,8];

	public void enableMe(int levelHeight){
		InvokeRepeating ("spawnCube", 1f, 0.1f);
		Vector3 myPosition = new Vector3 (this.transform.position.x, levelHeight + 10, this.transform.position.z);
		this.transform.position = myPosition;
	}

	void spawnCube() {
		int x = Random.Range(0, 7);
		int z = Random.Range(0, 7);

		Vector3 spawnPosition = new Vector3(x-3, this.transform.position.y, z-3);
		
		GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity) as GameObject;
		cube.transform.SetParent(this.transform);

		cubeCount++;
		
		cubeArr[x,z] = cube;
	}
}