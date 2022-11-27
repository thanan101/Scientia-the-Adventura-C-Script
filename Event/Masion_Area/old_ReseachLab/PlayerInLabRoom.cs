using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInLabRoom : MonoBehaviour
{

    [SerializeField] AudioSource soundGenerator;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameManager.Instance.powerIsGenerate == true)
            {
                if(soundGenerator.isPlaying==false)
                    soundGenerator.Play();
            }
                
            else
                soundGenerator.Stop();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            soundGenerator.Stop();
    }
}
