using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMode : MonoBehaviour
{
    public GameObject ImageTarget;
    private void OnEnable()
    {
        UIController.ShowUI("end");
        ImageTarget.SetActive(false);
        UAP_AccessibilityManager.SetLanguage("English");
    }

    public void OpenLink()
    {
        Application.OpenURL("https://studierendenwerk-ulm.de/studierendenwerk/nachhaltigkeit/#akkordeon-campusgastronomie");
    }

    public void ReturnToScan()
    {
        InteractionController.EnableMode("scan");
    }
}
