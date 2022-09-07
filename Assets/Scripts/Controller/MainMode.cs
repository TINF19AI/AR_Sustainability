using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainMode : MonoBehaviour
{
    [SerializeField] GameObject gridSpawner;

    [SerializeField] Text guessText;
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
        gridSpawner.GetComponent<CupGrid>().SetCupAmount(currentAmount);

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

    public void SliderChanged(System.Single value)
    {
        int cups = convertSliderToCup(value);
        Debug.Log("Converted " + value.ToString() + " to " + cups.ToString());
        gridSpawner.GetComponent<CupGrid>().SetCupAmount(cups);
        currentAmount = cups;
        UpdateView();

    }

    //}
    /// <summary>
    ///
    /// </summary>
    /// <param name="value">Float between 0 and 15</param>
    /// <returns>Amount of Cups</returns>
    int convertSliderToCup(System.Single value)
    {
        float result = Mathf.Pow(2.71828f, value+7)-1096f;
        return (int)Math.Round(result, 0);
    }

    public void SubmitGuess() {
        InteractionController.GetGlobalState()["guessedValue"] = currentAmount.ToString();
        InteractionController.EnableMode("result");
    }


    void UpdateView() {
        guessText.text = "Your Current Guess: " + currentAmount.ToString() + " Cups";
        
    }
}
