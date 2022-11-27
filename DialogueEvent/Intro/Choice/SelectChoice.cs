using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChoice : MonoBehaviour
{
    [SerializeField] DialoguePlayist choice1;
    [SerializeField] DialoguePlayist choice2;
    [SerializeField] GameObject DialogueUI;
    [SerializeField] GameObject blackScene;
    [SerializeField] GameObject panelChoice;
    private void OnEnable()
    {
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        yield return new WaitForEndOfFrame();
        DialogueUI.SetActive(true);
        
    }
    public void PlayDialogueA()
    {
        CloseChoice();
        choice1.TrigerPlaylist();
        StartCoroutine(BlackSecene());
    }
    public void PlayDialogueB()
    {
        CloseChoice();
        choice2.TrigerPlaylist();
        StartCoroutine(BlackSecene());
    }
    IEnumerator BlackSecene()
    {
        yield return new WaitForSecondsRealtime(3f);
        blackScene.SetActive(false);
    }
    void CloseChoice()
    {
        panelChoice.SetActive(false);
    }
}
