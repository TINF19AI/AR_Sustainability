using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMode : MonoBehaviour
{
    private void OnEnable()
    {
        UIController.ShowUI("end");
    }

    public void OpenLink()
    {
        Application.OpenURL("https://www.heidenheim.dhbw.de/dhbw-heidenheim/wir-ueber-uns/nachhaltige-hochschule");
    }

    public void ReturnToScan()
    {
        InteractionController.EnableMode("scan");
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
