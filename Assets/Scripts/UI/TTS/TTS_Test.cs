using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTS_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        UAP_AccessibilityManager.SetLanguage("English");
        Debug.Log("OnEnable Called");
    }

    public void TTS_Test_Function()
    {
        // UAP_AccessibilityManager.EnableAccessibility(true, true);
        Debug.Log("TTS_Test_Function Called_Before");
        UAP_AccessibilityManager.Say("Test");
        Debug.Log("TTS_Test_Function Called");
        // UAP_AccessibilityManager.EnableAccessibility(false, true);
    }
}
