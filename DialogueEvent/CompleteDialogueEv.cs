using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum dialogueNameList
{
    SecretReserch,
    Event1,
    Event2,
    Event3A,
    Event3B,
    Event4,
    Even5o1,
    Event5o2,
    Event5o3,
    Event5o4EXGameOver,
    Event5o5SaveWatt,
    Event6o1,
    Event6o2,
    Event7o1,
    Event7o2,
    Event7o3,
    Event8o1,
    Event8o2,
    Event8o3,
    Event9,
    Event10,
    Event11o1,
    Event11o2,
    Event12o1,
    Event12o2,
    Event1301FoundAmp,
    Event1302,
    Event1303,
    Event1304,
    EventHelpAmp,
}
public enum QuestionDL
{
    SecretReserchAiRoom
}
public class CompleteDialogueEv : MonoBehaviour
{
    /// <summary>
    private static CompleteDialogueEv _instance;
    public static CompleteDialogueEv Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("CompleteDialogueEv is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>
    /// 
   
    public List<bool> DialogueComplete =new List<bool>();
    public List<bool> QuestionComplete = new List<bool>();
}
