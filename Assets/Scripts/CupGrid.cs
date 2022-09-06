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

	// public int amount = 500;
	public float placeDelay = 0.05f;
	private int amountPlacedGlobal = 0;

	public int gridX = 10;
	public int gridY = 10;

	private int numberOfCupsToKeepActiveFromTop = 201;

	//@todo
	public int useLayerAtHeight = 2;

	List<GameObject> cups = new List<GameObject>();

// vlt in coroutine auslagern
// slider beschreibt anzahl der Becher

	void Start(){
		StartCoroutine(Spawn(0, amountPlacedGlobal));
	}

	IEnumerator Spawn(int amount, int amountPlaced)
	{
		Debug.Log("amount" + amount + "amountPlaced" + amountPlaced);

		if(amount < amountPlaced){
			// remove
			for(int i = amountPlaced; i > amount; i--){
				Destroy(cups[i-1]);
				cups.RemoveAt(i-1);


				ShowCupIfNotUseless(i);
			}

		}else{
			// add
			for (int i = amountPlaced; i < amount; i++){
				// if(i % 100 == 0){
				// 	yield return new WaitForSeconds(placeDelay);
				// }

				Instantiate(getX(i), getY(i), getZ(i), cupObject);


				HideCupIfUseless(i);



			}
		}

		amountPlacedGlobal = amount;
		yield return null;
	}

	void Update(){
		// if (update){
		// 	update = false;
		// 	StartCoroutine(Spawn());
		// }
	}

	void Instantiate(int x, int y, int z, GameObject placeObject){
		GameObject cup = Instantiate(placeObject, new Vector3(x * cupWidth, y * cupHeight, z * cupWidth), Quaternion.identity, gameObject.transform);
		cup.gameObject.name = "cup_" + x + "_" + y + "_" + z;
		// cup.gameObject.SetActive(false);
		// cup.transform.parent = gameObject.transform;
		cups.Add(cup);
	}

	public void SetCupAmount(int amountToPlace){
		// amount = amountToPlace;
		StartCoroutine(Spawn(amountToPlace, amountPlacedGlobal));
	}

	private void HideCupIfUseless(int i){
		if(i - numberOfCupsToKeepActiveFromTop >= 0 && cups[i - numberOfCupsToKeepActiveFromTop] != null){
			if(getX(i) == 0) return;
			// if(getX(i) == (gridX - 1)) return;
			if(getZ(i) == 0 || getZ(i) == gridY - 1) return;

			cups[i - numberOfCupsToKeepActiveFromTop].gameObject.SetActive(false);
		}
	}

	private void ShowCupIfNotUseless(int i){
		if(i - numberOfCupsToKeepActiveFromTop >= 0 && cups[i - numberOfCupsToKeepActiveFromTop] != null){
			cups[i - numberOfCupsToKeepActiveFromTop].gameObject.SetActive(true);
		}
	}

	private int getX(int i){
		return i % gridX;
	}

	private int getY(int i){
		return (int)Mathf.Floor(i / (gridX * gridY));
	}

	private int getZ(int i){
		return (int)Mathf.Floor( (i % (gridX * gridY)) / gridY);
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
