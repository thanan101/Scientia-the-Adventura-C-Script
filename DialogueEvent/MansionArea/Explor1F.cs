using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explor1F : AbstractDoor
{
    [SerializeField] DialoguePlayist dialogue9;

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.Explore1F].complete == true)
        {
            CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event9] = true;
            base.OnTriggerStay2D(collision);
        }
            
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogue9.TrigerPlaylist();
            }
        }
        
    }
}
