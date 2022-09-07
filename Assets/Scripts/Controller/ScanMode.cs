using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanMode : MonoBehaviour
{
    [SerializeField] GameObject ImageTarget;

    // called when setactive(true) called
    void OnEnable()
    {
        UIController.ShowUI("scan");
        ImageTarget.SetActive(true);
        //UIController.SetHelpButtonVisible(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImageFound()
    {
        InteractionController.EnableMode("main");
    }
}
