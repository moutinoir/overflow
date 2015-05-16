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
	
	void Start(){
		// check if level height input is legit
		if (levelHeight >= 15 && levelHeight % 5 == 0) {
			generateLevel ();
		} else
			Debug.Log ("ERROR: level height input wrong!");

	}

	void generateLevel(){
		GameObject wall = Instantiate(wallStartPrefabs[Random.Range(0, wallStartPrefabs.Length)], Vector3.zero, Quaternion.identity) as GameObject;
		wall.transform.SetParent(this.transform);

		for (int curHeight = 5; (curHeight + 5) < levelHeight; ) {
			float curDoubleChance = Random.value;

			if ((curHeight + 10) < levelHeight && curDoubleChance > simpleChance){
				int wallNumber = Random.Range (0, wallDoublePrefabs.Length);
				Vector3 spawnPosition = new Vector3 (0f, curHeight, 0f);

				wall = Instantiate(wallDoublePrefabs[wallNumber], spawnPosition, Quaternion.identity) as GameObject;
				wall.transform.SetParent(this.transform);

				Color myColor = new Color(0f, 0f, Random.value);
				foreach (Transform child in wall.transform)
				{
					child.GetComponent<Renderer>().material.color = myColor;
				}
				
				curHeight += 10;
			}

			else {
				int wallNumber = Random.Range (0, wallSimplePrefabs.Length);
				Vector3 spawnPosition = new Vector3 (0f, curHeight, 0f);
				
				wall = Instantiate(wallSimplePrefabs[wallNumber], spawnPosition, Quaternion.identity) as GameObject;
				wall.transform.SetParent(this.transform);

				Color myColor = new Color(Random.value, 0f, 0f);
				foreach (Transform child in wall.transform)
				{
					child.GetComponent<Renderer>().material.color = myColor;
				}
				
				curHeight += 5;
			}
		}

		wall = Instantiate(wallEndPrefabs[Random.Range(0, wallEndPrefabs.Length)], new Vector3(0f, levelHeight - 5, 0f), Quaternion.identity) as GameObject;
		wall.transform.SetParent(this.transform);

		GameObject.Find ("cubeGenerator").GetComponent<cubeGeneration> ().enableMe (levelHeight);
	}
}
