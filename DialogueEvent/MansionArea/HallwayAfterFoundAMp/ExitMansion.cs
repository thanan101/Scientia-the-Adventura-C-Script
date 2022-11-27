using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMansion : MonoBehaviour
{
    [SerializeField] GameObject findEmblemText;
    [SerializeField] GameObject getOutNowAwnser;
    [SerializeField] DialoguePlayist badEndDialogue1;
    [SerializeField] DialoguePlayist badEndDialogue2;//ไม่ได้ใช้แล้ว
    [SerializeField] DialoguePlayist goodEndDialogue;
    [SerializeField] DialoguePlayist dialogEx5;//ถ้าหากโวลถูกจับไปจริงๆ
    [SerializeField] DialoguePlayist dialogEx3;
    [SerializeField] EndingTrigger endingTriggerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.OpenSreachIcon();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.CloseSreachIcon();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (collision.tag == "Player" && InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyEmblem1] == true &&
            InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyEmblem2] == true)
            {
                //dialogEx5.TrigerPlaylist();
                AskGetOutNow();
            }
            else if (collision.tag == "Player" && InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyEmblem1] == false ||
                collision.tag == "Player" && InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyEmblem2] == false)
            {
                findEmblemText.SetActive(true);
            }
        }
        
    }
    public void BadEndWontGoSaveFriend()
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.FindAndHelpAmp].complete == false)
        {
            badEndDialogue2.TrigerPlaylist();
        }
        else if(InventoryManager.Instance.gotItem[(int)ItemListEnum.Diary1]==true&&
            InventoryManager.Instance.gotItem[(int)ItemListEnum.Diary2] == true &&
            InventoryManager.Instance.gotItem[(int)ItemListEnum.Diary3] == true)
        {
            //badEndDialogue2.TrigerPlaylist();
            /////////ใส่เป็น GoodEnd แทน
            goodEndDialogue.TrigerPlaylist();
        }
        else
        {
            badEndDialogue1.TrigerPlaylist();
        }
    }
    public void PlayDialogGoFindFriend()
    {
        dialogEx3.TrigerPlaylist();
    }
    public void GameOver()
    {
        Player.Instance.PlayeDieAnimation();
    }
    public void AskGetOutNow()
    {
        getOutNowAwnser.SetActive(true);
        endingTriggerScript = GetComponent<EndingTrigger>();
        endingTriggerScript.EndingEvTrigger();
    }

}
