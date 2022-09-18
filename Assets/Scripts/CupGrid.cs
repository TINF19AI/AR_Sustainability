using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGrid : MonoBehaviour
{
	public GameObject cupObject;
	public GameObject cupHighlightedObject;
	public GameObject arCamera;

	public Vector3 cupSize = new Vector3();
	private int amountPlacedGlobal = 0;

	public const int gridX = 25;
	public const int gridZ = 25;
	private const int gridSize = (gridX * gridZ);

	public int numberOfCupsToKeepActiveFromTop = 625;
	public int dontInstantiateAtCups = 7500;

	//@todo
	public int useLayerAtHeight = 2;

	List<GameObject> cups = new List<GameObject>();

// vlt in coroutine auslagern
// slider beschreibt anzahl der Becher

	void Start(){
		SetCupAmount(0);
	}

	void Update(){
		transform.LookAt(arCamera.transform);
		transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 180, 0);
	}

	IEnumerator Spawn(int amount, int amountPlaced, bool defaultPrefab)
	{


		// Calculate bounds for the first Cup
		if(cups.Count > 0 && cupSize.x == 0 && cupSize.y == 0	&& cupSize.z == 0){
			cupSize = Vector3.Scale(GetMaxBounds(cups[0]).max, new Vector3(2,2,2));
		}

		// More cups than needed? Remove
		if(amount < amountPlaced){
			// remove
			for(int i = amountPlaced; i > amount; i--){
				if(cups[i-1] != null){
					Destroy(cups[i-1]);
				}else{
					cups[(i - 1) % gridSize].transform.localPosition = getLocalPosition((i - 1) - gridSize );
				}

				cups.RemoveAt(i-1);
				// ShowCupIfNotUseless(i);
			}

		// Place more cups
		}else{

			// add
			for (int i = amountPlaced; i < amount; i++){
				if(i > (gridX * gridZ) && !IsAtEdge(getPosition(i))){
					cups[i % gridSize].transform.localPosition = getLocalPosition(i);
					cups.Add(null);
				}else{
					Instantiate(i, defaultPrefab ? cupObject : cupHighlightedObject );
					// HideCupIfUseless(i);
				}

			}
		}

		amountPlacedGlobal = amount;
		yield return null;
	}

	void Instantiate(int positionIndex, GameObject placeObject){
		GameObject cup = Instantiate(placeObject, new Vector3(), Quaternion.identity, gameObject.transform);
		cup.transform.localPosition = getLocalPosition(positionIndex);
		Vector3 position = getPosition(positionIndex);
		cup.gameObject.name = "cup_" + position.x + "_" + position.y + "_" + position.z;
		cups.Add(cup);
	}

	public void SetCupAmount(int amountToPlace, bool defaultPrefab = true){
		StartCoroutine(Spawn(amountToPlace, amountPlacedGlobal, defaultPrefab));
	}

	public void SetHighlightedCups(int realAmountOfCups){
		StartCoroutine(HightlightCups(amountPlacedGlobal, realAmountOfCups));
	}

	private IEnumerator HightlightCups(int guessedAmount, int realAmountOfCups){
		if(guessedAmount > realAmountOfCups){
			// More than correct amount
			SetCupAmount(realAmountOfCups);
			SetCupAmount(guessedAmount, false);

		}else{
			// Less then correct amount
			SetCupAmount(realAmountOfCups, false);
		}

		yield return null;
	}

	// private void HideCupIfUseless(int i){
	// 	if(i - numberOfCupsToKeepActiveFromTop >= 0 && cups[i - numberOfCupsToKeepActiveFromTop] != null){
	// 		if(IsAtEdge(getPosition(i))){
	// 			return;
	// 		}

	// 		cups[i - numberOfCupsToKeepActiveFromTop].gameObject.SetActive(false);
	// 	}
	// }

	// private void ShowCupIfNotUseless(int i){
	// 	if(i - numberOfCupsToKeepActiveFromTop >= 0 && cups[i - numberOfCupsToKeepActiveFromTop] != null){
	// 		cups[i - numberOfCupsToKeepActiveFromTop].gameObject.SetActive(true);
	// 	}
	// }

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

	private Vector3 getLocalPosition(int i){
		Vector3 position = getPosition(i);
		return new Vector3(
			position.x * cupSize.x / transform.localScale.x,
			position.y * cupSize.y / transform.localScale.y,
			position.z * cupSize.z / transform.localScale.z
		);
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
