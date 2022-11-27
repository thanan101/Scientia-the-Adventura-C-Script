using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] AudioSource _diedFx;
    [SerializeField] float delayTime=2;
    private void Start()
    {
        StartCoroutine(delaySound());
    }
    IEnumerator delaySound()
    {
        yield return new WaitForSeconds(delayTime);
        _diedFx.Play();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            sceneManager.Instance.goMainMenu();
        }
        
    }
}
