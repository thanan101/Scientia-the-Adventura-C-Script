using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltOhmDialogue : MonoBehaviour
{
    [SerializeField]DialoguePlayist dialogue12o1;
    [SerializeField] GameObject cameraEvVoltAndOhm;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject npcEv12o1;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Player"&&CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event12o1] == true)
            Destroy(gameObject);
        else if (collision.tag == "Player" && CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event12o2] == true)
        {
            npcEv12o1.SetActive(true);
            cameraEvVoltAndOhm.SetActive(true);
            mainCamera.enabled = false;
            dialogue12o1.TrigerPlaylist();

        }
    }
    public void EndDialogue()
    {
        npcEv12o1.SetActive(false);
        cameraEvVoltAndOhm.SetActive(false);
        mainCamera.enabled = true;
    }

}
