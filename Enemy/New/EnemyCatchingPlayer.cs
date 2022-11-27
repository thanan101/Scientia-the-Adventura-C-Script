using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatchingPlayer : MonoBehaviour
{
    EnemyScript enemyScript;
    float ogMoveEmSpeed;
    public bool seePlayer;
    private void Start()
    {
        enemyScript = GetComponentInParent<EnemyScript>();
        ogMoveEmSpeed = enemyScript.moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (enemyScript.enemyIsSlowNow == false)
            {
                StopAllCoroutines();
                AleartenemyIcon.Instance.OpenAleartEnemyIcon();
                SoundFxManager.Instance.CatchinEnemy(true);
                enemyScript.moveSpeed = enemyScript.moveSpeed + 3;
                seePlayer = true;
            }
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AleartenemyIcon.Instance.CloseAleartEnemyIcon();
            StartCoroutine(StopEnemyMusic());
            enemyScript.moveSpeed = ogMoveEmSpeed;
            seePlayer = false;
        }
            
    }
    IEnumerator StopEnemyMusic()
    {
        yield return new WaitForSecondsRealtime(3f);
        SoundFxManager.Instance.CatchinEnemy(false);
    }
}
