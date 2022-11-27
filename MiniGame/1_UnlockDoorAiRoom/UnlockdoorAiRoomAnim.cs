using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockdoorAiRoomAnim : MonoBehaviour
{
    Animator _anim;
    PuzzleUnlcockdoorAiRoom _puzzleUnlcockdoor;
    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _puzzleUnlcockdoor = gameObject.GetComponentInParent<PuzzleUnlcockdoorAiRoom>();
    }

    public void KnotAnim()
    {
        _anim.SetTrigger("OpenKnot");
        
    }
    public void CoverOpen()
    {
        _anim.SetTrigger("OpenCover");
    }
    public void ScrewDone()
    {
        _puzzleUnlcockdoor.UnscrewCount();
    }
}
