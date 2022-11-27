using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrigerExamDialog : MonoBehaviour
{
    [SerializeField] DialoguePlayist dialoguePlayist_Exam;
    [SerializeField] GameObject bg2;
    [SerializeField] public Image blackScreen;
    IntroDialogue introDialogueScirpt;
    [SerializeField] AudioSource bgm_ExamDay;
    public float delayTime = 3f;
    private void Awake()
    {
        introDialogueScirpt = GetComponent<IntroDialogue>();
    }
    private void Start()
    {
        
    }
    public void PlayExamDialogue()
    {
        blackScreen.enabled = true;
        introDialogueScirpt.bgm_Backstory.Stop();
        bgm_ExamDay.Play();
        StartCoroutine(PlaynextDialogue());
    }
    public IEnumerator  PlaynextDialogue()
    {
        yield return new WaitForSeconds(delayTime);
        blackScreen.enabled = false;        
        bg2.SetActive(true);
        dialoguePlayist_Exam.TrigerPlaylist();

    }
}
