using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cubeGeneration : MonoBehaviour {

	// load cubepresets, later different kinds
	public GameObject[] cubePrefabs;
	
	public int DEBUG_cubeCount = 0;

	// setup cube generator grid 8x8
	GameObject[,] cubeGrid = new GameObject[8,8];

	public void enableMe(int levelHeight){
		InvokeRepeating ("spawnCube", 1f, 0.1f);
		Vector3 myPosition = new Vector3 (this.transform.position.x, levelHeight + 10, this.transform.position.z);
		this.transform.position = myPosition;
	}

	void spawnCube() {
		// generate a random spawn position
		int x = Random.Range(0, 7);
		int z = Random.Range(0, 7);

		// set the final spawn position using generators position
		Vector3 spawnPosition = new Vector3(x-3, this.transform.position.y, z-3);

		// instantiate a random cube from the cube prefabs array
		GameObject cube = Instantiate(cubePrefabs[Random.Range (0, cubePrefabs.Length)], spawnPosition, genQuaternion()) as GameObject;

		// save the grid location of the cube in the cube grid array
		cubeGrid[x,z] = cube;

		// parent the cube to the cubeGenerator
		cube.transform.SetParent(this.transform);

		// increment the DEBUG cube count
		DEBUG_cubeCount++;
	}

	Quaternion genQuaternion(){
		int r = Random.Range (0, 5);
		Quaternion q;

		switch (r) {
			case 0: q = Quaternion.LookRotation (Vector3.up); break;
			case 1: q = Quaternion.LookRotation (Vector3.down); break;
			case 2: q = Quaternion.LookRotation (Vector3.left); break;
			case 3: q = Quaternion.LookRotation (Vector3.right); break;
			case 4: q = Quaternion.LookRotation (Vector3.back); break;
			case 5: q = Quaternion.LookRotation (Vector3.forward); break;
		}

		return q;
	}
}