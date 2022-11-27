using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlSceam1 : MonoBehaviour
{
    [SerializeField] SoundFxManager soundFxManager;
    [SerializeField] GameObject _txtAlert;
    public bool seeOhmnow=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&seeOhmnow==false)
        {
            soundFxManager.GirlSceam1();
            _txtAlert.SetActive(true);
            
        }
    }
    public void RemoveThisEv()
    {
        Destroy(gameObject);
    }
}
