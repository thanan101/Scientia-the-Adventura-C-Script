using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAiRoom : MonoBehaviour
{
    AiRoomDialog aiRoomDL;
    private void OnDisable()
    {
        aiRoomDL = FindObjectOfType<AiRoomDialog>();
        aiRoomDL.Question();
        //Debug.Log("Run2");
    }
}
