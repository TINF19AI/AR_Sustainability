using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class StartupMode : MonoBehaviour
{
    [SerializeField] string nextMode = "scan";
    [SerializeField] GameObject ImageTarget;

    void OnEnable()
    {
        UIController.ShowUI("startup");
        ImageTarget.SetActive(false);
        
    }

    public void ContinueApplication()
    {
        InteractionController.EnableMode("scan");
    }

    // Update is called once per frame
    void Update()
    {
        //VuforiaBehaviour.
    }
}
