using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipBTN : MonoBehaviour
{
    TrigerExamDialog trigerExamDL;
    private int skip =0;
    private void Start()
    {
        trigerExamDL = FindObjectOfType<TrigerExamDialog>();
    }
    public void SkipFunc()
    {
        skip++;
        if (skip == 1)
        {
            trigerExamDL.PlayExamDialogue();
        }
        else
        {

        }
    }
}

   
