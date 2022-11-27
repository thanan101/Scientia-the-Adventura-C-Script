using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiRoomDialog : MonoBehaviour
{
    DialoguePlayist dialoguePlayist;
    [SerializeField]GameObject fadeblackScreen;
    [SerializeField] GameObject uiDialog;
    [SerializeField] GameObject[] allDialogueGameOG;
    public dialogueNameList name_Dialogue;

    [SerializeField] GameObject QuestionUI;
    [SerializeField] Text Anwser1;
    [SerializeField] Text Anwser2;
    [SerializeField] DialoguePlayist answer1_Class;
    [SerializeField] DialoguePlayist answer2_Class;
    public string textAnswer1;
    public string textAnswer2;

    void Start()
    {
        if(CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.SecretReserch]==false)
            StartCoroutine(Delay2());


    }
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(4f);
        fadeblackScreen.SetActive(false);
        dialoguePlayist.TrigerPlaylist();
    }
    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(0.1f);

        cheack();
    }
    void cheack()
    {

        if (CompleteDialogueEv.Instance.DialogueComplete[(int)name_Dialogue] == true)
        {
            for (int i = 0; i < allDialogueGameOG.Length; i++)
            {
                Destroy(allDialogueGameOG[i]);
            }
            Destroy(gameObject);
        }
        else if (CompleteDialogueEv.Instance.DialogueComplete[(int)name_Dialogue] == false)
        {
            GameManager.Instance.EnableUIDisplay(false);
            fadeblackScreen.SetActive(true);
            Player.Instance._canMove = false;
            dialoguePlayist = GetComponent<DialoguePlayist>();
            uiDialog.SetActive(true);
            fadeblackScreen.SetActive(true);
            StartCoroutine(Delay());
        }
    }
    public void Question()
    {
        uiDialog.SetActive(true);
        QuestionUI.SetActive(true);
        Anwser1.text = textAnswer1;
        Anwser2.text = textAnswer2;
        StartCoroutine(DealayCloseUI());
    }
    IEnumerator DealayCloseUI()
    {
        yield return new WaitForEndOfFrame();
        GameManager.Instance.EnableUIDisplay(false);
        Player.Instance.PlayerCanNotMove();
    }
    public void SelectAnswerA(int idQuestion )
    {
        answer1_Class.TrigerPlaylist();
        CompleteDialogueEv.Instance.QuestionComplete[idQuestion] = true;
        QuestionUI.SetActive(false);
    }
    public void SlectAnswerB(int idQuestion)
    {
        answer2_Class.TrigerPlaylist();
        CompleteDialogueEv.Instance.QuestionComplete[idQuestion] = true;
        QuestionUI.SetActive(false);
    }
    public void ShowOtherUI()
    {
        GameManager.Instance.EnableUIDisplay(true);
    }

}
