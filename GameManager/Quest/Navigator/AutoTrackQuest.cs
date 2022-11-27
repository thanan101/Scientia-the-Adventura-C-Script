using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTrackQuest : MonoBehaviour
{
    /*bool quest1;
    bool quest2;
    bool quest3;
    bool quest4;
    bool quest5;
    bool quest6;
    bool quest7;
    bool quest8;
    bool quest9;
    bool quest10;*/

    [SerializeField] Quest1GetoutFormThisRoom _quest1;
    [SerializeField] Quest2Dontdie _quest2;
    [SerializeField] Quest3FindwayGetinRoom _quest3;
    [SerializeField] Quest4HelpOhm _quest4;
    [SerializeField] Quest5HelpWatt _quest5;
    [SerializeField] Quest6HelpVolt _quest6;
    [SerializeField] Quest7Explore1F _quest7;
    [SerializeField] Quest8FindAndHelpAmp _quest8;
    [SerializeField] Quest9FindKeyHelpAmp _quest9;
    [SerializeField] Quest10FindVoltAndKeyEmblem _quest10;
    
    
    IEnumerator GetValueQuest()
    {
        yield return new WaitForEndOfFrame();
        /*quest1 = QuestManager.Instance.questsList[0].complete;
        quest2 = QuestManager.Instance.questsList[1].complete;
        quest3 = QuestManager.Instance.questsList[2].complete;
        quest4 = QuestManager.Instance.questsList[3].complete;
        quest5 = QuestManager.Instance.questsList[4].complete;
        quest6 = QuestManager.Instance.questsList[5].complete;
        quest7 = QuestManager.Instance.questsList[6].complete;
        quest8 = QuestManager.Instance.questsList[7].complete;
        quest9 = QuestManager.Instance.questsList[8].complete;
        quest10 = QuestManager.Instance.questsList[9].complete;*/
    }
    IEnumerator CheackRemainQuest()
    {
        yield return new WaitForSeconds(6f);
        /*if(quest1 == true && quest2 == true && quest2 == true && quest3 == true && 
            quest4 == true && quest5 == true && quest6 == true && quest7 == true && quest8 == true
            &&quest9==true)
        {
            _quest10.QuestTrigger();
        }
        else if (quest1 == true && quest2 == true && quest2 == true && quest3 == true &&
            quest4 == true && quest5 == true && quest6 == true && quest7 == true && quest8 == true
            && quest9 == false)
        {
            _quest9.QuestTrigger();
        }
        else if (quest1 == true && quest2 == true && quest2 == true && quest3 == true &&
            quest4 == true && quest5 == true && quest6 == true && quest7 == true && quest8 == false
            && quest9 == false)
        {
            _quest8.QuestTrigger();
        }*/
        int i = 0;
        while (QuestManager.Instance.questsList[i].complete == true)
        {
            i++;
        }
        if (i == 0&&_quest1!=null)
            _quest1.QuestTrigger();
        else if (i == 1 && _quest2 != null)
            _quest2.QuestTrigger();
        else if (i == 2 && _quest3 != null)
            _quest3.QuestTrigger();
        else if (i == 3 && _quest4 != null)
            _quest4.QuestTrigger();
        else if (i == 4 && _quest5 != null)
            _quest5.QuestTrigger();
        else if (i == 5 && _quest6 != null)
            _quest6.QuestTrigger();
        else if (i == 6 && _quest7 != null)
            _quest7.QuestTrigger();
        else if (i == 7 && _quest8 != null)
            _quest8.QuestTrigger();
        else if (i == 8 && _quest9 != null)
            _quest9.QuestTrigger();
        /*else if (i == 9 && _quest10 != null)
            _quest10.QuestTrigger();*/
        else
        {

        }
    }
    private void Start()
    {
        StartCoroutine(CheackRemainQuest());
    }
}
