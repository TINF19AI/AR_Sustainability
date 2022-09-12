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
    }

    public void OpenLink()
    {
        Application.OpenURL("https://studierendenwerk-ulm.de/studierendenwerk/nachhaltigkeit/#akkordeon-campusgastronomie");
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
