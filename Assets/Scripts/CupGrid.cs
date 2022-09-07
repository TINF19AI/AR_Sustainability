using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGrid : MonoBehaviour
{
	public GameObject cupObject;
	public GameObject cupLayerObject;

	public Vector3 cupSize = new Vector3();
	private int amountPlacedGlobal = 0;

	public int gridX = 25;
	public int gridZ = 25;

	private int numberOfCupsToKeepActiveFromTop = 625;

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
		// Calculate bounds for the first Cup
		if(cups.Count > 0 && cupSize.x == 0 && cupSize.y == 0	&& cupSize.z == 0){
			cupSize = Vector3.Scale(GetMaxBounds(cups[0]).max, new Vector3(2,2,2));
		}

		// More cups than needed? Remove
		if(amount < amountPlaced){
			// remove
			for(int i = amountPlaced; i > amount; i--){
				Destroy(cups[i-1]);
				cups.RemoveAt(i-1);

				ShowCupIfNotUseless(i);
			}

		// Place more cups
		}else{
			// add
			for (int i = amountPlaced; i < amount; i++){

				if(i > 7500 && !IsAtEdge(getPosition(i))){
					cups.Add(null);
				}else{
					Instantiate(getX(i), getY(i), getZ(i), cupObject);
					HideCupIfUseless(i);
				}

			}
		}

		amountPlacedGlobal = amount;
		yield return null;
	}

	void Update(){
	}

	void Instantiate(int x, int y, int z, GameObject placeObject){
		GameObject cup = Instantiate(placeObject, new Vector3(x * cupSize.x, y * cupSize.y, z * cupSize.z), Quaternion.identity, gameObject.transform);
		cup.gameObject.name = "cup_" + x + "_" + y + "_" + z;
		cups.Add(cup);
	}

	public void SetCupAmount(int amountToPlace){
		// amount = amountToPlace;
		StartCoroutine(Spawn(amountToPlace, amountPlacedGlobal));
	}

	private void HideCupIfUseless(int i){
		if(i - numberOfCupsToKeepActiveFromTop >= 0 && cups[i - numberOfCupsToKeepActiveFromTop] != null){
			if(IsAtEdge(getPosition(i))){
				return;
			}

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
		return (int)Mathf.Floor(i / (gridX * gridZ));
	}

	private int getZ(int i){
		return (int)Mathf.Floor( (i % (gridX * gridZ)) / gridZ);
	}

	private Vector3 getPosition(int i){
		return new Vector3(getX(i), getY(i), getZ(i));
	}


	Bounds GetMaxBounds(GameObject g) {
		var b = new Bounds(g.transform.position, Vector3.zero);
		foreach (Renderer r in g.GetComponentsInChildren<Renderer>()) {
			b.Encapsulate(r.bounds);
		}
		return b;
	}


	bool IsAtEdge(Vector3 position){
		if(position.x == 0 || position.x == 1) return true;
		if(position.x == gridX - 1 || position.x == gridX - 2) return true;

		if(position.z == 0 || position.z == 1) return true;
		if(position.z == gridZ - 1 || position.z == gridZ - 2) return true;

		return false;
	}
}
