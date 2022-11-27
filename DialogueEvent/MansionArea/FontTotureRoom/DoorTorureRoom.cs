using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTorureRoom : AbstractDoor
{
    [SerializeField]DialoguePlayist Ev13o1;
    public override void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Player"&&CompleteDialogueEv.Instance.DialogueComplete
            [(int)dialogueNameList.Event1301FoundAmp]==true
            &&Input.GetKeyDown(KeyCode.E))
            base.OnTriggerStay2D(collision);
        else if (collision.tag == "Player" && CompleteDialogueEv.Instance.DialogueComplete
            [(int)dialogueNameList.Event1301FoundAmp] == false
            && Input.GetKeyDown(KeyCode.E))
        {
            Ev13o1.TrigerPlaylist();
        }

    }
    public void GetInRoom()
    {
        TeleportPlayer();
    }

}
