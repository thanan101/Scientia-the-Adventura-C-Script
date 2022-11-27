using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3FindwayGetinRoom : AbstractQuest
{

    public override void DonotPlayThisQuestAgain()
    {
        StartCoroutine(delay());
        
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(6f);
        base.DonotPlayThisQuestAgain();
    }
}
