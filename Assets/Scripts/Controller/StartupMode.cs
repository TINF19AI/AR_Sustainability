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
        arCamera.SetActive(false);
        UIController.ShowUI("startup");
        ImageTarget.SetActive(false);
    }

    public void ContinueApplication()
    {
        arCamera.SetActive(true);
        InteractionController.EnableMode("scan");
    }

    // Update is called once per frame
    void Update()
    {
        //VuforiaBehaviour.
    }
}
