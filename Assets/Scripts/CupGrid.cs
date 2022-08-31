using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGrid : MonoBehaviour
{
	public GameObject block;
  public bool update;

	public int cupWidth = 2;
	public int cupHeight = 2;

	public int amount = 3;
	public float placeDelay = 0.05f;
	private int amountPlaced = 0;

	public int gridX = 10;
	public int gridY = 10;

	List<GameObject> cups = new List<GameObject>();

// vlt in coroutine auslagern
// slider beschreibt anzahl der Becher

	void Start(){
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn()
	{
		if(amount < amountPlaced){
			// remove
			for(int i = amountPlaced; i > amount; i--){
				Destroy(cups[i-1]);
				cups.RemoveAt(i-1);
			}

		}else{
			// add
			for (int i = amountPlaced; i < amount; i++){
				if(i % 100 == 0){
					yield return new WaitForSeconds(placeDelay);
				}

				Instantiate(i % gridX, (int)Mathf.Floor(i / (gridX * gridY)), (int)Mathf.Floor( (i % (gridX * gridY)) / gridY));
			}
		}

		amountPlaced = amount;
		yield return null;
	}

	void Update(){
		if (update){
			update = false;
			StartCoroutine(Spawn());
		}
	}

	void Instantiate(int x, int y, int z){
		GameObject cup = Instantiate(block, new Vector3(x * cupWidth, y * cupHeight, z * cupWidth), Quaternion.identity);
		cup.gameObject.name = "cup_" + x + "_" + y + "_" + z;
		cup.transform.parent = gameObject.transform;
		cups.Add(cup);
	}
}









		// bool addChildren = false;

		// if(prevWidth > width) {
		// 	// remove previous prefabs

		// }else{
		// 	addChildren = true;
		// }

		// if(prevLength > length) {
		// 	// remove previous prefabs

		// }else{
		// 	addChildren = true;
		// }

		// if(prevHeight > height) {
		// 	// remove previous prefabs

		// }else{
		// 	addChildren = true;
		// }

		// if(addChildren == true){
		// 	for (int x = 0; x<width; ++x)
		// 	{
		// 		for (int y = 0; y<length; ++y)
		// 		{
		// 			for (int z = 0; z<height; ++z)
		// 			{
		// 				if(GameObject.Find ("cup_" + x + "_" + y + "_" + z) == null){
		// 					Instantiate(x, y, z);
		// 				}
		// 			}
		// 		}
		// 	}
		// }

		// // set current size to prevSize
		// prevWidth = width;
		// prevLength = length;
		// prevHeight = height;
