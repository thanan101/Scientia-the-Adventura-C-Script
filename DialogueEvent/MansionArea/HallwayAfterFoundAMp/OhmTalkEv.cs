using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhmTalkEv : MonoBehaviour
{
    [SerializeField] GameObject Ohm;
    [SerializeField] DialoguePlayist Ev13Ex1;
    [SerializeField] DialoguePlayist Ev13Ex2;
    //[SerializeField] Quest10FindVoltAndKeyEmblem questFindVoltAndKeyEmblem;
    BoxCollider2D boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        Ohm.SetActive(false);
    }
    private void Update()
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.FindKeyAndHelpAMp].complete == true)
        {
            boxCollider.enabled = true;
            Ohm.SetActive(true);
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.OpenSreachIcon();
            if (GameManager.Instance.useSwitchBraker == false)
                SoundFxManager.Instance.FireSoundFx(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.CloseSreachIcon();
        if (GameManager.Instance.useSwitchBraker == false)
            SoundFxManager.Instance.FireSoundFx(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&Input.GetKeyDown(KeyCode.F))
        {
            GameManager.Instance.knowVoltisGone = true;
            //questFindVoltAndKeyEmblem.QuestTrigger();
            if (GameManager.Instance.useSwitchBraker == false)
                Ev13Ex1.TrigerPlaylist();
            else if (GameManager.Instance.useSwitchBraker == true)
                Ev13Ex2.TrigerPlaylist();
        }
        
    }
}
