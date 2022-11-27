using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobot : MonoBehaviour
{
    /// <summary>
    private static EnemyRobot _instance;
    public static EnemyRobot Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("EnemyRobot is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>

    [SerializeField] float moveSpeed = 2f;
    public Rigidbody2D _rigibody1;
    public bool _flipSprite =true; 
    [SerializeField] GameObject _sprite;
    [SerializeField] Animator _spriteAnimator;
    [SerializeField] Transform _searchLight;
    [SerializeField] Transform _catchingZone;
    public int direction = -1;
     void Start()
    {

        _rigibody1 = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _rigibody1.velocity = new Vector2(direction * moveSpeed, _rigibody1.velocity.y);
        if (direction < 0&& _flipSprite)
        {
            _spriteAnimator.SetBool("isWalking", true);
            FlipSprite();
            ///MoveToLeft();
        }
        else if (direction > 0&& !_flipSprite)
        {
            _spriteAnimator.SetBool("isWalking", true);
            FlipSprite();
            //MoveToRight();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
    }
    /*public void MoveToLeft()
    {
        _rigibody1.velocity = new Vector2(-1 * moveSpeed, _rigibody1.velocity.y);
        //flip
        FlipSprite();
        _searchLight.transform.localScale = new Vector3(9.75207f, 1, 1);
    }
    public void MoveToRight()
    {
        _rigibody1.velocity = new Vector2(1 * moveSpeed, _rigibody1.velocity.y);
        //flip
        FlipSprite();
        _searchLight.transform.localScale = new Vector3(-9.75207f, 1, 1);
    }*/
    public void FlipSprite()
    {
        _flipSprite = !_flipSprite;
        _sprite.transform.Rotate(0f, 180f, 0);
        _searchLight.transform.Rotate(0f, 180f, 0);
        _catchingZone.transform.Rotate(0f, 180f, 0);
    }
}
