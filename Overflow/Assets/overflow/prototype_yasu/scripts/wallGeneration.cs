using UnityEngine;
using System.Collections;

public class wallGeneration : MonoBehaviour {

	// put in all wall prefabs
	public GameObject[] wallStartPrefabs;	// level bottoms, 5m height
	public GameObject[] wallSimplePrefabs;	// level mids, 5m height
	public GameObject[] wallDoublePrefabs;	// level mids, 10m height
	public GameObject[] wallEndPrefabs;		// level ends, whatever m height

	// set level height before generation
	public int levelHeight = 40;

	public float simpleChance = 0.4f;

	// counter for level generation
	int curHeight = 0;
	
	GameObject[,] cubeArr = new GameObject[8,8];
	
	void Start(){
		// check if level height input is legit
		if (levelHeight >= 15 && levelHeight % 5 == 0) {
			generateLevel ();
		} else
			Debug.Log ("ERROR: level height input wrong!");

	}

	void generateLevel(){
		Instantiate(wallStartPrefabs[Random.Range(0, wallStartPrefabs.Length)], Vector3.zero, Quaternion.identity);

		curHeight += 5;

		int while_debug = 0;

		while (while_debug < 20) {
			float curDoubleChance = Random.value;

			if ((curHeight + 10) < levelHeight && curDoubleChance > simpleChance){
				int wallNumber = Random.Range (0, wallDoublePrefabs.Length);
				Vector3 spawnPosition = new Vector3 (0f, curHeight, 0f);

				GameObject wall = Instantiate(wallDoublePrefabs[wallNumber], spawnPosition, Quaternion.identity) as GameObject;
				Color myColor = new Color(0f, 0f, Random.value);
				foreach (Transform child in wall.transform)
				{
					child.GetComponent<Renderer>().material.color = myColor;
				}
				
				curHeight += 10;
			}

			else if ((curHeight) + 5 < levelHeight){
				int wallNumber = Random.Range (0, wallSimplePrefabs.Length);
				Vector3 spawnPosition = new Vector3 (0f, curHeight, 0f);
				
				GameObject wall = Instantiate(wallSimplePrefabs[wallNumber], spawnPosition, Quaternion.identity) as GameObject;
				Color myColor = new Color(Random.value, 0f, 0f);
				foreach (Transform child in wall.transform)
				{
					child.GetComponent<Renderer>().material.color = myColor;
				}
				
				curHeight += 5;
			}

			if (curHeight >= levelHeight){
				break;
			}

			while_debug++;
		}
		Debug.Log ("WHILE left in " + while_debug + " runs!");

		Instantiate(wallEndPrefabs[Random.Range(0, wallEndPrefabs.Length)], new Vector3(0f, curHeight, 0f), Quaternion.identity);

		GameObject.Find ("cubeGenerator").GetComponent<cubeGeneration> ().enableMe (levelHeight);
	}
}
