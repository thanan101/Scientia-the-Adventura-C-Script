using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    /// <summary>
    private static QuestManager _instance;
    public static QuestManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("QuestMaster is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;

    }
    /// </summary>

    //public int questID = 0;
    public List<Quests> questsList = new List<Quests>();
    public List<SideQuest> sideQuestsList = new List<SideQuest>();


    [SerializeField] private Text textQuestList;
    [SerializeField] private Text[] textSideQuestList;
    [SerializeField] private GameObject[] iconSideQuest;
    private void Start()
    {

    }
    private void ShowRemainQuest()
    {
        int i = 0;
        {
            i++;
            textQuestList.text = questsList[i].questName;
            if (questsList[i] == null)
                textQuestList.text = "";
            Debug.Log(i);
        } while (questsList[i].complete == true) ;
    }
}
