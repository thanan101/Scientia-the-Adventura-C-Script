using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRoomFinish : MonoBehaviour
{
        [SerializeField] GameObject baseCapsule;
        AiRoomDialog aiRoomDL;

        private void OnDisable()
        {
            aiRoomDL = FindObjectOfType<AiRoomDialog>();
            GameManager.Instance.EnableUIDisplay(true);
            Destroy(baseCapsule);
            Player.Instance._canMove = true;
            CompleteDialogueEv.Instance.DialogueComplete[0] = true;
        }
}
