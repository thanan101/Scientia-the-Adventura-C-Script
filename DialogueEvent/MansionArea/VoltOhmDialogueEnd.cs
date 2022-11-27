using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltOhmDialogueEnd : AbstractFinishDialogue
{
    [SerializeField] VoltOhmDialogue voltOhmDialog;
    public override void OnDisable()
    {
        voltOhmDialog.EndDialogue();
        base.OnDisable();
    }
}
