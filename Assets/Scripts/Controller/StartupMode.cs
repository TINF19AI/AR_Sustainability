using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class StartupMode : MonoBehaviour
{
    [SerializeField] string nextMode = "scan";
    [SerializeField] GameObject ImageTarget;
    public GameObject arCamera;

    void OnEnable()
    {
        //UIController.SetHelpButtonVisible(false, false);
        UIController.ShowUI("startup");
        ImageTarget.SetActive(false);
        UAP_AccessibilityManager.SetLanguage("English");
    }

    public void ContinueApplication()
    {
        InteractionController.EnableMode("scan");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
