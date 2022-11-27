using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFinishFoodRoom : AbstractFinishDialogue
{
    [SerializeField] GameObject quest8FindAndHelpAmp;
    public override void OnDisable()
    {
        quest8FindAndHelpAmp.SetActive(true);
        QuestManager.Instance.questsList[(int)QuestListEnum.Explore1F].complete = true;
        CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event11o1] = true;
        base.OnDisable();
    }
}
