using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squest3Done : MonoBehaviour
{
    SideQuest3GetinServerRoom sideQuest3;
    private void Start()
    {
        sideQuest3 = GetComponentInParent<SideQuest3GetinServerRoom>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sideQuest3.QuestComplete();
        }
    }
}
