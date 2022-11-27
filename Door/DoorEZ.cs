using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorEZ : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _spawnLocation;
    [SerializeField] GameObject _doorIcon;
    [SerializeField] GameObject _fadeON;
    //[SerializeField] Image _blackScreen;
    [SerializeField] bool isArea1;
    [SerializeField] bool isArea2;


    // private bool DoorInteract = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _doorIcon.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                if(Player.Instance._buffImmue==0||Player.Instance._buffImmue>0)
                Player.Instance._buffImmue = 1;
                DoorSound();
                TeleportPlayer();
                StartCoroutine(RemoveImmue());
                StartCoroutine(StopEnemyMusic());
            }
        }
        
    }
    IEnumerator StopEnemyMusic()
    {
        yield return new WaitForSecondsRealtime(3f);
        SoundFxManager.Instance.CatchinEnemy(false);
    }
    IEnumerator RemoveImmue()
    {
        yield return new WaitForSeconds(7f);//ระยะเวลาอมตะ
        Player.Instance._buffImmue = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            _doorIcon.SetActive(false);
    }
    public void TeleportPlayer()
    {
        _player.transform.position = _spawnLocation.transform.position;
        _doorIcon.SetActive(false);
        _fadeON.SetActive(true);
    }
    void DoorSound()
    {
        if (isArea1 == true)
            SoundFxManager.Instance.DoorArea1();
        else if (isArea2 == true)
            SoundFxManager.Instance.DoorArea2();
        else if (isArea1 == false && isArea2 == false)
            SoundFxManager.Instance.FootStepDoor();
    }
    
}
