using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest10FindVoltAndKeyEmblem : AbstractQuest
{
    bool isTriggerNow = false;
    private void Update()
    {
        if (GameManager.Instance.knowVoltisGone == true && isTriggerNow == false)
        {
            QuestTrigger();
            isTriggerNow = true;
        }
            
    }
}
