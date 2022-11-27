using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1Enable : MonoBehaviour
{
    [SerializeField]GameObject questHideformEnemy;
    private void Start()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        if(questHideformEnemy!=null)
            questHideformEnemy.SetActive(false);
    }
}
