using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3Finish : MonoBehaviour
{
    Quest3FindwayGetinRoom quest3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        quest3 = FindObjectOfType<Quest3FindwayGetinRoom>();
        if(quest3!=null)
            quest3.QuestComplete();
    }
}
