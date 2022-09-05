using System.Collections;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
public class InteractionModeDictionary : SerializableDictionaryBase<string, GameObject> { }

public class InteractionController : Singleton<InteractionController>
{
    [SerializeField]
    InteractionModeDictionary interactionModes;
    GameObject currentMode;

    protected override void Awake()
    {
        base.Awake();
        ResetAllModes();
    }

    void Start()
    {
        _EnableMode("startup");
    }

    void ResetAllModes()
    {
        foreach (GameObject mode in interactionModes.Values)
        {
            mode.SetActive(false);
        }
    }

    /// <summary>
    /// other scripts can call InteractionController.EnableMode(modename);
    /// </summary>
    /// <param name="name"></param>
    public static void EnableMode(string name)
    {
        Debug.Log("enable mode called: " + name);
        Instance?._EnableMode(name);
    }

    void _EnableMode(string name)
    {
        GameObject modeObject;
        if (interactionModes.TryGetValue(name, out modeObject))
        {
            // coroutine is used to allow current mode extra frame to be disabled before activating new one
            StartCoroutine(ChangeMode(modeObject)); 
        }
        else
        {
            Debug.LogError("undefined mode named " + name);
        }
    }

    IEnumerator ChangeMode(GameObject mode)
    {
        if (mode == currentMode)
            yield break;

        if (currentMode)
        {
            currentMode.SetActive(false);
            yield return null;
        }

        currentMode = mode;
        mode.SetActive(true);
    }

}