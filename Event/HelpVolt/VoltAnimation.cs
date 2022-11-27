using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltAnimation : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpVolt].complete == true)
        {
            animator.SetTrigger("isHelp");

        }
    }
    public void SetVoltAnimation()
    {
        animator.SetTrigger("isHelp");
    }
}
