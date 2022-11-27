using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    [SerializeField] GameObject badEndingBG;
    [SerializeField] GameObject goodEndingBG;
    private void Update()
    {
        if (GameManager.Instance.EndingEvTrigger == true)
        {
            PlayBgmEv();
        }
    }
    public void EndingEvTrigger()//True==GoodEnd Fals==BadEnd
    {
        GameManager.Instance.EndingEvTrigger = true;
        if (InventoryManager.Instance.gotItem[(int)ItemListEnum.Diary1] == true &&
            InventoryManager.Instance.gotItem[(int)ItemListEnum.Diary2] == true &&
            InventoryManager.Instance.gotItem[(int)ItemListEnum.Diary3] == true )
            //GoodEndPlayBGM
        {
            GameManager.Instance.inToGoodEndStory = true;
        }
            else//BadEndPlayBGM
            {
            GameManager.Instance.inToGoodEndStory = false;
            } 
    }
    void PlayBgmEv()
    {
        SoundAmbienceManager.Instance.DisableRoomSound();
        if (GameManager.Instance.inToGoodEndStory == true)
        {
            BGMEventManager.Instance.GoodEndBGM();
            goodEndingBG.SetActive(true);
        }
        else if(GameManager.Instance.inToGoodEndStory == false)
        {
            BGMEventManager.Instance.BadEndBGM();
            badEndingBG.SetActive(true);
        }
    }
}
