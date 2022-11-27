using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    /// <summary>
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Player is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>

    private Rigidbody2D _rigid;
    [SerializeField] public float _speed = 1.0f;
    public int Health;
    public string onScene;
    bool _playerFlip = true;
    private Animator _animator;
    public int _buffImmue=1;
    [SerializeField] SpriteRenderer spriteIconSearch;
    public bool _canMove = true;//หยุดผู้เล่น
    [SerializeField] Transform Friend;
    public bool _playerWasDetectByCamera = false;
    float move;
    [SerializeField] Transform FlashLight;
    [SerializeField] Transform UseMopIcon;

    public bool playerInEmemyZone = false;
    [SerializeField] GameObject vfxElectro;
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("Move", false);
        _playerFlip = GetComponentInChildren<Transform>();

    }
    void Update()
    {
        if (_canMove == true)
        {
            MoveMent();
        }   
    }

    /// MoveMent ///
    private void MoveMent()
    {
        if (PauseGame.Instance.gameIsPulse == false) 
         move = Input.GetAxisRaw("Horizontal");
        //Debug.Log(move);
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        if (move < 0 && _playerFlip)
        {
            playerFlip();
            Friend.localPosition = new Vector3(1.84f, -2.3f, 3.4f);
            Friend.localScale = new Vector3(-1, 1, 1);
            spriteIconSearch.flipX = true;
            FlashLight.localScale = new Vector3(1, 1, 1);
            UseMopIcon.localScale = new Vector3(-1, 1, 1);

        }
        else if (move > 0 && !_playerFlip)
        {
            playerFlip();
            Friend.localPosition = new Vector3(-1.84f, -2.3f, 3.4f);
            Friend.localScale = new Vector3(1, 1, 1);
            spriteIconSearch.flipX = false;
            FlashLight.localScale = new Vector3(1, 1, 1);
            UseMopIcon.localScale = new Vector3(1, 1, 1);


        }

        if (move < 0)
        {
            walking();
        }
        else if (move > 0)
        {
            walking();
        }
        else
        {
            _animator.SetBool("Move", false);
        }

    }
    public void PlayerCanNotMove()
    {
        _canMove = false;
        _rigid.Sleep();
        _animator.SetBool("Move", false);
        PauseGame.Instance.gameIsPulse = true;
    }
    public void PlayerCanMove()
    {
        _canMove = true;
        _rigid.WakeUp();
        _animator.SetBool("Move", true);
        PauseGame.Instance.gameIsPulse = false;
    }

    public void walking()
    {
        _animator.SetBool("Move" , true);
        //ใส่เสียงเดินตรงนี้
    }
    
    void playerFlip()
    {
        _playerFlip = !_playerFlip;
        transform.Rotate(0f, 180f, 0f);
    }
    public void PlayeDieAnimation()
    {
        GameManager.Instance.EnableUIDisplay(false);
        PlayerCanNotMove();
        _animator.SetTrigger("Die");     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
    }
    /// Save /// 
    /*
    public void SavePlayer( )
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        
        Health = data.Health;

        
        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
        SceneManager.LoadScene(onScene);
        //FlashLight = data.FlashLight;      
        Time.timeScale = 1;
        
    }
    */
    public void VfxElectroON(bool value)
    {
        if (value == true)
            vfxElectro.SetActive(true);
        else
            vfxElectro.SetActive(false);
    }


}
