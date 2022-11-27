using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRoomWrongChoice : MonoBehaviour
{
    

    private void OnDisable()
    {                
        Player.Instance._canMove = true;
        CompleteDialogueEv.Instance.DialogueComplete[0] = true;
        sceneManager.Instance.goGameover();
    }
}
