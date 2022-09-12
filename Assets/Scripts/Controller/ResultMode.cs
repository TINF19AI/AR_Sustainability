using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultMode : MonoBehaviour
{
    public Text guessValueText;
    public Text correctValueText;
    public int correctValue;
    [SerializeField] GameObject gridSpawner;

    private void OnEnable()
    {
        string guessedValue = InteractionController.GetGlobalState()["guessedValue"];
        guessValueText.text = guessedValue;
        UIController.ShowUI("result");

        gridSpawner.GetComponent<CupGrid>().SetHighlightedCups(correctValue);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
