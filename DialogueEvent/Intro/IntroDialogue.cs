using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroDialogue : MonoBehaviour
{
    [SerializeField]DialoguePlayist dialoguePlayist_Past;
    [SerializeField] Image blackScreen;
    [SerializeField] GameObject bg1;
    [SerializeField] public AudioSource bgm_Backstory;
    void Start()
    {
        bg1.SetActive(true);
        StartCoroutine(count());
        bgm_Backstory.Play();
    }
    IEnumerator count()
    {
        yield return new WaitForSeconds(0.1f);

        blackScreen.enabled = false;
        dialoguePlayist_Past.TrigerPlaylist();
    }
}
