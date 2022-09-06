using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainMode : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tapText;
    [SerializeField] int currentAmount;

    //private PointerEventData pt;
    //private GraphicRaycaster rc;
    //public EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        //rc = GetComponent<GraphicRaycaster>();
        //eventSystem = GetComponent<EventSystem>();
        UIController.ShowUI("main");
    }

    // Update is called once per frame
    void Update()
    {
        //pt = new PointerEventData(eventSystem);
        //pt.position = Input.mousePosition;
        //List<RaycastResult> results = new List<RaycastResult>();
        //rc.Raycast(pt, results);

        //foreach (RaycastResult btn in results)
        //{
        //    Debug.Log("Raycast hit: " + btn.gameObject.name);
        //}
    }

    //public void OnARButtonClick(BaseEventData data)
    //{
    //    if (data != null)
    //    {
    //        Debug.Log("Button Clicked: " + data.selectedObject.name);
    //    }
        
    //}

    public void increaseAmount()
    {
        currentAmount++;
        updateView();
    }

    public void decreaseAmount()
    {
        currentAmount--;
        updateView();
    }

    void updateView() {
        Debug.Log("update view called");
        tapText.text = "Amount: " + currentAmount.ToString();
    }
}
