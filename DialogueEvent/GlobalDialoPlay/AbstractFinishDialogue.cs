using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFinishDialogue : MonoBehaviour
{

    AbstractDialoguePlay dialoguePlay;
    [SerializeField] List<GameObject> setEnableQuestObj;
    public virtual void OnDisable()
    {
        if (setEnableQuestObj != null)
        {
            for (int i = 0; i < setEnableQuestObj.Count; i++)
            {

                setEnableQuestObj[i].SetActive(true);
            }
        }      
        dialoguePlay = GetComponentInParent<AbstractDialoguePlay>();
        if (dialoguePlay != null)
        {
            dialoguePlay.ShowOtherUI();
            dialoguePlay.DestroyDilogueOBJ();
            Player.Instance.PlayerCanMove();
            CompleteDialogueEv.Instance.DialogueComplete[(int)dialoguePlay.name_Dialogue] = true;
        }
    }
}
