using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChoice : MonoBehaviour
{
    [SerializeField] GameObject answerChoice;
    [SerializeField] GameObject blackScene;
    private void OnDisable()
    {
        answerChoice.SetActive(true);
        blackScene.SetActive(true);
    }
}
