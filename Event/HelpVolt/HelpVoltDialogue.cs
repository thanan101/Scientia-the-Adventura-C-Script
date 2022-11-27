using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpVoltDialogue : MonoBehaviour
{
    GameObject cameraVolt;
    public void SetCamera(GameObject gameObject)
    {
        cameraVolt = gameObject;
    }
    private void OnDestroy()
    {
        cameraVolt.SetActive(false);
        Quest6HelpVolt quest6HelpVolt = FindObjectOfType<Quest6HelpVolt>();
        quest6HelpVolt.QuestComplete();
    }
}
