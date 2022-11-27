using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpGameOver : AbstractFinishDialogue
{
    public override void OnDisable()
    {
        Player.Instance.PlayeDieAnimation();
        base.OnDisable();
    }
}
