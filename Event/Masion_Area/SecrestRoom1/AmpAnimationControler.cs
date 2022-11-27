using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpAnimationControler : MonoBehaviour
{
    [SerializeField] GameObject baseObgAmp;
    Animator animator;
    private void Start()
    {
        DelayCheack();
    }
    IEnumerator DelayCheack()
    {
        yield return new WaitForEndOfFrame();
        if(QuestManager.Instance.questsList[(int)QuestListEnum.FindKeyAndHelpAMp].complete == true)
        {
            Destroy(baseObgAmp);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(QuestManager.Instance.questsList[(int)QuestListEnum.FindKeyAndHelpAMp].complete==true)
        {
            Destroy(baseObgAmp);
            animator.SetBool("isHelp", true); 
        }
        else
        {
            animator.SetBool("isHelp", false);
        }
    }
}
