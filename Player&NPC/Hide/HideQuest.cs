using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideQuest : PlayerHide
{
    SideQuest2FindHidespot sideQuest2;
    Quest2Dontdie quest2;
    private bool questDon = false;
    public override void Start()
    {
        if (QuestManager.Instance.questsList[1].complete == false)
        {
            sideQuest2 = FindObjectOfType<SideQuest2FindHidespot>();
            quest2 = FindObjectOfType<Quest2Dontdie>();
        }
        
        base.Start();
    }
    public override void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (questDon == false)
            {
                if (QuestManager.Instance.questsList[1].complete == false)
                {
                    sideQuest2.QuestComplete();
                    quest2.QuestComplete();
                    questDon = true;
                }
                
            }
            base.OnTriggerStay2D(collision);
        }
        
        
    }
}
