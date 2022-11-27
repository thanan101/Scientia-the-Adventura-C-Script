using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectNew : MonoBehaviour
{
    [SerializeField] Transform _enemy;
    EnemyScript enemyScript;
    SurpriseEnemy surpriseEnemyScript;
    public bool enemyHitFlashLight=false;
    [SerializeField] float catchingTime=2.5f;
    bool hitPlayer=false;
    private void Start()
    {
        enemyScript = GetComponentInParent<EnemyScript>();
        surpriseEnemyScript = GetComponentInParent<SurpriseEnemy>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FlashLight")
        {
            AleartenemyIcon.Instance.OpenAleartEnemyIcon();
            enemyHitFlashLight = true;
        }
        if (collision.tag == "Player")
        {
            
            enemyHitFlashLight = false;
            //Debug.Log(collision);
            if (Player.Instance._buffImmue == 0)
            {
                hitPlayer = true;
                GameManager.Instance._enemyKillPlayer = true;
                Player.Instance.PlayerCanNotMove();
                AleartenemyIcon.Instance.OpenAleartEnemyIcon();
                GameManager.Instance.EnableUIDisplay(false);
                if (enemyScript != null)
                {
                    enemyScript.EnemyDetectPlayer();
                    enemyScript.MoveTowardToPlayer();
                }
                    
                else if (surpriseEnemyScript != null)
                    surpriseEnemyScript.EnemyDetectPlayer();
                //ใส่เสียงแจ้งเตือน
            }
            else if (Player.Instance._buffImmue == 1)
            {
                /*float xPos = _enemy.transform.position.x - 20;
                float yPos = _enemy.transform.position.y;
                float zPos = _enemy.transform.position.z;

                int randomValueOperator = Random.Range(1, 3);
                if (randomValueOperator > 1)
                {
                    xPos = _enemy.transform.position.x + 20;
                }
                _enemy.transform.position = new Vector3(xPos, yPos, zPos);

                Player.Instance._buffImmue = 0;*/
                enemyScript.SlowDownEnemy(true);
                StartCoroutine(CountDonwSpeed());
            }
        }
    }
    IEnumerator CountDonwSpeed()
    {
        yield return new WaitForSeconds(2.5f);
        enemyScript.SlowDownEnemy(false);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FlashLight")
        {
            AleartenemyIcon.Instance.CloseAleartEnemyIcon();
            if (hitPlayer == false)
                StartCoroutine(CatchingPlayer());
        }
            
    }
    IEnumerator CatchingPlayer()
    {
        yield return new WaitForSeconds(catchingTime);
        enemyHitFlashLight = false;
    }
}
