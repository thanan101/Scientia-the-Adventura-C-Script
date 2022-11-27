using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDialoguePlay : MonoBehaviour
{
    public dialogueNameList name_Dialogue;
    [SerializeField] GameObject[] allDialogueGameOG;
    DialoguePlayist dialoguePlayist;//ที่เดียวกันไม่ต้องลากมาใส่

    private void Start()
    {
        dialoguePlayist = GetComponent<DialoguePlayist>();
        
        StartCoroutine(CheackFormStart());

    }
    IEnumerator CheackFormStart()
    {
        yield return new WaitForSeconds(1f);
        cheackLoad();
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cheack();
        }
    }
    public virtual void cheack()
    {
        if (CompleteDialogueEv.Instance.DialogueComplete[(int)name_Dialogue] == true)
        {
            DestroyDilogueOBJ();
        }
        else if (CompleteDialogueEv.Instance.DialogueComplete[(int)name_Dialogue] == false)
        {
            Player.Instance.PlayerCanNotMove();
            //uiDialog.SetActive(true);
            //fadeblackScreen.SetActive(true);
            //StartCoroutine(Delay());
            GameManager.Instance.EnableUIDisplay(false);
            dialoguePlayist.TrigerPlaylist();
        }

    }
    public virtual void cheackLoad()
    {
        if (CompleteDialogueEv.Instance.DialogueComplete[(int)name_Dialogue] == true)
        {
            gameObject.SetActive(false);
        }

    }
    public void ShowOtherUI()
    {
        GameManager.Instance.EnableUIDisplay(true);
    }
    public void DestroyDilogueOBJ()
    {
        for (int i = 0; i < allDialogueGameOG.Length; i++)
        {
            Destroy(allDialogueGameOG[i]);
        }
        Destroy(gameObject);
    }
}
