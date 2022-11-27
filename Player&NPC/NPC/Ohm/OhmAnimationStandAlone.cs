using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhmAnimationStandAlone : MonoBehaviour
{
    Animator animator;
    public bool isInCapsule = false;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("inCapsule", isInCapsule);
    }
    public void PlayAnimationTeleport()
    {
        animator.SetTrigger("isTeleport");
    }

}
