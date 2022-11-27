using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    [SerializeField] Transform _enemy;
    [SerializeField] Animator _animator;
    EnemyRobot enemyRobotScript;
    private void Start()
    {
        enemyRobotScript = GetComponentInParent<EnemyRobot>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            //Debug.Log(collision);
            if (Player.Instance._buffImmue == 0)
            {
                enemyRobotScript._rigibody1.Sleep();
                enemyRobotScript.direction = 0;
                Player.Instance.PlayerCanNotMove();
                AleartenemyIcon.Instance.OpenAleartEnemyIcon();
                GameManager.Instance.EnableUIDisplay(false);
                //ใส่เสียงแจ้งเตือน
                _animator.SetTrigger("Attacking");
            }
            else if(Player.Instance._buffImmue == 1)
            {
                float xPos = _enemy.transform.position.x - 20;
                float yPos = _enemy.transform.position.y;
                float zPos = _enemy.transform.position.z;

                int randomValueOperator = Random.Range(1, 3);
                if (randomValueOperator > 1)
                {
                    xPos = _enemy.transform.position.x + 20;
                }
                _enemy.transform.position = new Vector3(xPos, yPos, zPos);

                Player.Instance._buffImmue = 0;
            }
            
        }
        
    }
}
