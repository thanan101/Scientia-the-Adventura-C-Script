using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]public float moveSpeed = 2f;
    Rigidbody2D _rigibody1;
    public bool _flipSprite = true;
    [SerializeField] GameObject _sprite;
    [SerializeField] Animator _spriteAnimator;
    [SerializeField] Transform _searchLight_Deadzone;
    [SerializeField] Transform _catchingZone;
    public int direction = -1;
    EnemyDetectNew enemyDetect;

    int time = 0;
    public int maxtimeRandom = 5;
    public bool enemyIsSlowNow = false;
    void Start()
    {
        _rigibody1 = GetComponent<Rigidbody2D>();
        enemyDetect = GetComponentInChildren<EnemyDetectNew>();
    }
    private void OnEnable()
    {
        //StopAllCoroutines();
        //StartCoroutine(CouroutineAction());
        do
        {
            direction = Random.Range(-1, 2);//สุ่มทิศทาง
            
        } while (direction == 0);
    }
    void FixedUpdate()
    {
        if (enemyDetect.enemyHitFlashLight == true)
        {
            _spriteAnimator.SetBool("isWalking", true);
            _rigibody1.WakeUp();
            MoveTowardToPlayer();
        }
        else if (direction == -1||direction==1)
        {
            _spriteAnimator.SetBool("isWalking", true);
            _rigibody1.WakeUp();
            MoveDirection();
        }
        else if (direction==0)
        {
            _rigibody1.Sleep();
            _spriteAnimator.SetBool("isWalking", false);
        }
    }
    public void EnemyDetectPlayer()
    {
        //StopAllCoroutines();
        direction = 0;
        _rigibody1.Sleep();
        _spriteAnimator.SetTrigger("Attacking"); 
    }
    IEnumerator CouroutineAction()
    {
        yield return new WaitForSeconds(time);
        RandomTimeAction();
        RandomAction();
    }
    void RandomTimeAction()
    {
        time = Random.Range(1, maxtimeRandom);
    }
    
    void RandomAction()
    {
        int beforeInt = 0;
        int afterNumber = 0;
        do
        {
            direction = Random.Range(-1, 2);    
            beforeInt = afterNumber;
            afterNumber = direction;

        } while (direction != beforeInt);
        StopAllCoroutines();
        StartCoroutine(CouroutineAction());

    }
    void MoveDirection()
    {
        _rigibody1.velocity = new Vector2(direction * moveSpeed, _rigibody1.velocity.y);
        if (direction < 0 && _flipSprite)
        {
            _spriteAnimator.SetBool("isWalking", true);
            FlipSprite();
        }
        else if (direction > 0 && !_flipSprite)
        {
            _spriteAnimator.SetBool("isWalking", true);
            FlipSprite();
        }
    }
    public void MoveTowardToPlayer()
    {
        //_rigibody1.velocity = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, moveSpeed * Time.deltaTime);
        int directionToward;
        if (Player.Instance.transform.position.x > transform.position.x)
        {
            directionToward = 1;
        }
        else
            directionToward = -1;
        _rigibody1.velocity = new Vector2(directionToward * moveSpeed, _rigibody1.velocity.y);
        if (directionToward < 0 && _flipSprite)
        {
            _spriteAnimator.SetBool("isWalking", true);
            FlipSprite();
        }
        else if (directionToward > 0 && !_flipSprite)
        {
            _spriteAnimator.SetBool("isWalking", true);
            FlipSprite();
        }

    }
    public void FlipSprite()
    {
        _flipSprite = !_flipSprite;
        _sprite.transform.Rotate(0f, 180f, 0);
        _searchLight_Deadzone.transform.Rotate(0f, 180f, 0);
        _catchingZone.transform.Rotate(0f, 180f, 0);
    }
    public void SlowDownEnemy(bool value)
    {
        if (value == true)
        {
            moveSpeed = moveSpeed - 2.5f;
            enemyIsSlowNow = true;
        }

        else
        {
            moveSpeed = moveSpeed + 2.5f;
            enemyIsSlowNow = false;
        }
            
    }

}
