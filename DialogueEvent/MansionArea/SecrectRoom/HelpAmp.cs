using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpAmp : MonoBehaviour
{
    [SerializeField] GameObject useKeyNowTextAwnser;
    [SerializeField] DialoguePlayist ev1302;
    [SerializeField] DialoguePlayist ev1304;
    [SerializeField] DialoguePlayist canSaveAmpDialog;
    [SerializeField] Quest8FindAndHelpAmp questFindAndHelpAmp;
    [SerializeField] Quest9FindKeyHelpAmp questFindKeyHelpAmp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.FindKeyAndHelpAMp].complete == true)
            Destroy(gameObject);
        if (QuestManager.Instance.questsList[(int)QuestListEnum.FindAndHelpAmp].complete != true)
        {
            questFindAndHelpAmp.QuestComplete();
            questFindKeyHelpAmp.QuestTrigger();
        }
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.OpenSreachIcon();
            if (GameManager.Instance.powerIsGenerate == true)
                Player.Instance.VfxElectroON(true);
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.OpenSreachIcon(); 
            if (GameManager.Instance.powerIsGenerate == true)
                Player.Instance.VfxElectroON(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (collision.tag == "Player" &&
            InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyTorTureRoom] == false)
            {
                ev1302.TrigerPlaylist();
            }
            else if (collision.tag == "Player"&&
                InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyTorTureRoom] == true)
            {
                useKeyNowTextAwnser.SetActive(true);
            }
        }
        
    }
    public void UseKey()
    {
        if (GameManager.Instance.powerIsGenerate == true)
        {
            ev1304.TrigerPlaylist();
            SoundFxManager.Instance.ShockCirkit();
            StartCoroutine(DelayAmpSreamDead());
        }
        if (GameManager.Instance.powerIsGenerate == false)
        {
            questFindKeyHelpAmp.QuestComplete();
            canSaveAmpDialog.TrigerPlaylist();
            Destroy(gameObject);
        }
    }
    IEnumerator DelayAmpSreamDead()
    {
        yield return new WaitForSeconds(0.5f);
        SoundFxManager.Instance.GirlScream4();
    }
}
