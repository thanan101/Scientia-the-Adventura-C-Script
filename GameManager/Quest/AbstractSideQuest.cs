using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractSideQuest : MonoBehaviour
{
    //public SideQuestTxt[] sideQuestTxt;
    //public SideQuestIcon[] sideQuestIcon;
    
    public SideQuestListEnum sideQuestID;
    [SerializeField] [Tooltip("ลากเกมObjectที่เกี่ยวของมาใส่")] public GameObject[] sideQuestGameObj;
    private void Awake()
    {
        
         //sideQuestIcon = FindObjectsOfType<SideQuestIcon>();
         //sideQuestTxt = FindObjectsOfType<SideQuestTxt>();
        
    }
    public virtual void Start()
    {
        StartCoroutine(StandbyCheack());
    }
    public virtual void Update()
    {
        
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (QuestManager.Instance.sideQuestsList[(int)sideQuestID].complete == false && collision.tag == "Player")
        {
            QuestTrigger();
        }
        else if (collision.tag == "Player"&& QuestManager.Instance.sideQuestsList[(int)sideQuestID].complete == true)
        {
            DonotPlayThisQuestAgain();
        }
    }
    public void QuestTrigger()
    {
        Debug.Log("SideQuest"+sideQuestID.ToString()+"Start");
        //SetTextSideQuest();
    }
    public virtual void QuestComplete()
    {
        Debug.Log("SideQuest" + sideQuestID.ToString() + "Complete");
        QuestManager.Instance.sideQuestsList[(int)sideQuestID].complete = true;
        //ResetTextSideQuestComplete();
        DonotPlayThisQuestAgain();       
    }
    public virtual void DonotPlayThisQuestAgain()
    {
        Debug.Log("SideQuest" + sideQuestID.ToString() + "Complete");
        for (int i = 0; i < sideQuestGameObj.Length; i++)
        {
            if (sideQuestGameObj[i] != null)
            {
                Destroy(sideQuestGameObj[i]);
            }
        }

        Destroy(gameObject);
    }
    IEnumerator StandbyCheack()
    {
        yield return new WaitForSeconds(1.5f);
        /*for (int i = 0; i < sideQuestTxt.Length; i++)
        {
            while(sideQuestTxt[i].textSideQuest.text== "สำเร็จแล้ว!...")
            {
                sideQuestTxt[i].textSideQuest.text = "";
                Debug.Log("COunt");
            }
        }
        yield return new WaitForSeconds(2f);*/
        if (QuestManager.Instance.sideQuestsList[(int)sideQuestID].complete == true)
        {
            DonotPlayThisQuestAgain();
            //ResetTextSideQuestComplete();
        }
    }
    public virtual void SetTextSideQuest()
    {
        /*int i = 0;
        do
        {
            if (textSideQuestList[i].text !="")
            {
                i++;
            }
            if (textSideQuestList[i].text==""&& 
                textSideQuestList[i].text!= QuestManager.Instance.sideQuestsList[(int)sideQuestID].sideQuestName)
            {
                iconSideQuest[i].SetActive(true);
                textSideQuestList[i].text = QuestManager.Instance.sideQuestsList[(int)sideQuestID].sideQuestName;
            }
            i++;
        } while (textSideQuestList[i].text!=""&&i<textSideQuestList.Length);
           */
        /*
        int i = 0;
        do
        {
            sideQuestTxt[i].textSideQuest.text = QuestManager.Instance.sideQuestsList[(int)sideQuestID].sideQuestName;
            sideQuestIcon[i].imageicon.enabled = true;
            i++;
        }
        while (sideQuestTxt[i].textSideQuest.text != ""); */
    }
    public virtual void ResetTextSideQuestComplete()
    {
        /*
        for (int i = 0; i < sideQuestTxt.Length; i++)
        {
            while (sideQuestTxt[i].textSideQuest.text == QuestManager.Instance.sideQuestsList[(int)sideQuestID].sideQuestName)
            {
                sideQuestTxt[i].textSideQuest.text = "";
                sideQuestIcon[i].imageicon.enabled = false;
                //StartCoroutine(Standby());
            }
        }
        */
    }
}
