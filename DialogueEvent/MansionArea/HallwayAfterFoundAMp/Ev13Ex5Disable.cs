using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ev13Ex5Disable : MonoBehaviour
{
    [SerializeField] ExitMansion exitMansionScript;
    private void OnDisable()
    {
        exitMansionScript.AskGetOutNow();
        GameManager.Instance.EnableUIDisplay(false);
    }
}
