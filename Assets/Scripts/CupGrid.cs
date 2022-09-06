using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGrid : MonoBehaviour
{
	public GameObject cupObject;
	public GameObject cupLayerObject;
  public bool update;

	public float cupWidth = 0.085f;
	public float cupHeight = 0.105f;

	public int amount = 500;
	public float placeDelay = 0.05f;
	private int amountPlaced = 0;

	public int gridX = 10;
	public int gridY = 10;

	//@todo
	public int useLayerAtHeight = 2;

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

				Instantiate(i % gridX, (int)Mathf.Floor(i / (gridX * gridY)), (int)Mathf.Floor( (i % (gridX * gridY)) / gridY), cupObject);
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

	void Instantiate(int x, int y, int z, GameObject placeObject){
		GameObject cup = Instantiate(placeObject, new Vector3(x * cupWidth, y * cupHeight, z * cupWidth), Quaternion.identity);
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
