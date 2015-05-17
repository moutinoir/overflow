using UnityEngine;
using System.Collections;

public class OFcubeGenerator : MonoBehaviour {
	
	// load cubepresets, later different kinds
	public GameObject[] cubePrefabs;
	
	public int DEBUG_cubeCount = 0;
	
	public float timeBetweenSpawns = 0.5f;

	public float climbness = 0f;

	public float spawnStartDelaySeconds = 1f;
	
	// setup cube generator grid 8x8
	int[,] cubeGrid = new int[8,8];

	public void enableMe(int levelHeight){
		createBaseCubes();

		Invoke ("spawnCube", 1f);
		Vector3 myPosition = new Vector3 (this.transform.position.x, levelHeight + 10, this.transform.position.z);
		this.transform.position = myPosition;
	}

	void createBaseCubes(){
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++) {
				GameObject cube = Instantiate(cubePrefabs[Random.Range (0, cubePrefabs.Length)], new Vector3(Mathf.RoundToInt(i), 0f, Mathf.RoundToInt(j)), genQuaternion()) as GameObject;

				// save the grid location of the cube in the cube grid array
				cubeGrid[Mathf.RoundToInt(i), Mathf.RoundToInt(j)]++;
				
				// parent the cube to the cubeGenerator
				//cube.transform.SetParent(this.transform);
			}

			// increment the DEBUG cube count
			DEBUG_cubeCount++;
		}
	}
	
	void spawnCube() {
		// calculate the medium height of all placed blocks
		float mediumHeight = getMediumHeight();

		// set the final spawn position using generators position
		Vector3 spawnPosition = getSpawnPosition(mediumHeight);

		// instantiate a random cube from the cube prefabs array
		GameObject cube = Instantiate(cubePrefabs[Random.Range (0, cubePrefabs.Length)], spawnPosition, genQuaternion()) as GameObject;
		
		// save the grid location of the cube in the cube grid array
		cubeGrid[Mathf.RoundToInt(spawnPosition.x), Mathf.RoundToInt(spawnPosition.z)]++;
		
		// parent the cube to the cubeGenerator
		cube.transform.SetParent(this.transform);
		
		// increment the DEBUG cube count
		DEBUG_cubeCount++;
		
		Invoke ("spawnCube", timeBetweenSpawns);
	}

	Vector3 getSpawnPosition(float mediumHeight){
		Vector3 sp;
		int x;
		int z;

		float higher = 0f;

		while (true) {
			x = Random.Range(0, 8);
			z = Random.Range(0, 8);

			if (cubeGrid[x, z] < (climbness + mediumHeight + higher)){
				break;
			}

			higher += 0.1f;
		}

		sp = new Vector3 (x, this.transform.position.y, z);

		return sp;
	}

	float getMediumHeight(){
		float mh = 0f;

		for (int i = 0; i < 8; i++){
			for (int j = 0; j < 8; j++){
				mh += cubeGrid[i,j];
			}
		}

		mh /= 64f;

		return mh;
	}
	
	Quaternion genQuaternion(){
		int r = Random.Range (0, 5);
		Quaternion q = Quaternion.LookRotation (Vector3.forward);
		
		switch (r) {
			case 0: q = Quaternion.LookRotation (Vector3.up); break;
			case 1: q = Quaternion.LookRotation (Vector3.down); break;
			case 2: q = Quaternion.LookRotation (Vector3.left); break;
			case 3: q = Quaternion.LookRotation (Vector3.right); break;
			case 4: q = Quaternion.LookRotation (Vector3.back); break;
			case 5: q = Quaternion.LookRotation (Vector3.forward); break;
			default: break;
		}
		
		return q;
	}
}