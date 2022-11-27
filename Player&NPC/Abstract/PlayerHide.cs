using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerHide : MonoBehaviour
{
    [SerializeField] GameObject _player;
    public bool _isHiding = false;
    [SerializeField] GameObject _btnIcon;
    [SerializeField] GameObject _btnIcon_getout;
    [SerializeField] Canvas _hideFilter;
    Animator _lockerAnim;
    public virtual void Start()
    {
        _lockerAnim = GetComponentInChildren<Animator>();
    }
    public virtual void Update()
    {
        if (_isHiding == true)
        {
            if (Input.GetKey(KeyCode.F)&&_isHiding==true)//ออกจากการหลบซ่อน
            {
                _player.SetActive(true);
                _isHiding = false;
                _hideFilter.enabled = false;
                _btnIcon_getout.SetActive(false);
                SoundFxManager.Instance.HideFx();
            }
        }
    }
    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && _isHiding == false)//หลบซ่อน
            {
                _player.SetActive(false);
                _isHiding = true;
                _hideFilter.enabled = true;
                _lockerAnim.SetBool("OpenLocker", false);
                _btnIcon_getout.SetActive(true);
                SoundFxManager.Instance.HideFx();
                StartCoroutine(StopEnemyMusic());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _btnIcon.SetActive(true);
            _lockerAnim.SetBool("OpenLocker", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _btnIcon.SetActive(false);
            _lockerAnim.SetBool("OpenLocker", false);
        }
    }
    IEnumerator StopEnemyMusic()
    {
        yield return new WaitForSecondsRealtime(3f);
        SoundFxManager.Instance.CatchinEnemy(false);
    }
}
