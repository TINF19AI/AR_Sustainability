using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary; // from unity asset store
using DG.Tweening; // from unity asset store

[System.Serializable]
public class UIPanelDictionary : SerializableDictionaryBase<string, CanvasGroup> { }
// <UI panel name, reference to UI panel CanvasGroup component>

public class UIController : Singleton<UIController>
{
    [SerializeField] UIPanelDictionary uiPanels; // dict that contains ui panels
    CanvasGroup currentPanel; // currently active panel

    protected override void Awake()
    {
        base.Awake();
        ResetAllUI();
    }

    void ResetAllUI()
    {
        foreach (CanvasGroup panel in uiPanels.Values)
        {
            panel.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Another script can show a panel by calling UIController.ShowUI(panelname) without direct reference
    /// </summary>
    /// <param name="name"></param>
    public static void ShowUI(string name)
    {
        Instance?._ShowUI(name);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    void _ShowUI(string name)
    {
        CanvasGroup panel;
        if (uiPanels.TryGetValue(name, out panel))
        {
            ChangeUI(uiPanels[name]);
        }
        else
        {
            Debug.LogError("Undefined ui panel " + name);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="panel"></param>
    void ChangeUI(CanvasGroup panel)
    {
        if (panel == currentPanel)
            return;

        if (currentPanel)
            FadeOut(currentPanel);
        //currentPanel.gameObject.SetActive(false);

        currentPanel = panel;

        if (panel)
            FadeIn(panel);
        //panel.gameObject.SetActive(true);
    }

    void FadeIn(CanvasGroup panel)
    {
        panel.gameObject.SetActive(true);
        panel.DOFade(1f, 0.5f);
    }

    void FadeOut(CanvasGroup panel)
    {
        panel.DOFade(0f, 0.5f).OnComplete(() => panel.gameObject.SetActive(false));
    }
}



