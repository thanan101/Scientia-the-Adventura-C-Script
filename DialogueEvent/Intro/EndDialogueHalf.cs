using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogueHalf : MonoBehaviour
{
    TrigerExamDialog trigerExamDL;
    private void Start()
    {
        trigerExamDL = FindObjectOfType<TrigerExamDialog>();
    }
    private void OnDisable()
    {
        trigerExamDL.PlayExamDialogue();
    }
}
