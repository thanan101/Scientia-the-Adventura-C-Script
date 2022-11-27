using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuBGM : MonoBehaviour
{
    [SerializeField] AudioSource bgmMainMenu;
    [SerializeField] float delayTime = 2f;
    void Start()
    {
        StartCoroutine(DelayPlay());
    }
    IEnumerator DelayPlay()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        bgmMainMenu.Play();
    }

}
