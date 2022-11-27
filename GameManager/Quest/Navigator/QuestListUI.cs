using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListUI : MonoBehaviour
{
    [SerializeField]GameObject questListUI;

    /// <summary>
    private static QuestListUI _instance;
    public static QuestListUI Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("QuestListUI is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;

    }
    /// </summary>

    public void OpenQuestListUI()
    {
        questListUI.SetActive(true);
    }
    public void CloseQuestListUI()
    {
        questListUI.SetActive(false);
    }
}
