using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieGameover : MonoBehaviour
{
    [SerializeField] GameObject dieBlackScreenByEnemy;
    [SerializeField] float delayTime = 1f;
    public void PlayerDie()
    {
        StartCoroutine(BlackScreenDieByEnemy());
    }
    IEnumerator BlackScreenDieByEnemy()
    {
        yield return new WaitForSeconds(delayTime);
        dieBlackScreenByEnemy.SetActive(true);
    }
}
