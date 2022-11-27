using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogeEx1 : MonoBehaviour
{
    [SerializeField]DialoguePlayist Ev13Ex2;
    private void OnDisable()
    {
        Ev13Ex2.TrigerPlaylist();
    }
}
