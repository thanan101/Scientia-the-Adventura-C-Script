using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationAmp : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.FindKeyAndHelpAMp].complete == true)
        {
            animator.SetBool("isNotHelp", false); 
        }
        else
            animator.SetBool("isNotHelp", true);
    }
}
