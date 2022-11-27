using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintShockCirkitAmp : MonoBehaviour
{
    //[SerializeField] Camera cameraMain;
    [SerializeField] GameObject cameraHIntAmp;
    BoxCollider2D boxCollider;
    [SerializeField] GameObject winkLineVFX;
    [SerializeField] DialoguePlayist dialogueHintAmp;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        winkLineVFX.SetActive(false);
    }
    private void Update()
    {
        if (InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyTorTureRoom] == true)
        {
            boxCollider.enabled = true;
            winkLineVFX.SetActive(true);
        }
        if (QuestManager.Instance.questsList[(int)QuestListEnum.FindKeyAndHelpAMp].complete == true||
            GameManager.Instance.powerIsGenerate==false)
            gameObject.SetActive(false);
    }
    public  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.OpenSreachIcon();
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.CloseSreachIcon();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            cameraHIntAmp.SetActive(true);
            dialogueHintAmp.TrigerPlaylist();
            SoundFxManager.Instance.ShockCirkit();
        }
    }
}
