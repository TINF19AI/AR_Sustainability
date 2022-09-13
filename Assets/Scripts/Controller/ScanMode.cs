using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ScanMode : MonoBehaviour
{
    [SerializeField] GameObject ImageTarget;
    DefaultObserverEventHandler imageTargetEventHandler;

    // called when setactive(true) called
    void OnEnable()
    {
        UIController.ShowUI("scan");
        imageTargetEventHandler = ImageTarget.GetComponent<DefaultObserverEventHandler>();
        imageTargetEventHandler.OnTargetFound.AddListener(ImageFound);
        ImageTarget.SetActive(true);
        //UIController.SetHelpButtonVisible(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImageFound()
    {
        Debug.Log("Image Found!");
        imageTargetEventHandler.OnTargetFound.RemoveAllListeners();
        InteractionController.EnableMode("main");
    }
}
