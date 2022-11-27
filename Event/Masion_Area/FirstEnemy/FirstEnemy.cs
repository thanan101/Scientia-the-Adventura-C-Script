using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    EnemyScript enemyScript;
    [SerializeField]BoxCollider2D boxCollider2D;
    bool dontUpdeteAgian = false;
    private void Start()
    {
        enemyScript = GetComponent<EnemyScript>();
        if (CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event8o2] == false)
        {
            enemyScript.enabled = false;
            boxCollider2D.enabled = false;
        }
            
    }
    private void Update()
    {
        if (CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event8o2] == true
            &&dontUpdeteAgian==false)
        {
            enemyScript.enabled = true;
            boxCollider2D.enabled = true;
            dontUpdeteAgian = true;
        }
    }
}
