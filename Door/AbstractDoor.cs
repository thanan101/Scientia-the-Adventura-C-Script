using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDoor : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _spawnLocation;
    [SerializeField] GameObject _doorIcon;
    [SerializeField] GameObject _fadeON;
    //[SerializeField] Image _blackScreen;

    // private bool DoorInteract = true;

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _doorIcon.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                if (Player.Instance._buffImmue == 0 || Player.Instance._buffImmue > 0)
                    Player.Instance._buffImmue = 1;
                TeleportPlayer();
                StartCoroutine(RemoveImmue());
            }
        }

    }
    IEnumerator RemoveImmue()
    {
        yield return new WaitForSeconds(1.5f);//ระยะเวลาอมตะ
        Player.Instance._buffImmue = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            _doorIcon.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            _doorIcon.SetActive(true);
    }
    public void TeleportPlayer()
    {
        _player.transform.position = _spawnLocation.transform.position;
        _doorIcon.SetActive(false);
        _fadeON.SetActive(true);
    }
}
