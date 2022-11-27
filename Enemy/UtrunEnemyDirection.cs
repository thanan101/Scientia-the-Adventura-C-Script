using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtrunEnemyDirection : MonoBehaviour
{
    [SerializeField] EnemyRobot _enemyRobot;
    [SerializeField] Animator _spriteAnimatorEnemy;
    [SerializeField] float _enemyStandbyDelayUtrun=3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (_enemyRobot.direction >= 0)
            {
                _spriteAnimatorEnemy.SetBool("isWalking", false);
                StartCoroutine(ChangeDirectionToLeft());
            }
            else if (_enemyRobot.direction <= 0)
            {
                _spriteAnimatorEnemy.SetBool("isWalking", false);
                StartCoroutine(ChangeDirectionToRight());
            }
        }
        
    }
    IEnumerator ChangeDirectionToLeft()
    {
        yield return new WaitForSeconds(_enemyStandbyDelayUtrun);
        _enemyRobot.direction = -1;
    }
    IEnumerator ChangeDirectionToRight()
    {
        yield return new WaitForSeconds(_enemyStandbyDelayUtrun);
        _enemyRobot.direction = 1;
    }
}
