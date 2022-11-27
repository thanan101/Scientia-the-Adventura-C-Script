using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopEnemyControl : MonoBehaviour
{
    [SerializeField] GameObject thisEnemy;
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] float delayStandEnemy = 3f;
    int comeDirection;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            comeDirection = enemyScript.direction;
            enemyScript.direction = 0;
            StartCoroutine(DelayUtuneEnemy());
        }
    }
    IEnumerator DelayUtuneEnemy()
    {
        yield return new WaitForSeconds(delayStandEnemy);
        if (comeDirection == -1)
            enemyScript.direction = 1;
        else if (comeDirection == 1)
            enemyScript.direction = -1;
    }
}
