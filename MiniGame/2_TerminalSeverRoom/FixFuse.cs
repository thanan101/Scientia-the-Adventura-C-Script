using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixFuse : MonoBehaviour
{
    [SerializeField] int BoxFuseID;
    [SerializeField] TerminalSeverRoom terminalPuzzleSeverroom;
    public void InsertFuse()
    {
        terminalPuzzleSeverroom.UseFuseForFix(BoxFuseID);
    }
    public void Done()
    {
        Destroy(gameObject);
    }

    



}
