using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class AbstractQuest : MonoBehaviour
{
    //public Quests quests;
    public string DefualtQuest = "สำรวจหาทางออกจากที่นี้";
    TextMainQuest textQuestList;
    public QuestListEnum questID;
    //bool questISStart = false;
    [SerializeField] [Tooltip("ลากเกมObjectที่เกี่ยวของมาใส่")] public GameObject[] questGameObj;
    private void Awake()
    {
        if (textQuestList == null)
            textQuestList = FindObjectOfType<TextMainQuest>();
    }
    public virtual void Start()
    {      
        StartCoroutine(StandbyCheack());
       
    }
    public virtual void Update()
    {
        /*if (questISStart == true && QuestManager.Instance.questsList[(int)questID]
            .complete == false)
        {
            textQuestList.mainQuestText.text = QuestManager.Instance.questsList[(int)questID].questName;
        }
        if (QuestManager.Instance.questsList[(int)questID].complete == true)
        {
            DonotPlayThisQuestAgain();
        }*/
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (QuestManager.Instance.questsList[(int)questID].complete == false&&collision.tag=="Player")
        {
            QuestTrigger();
        }
        else if (collision.tag == "Player" && QuestManager.Instance.questsList[(int)questID].complete == true)
        {
            DonotPlayThisQuestAgain();
        }
    }
    public void QuestTrigger()
    {
        Debug.Log("Quest "+questID.ToString()+" Start");
        //questISStart = true;
       textQuestList.mainQuestText.text = QuestManager.Instance.questsList[(int)questID].questName;
    }
    public virtual void QuestComplete()
    {
        QuestManager.Instance.questsList[(int)questID].complete = true;
        //questISStart = false;
        Debug.Log("Quest " + questID.ToString()+" Complete");
        textQuestList.mainQuestText.text = DefualtQuest;
        DonotPlayThisQuestAgain();
    }
    public virtual void DonotPlayThisQuestAgain()
    {
        for (int i = 0; i <questGameObj.Length; i++)
        {
            if (questGameObj[i] != null)
            {
                Destroy(questGameObj[i]);
            }
        }

        Destroy(this.gameObject);
    }
    IEnumerator StandbyCheack()
    {
        yield return new WaitForSeconds(2f);
        if (QuestManager.Instance.questsList[(int)questID].complete == true)
        {
            Debug.Log("Quest " + questID.ToString() + " Complete");
            DonotPlayThisQuestAgain();
            //Debug.Log("Ruunn");
        }

    }
}
