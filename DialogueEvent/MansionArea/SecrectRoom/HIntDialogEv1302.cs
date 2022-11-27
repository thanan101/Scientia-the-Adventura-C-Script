using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIntDialogEv1302 : AbstractFinishDialogue
{
    [SerializeField]Quest9FindKeyHelpAmp questFindKeyHelAmp;
    public override void OnDisable()
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.FindKeyAndHelpAMp].complete == false)
        {
            questFindKeyHelAmp.QuestTrigger();
            if (InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyTorTureRoom] == true)
                base.OnDisable();
        }
            
    }
}
