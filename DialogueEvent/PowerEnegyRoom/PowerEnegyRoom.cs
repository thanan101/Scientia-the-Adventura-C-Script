using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEnegyRoom : MonoBehaviour
{
    [SerializeField] GameObject textAlert1Lock;
    [SerializeField] GameObject doorEnegeyRoom;
    SreachIcon sreachIconPlayer;
    bool doorIsUnlock = false;
    void Start()
    {
        sreachIconPlayer = FindObjectOfType<SreachIcon>();
        doorEnegeyRoom.SetActive(false);
    }
    void Update()
    {
        if (CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event4] == true)
        {
            doorIsUnlock = true;
            doorEnegeyRoom.SetActive(true);//»Å´ÅçÍ¤»ÃÐµÙ
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&doorIsUnlock==false)
        {
            sreachIconPlayer.OpenSreachIcon();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && doorIsUnlock == false)
        {
            sreachIconPlayer.CloseSreachIcon();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && doorIsUnlock == false && Input.GetKeyDown(KeyCode.F))
        {
            textAlert1Lock.SetActive(true);
        }
    }
}
