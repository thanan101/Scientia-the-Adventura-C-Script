using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MediaComand : MonoBehaviour
{
    public int page=0;
    public Image[] media;
    public GameObject MediaCommand;
    public void NextBtn()
    {
        media[page].enabled = false;
        page++;
        if (page >= media.Length)
        {
            page = 0;
            MediaClose();
            
        }
       
        media[page].enabled = true;
        
    }
    public void BackBtn()
    {
        media[page].enabled = false;
        page--;
        if (page < 0)
        {
            page = 0;
        }
        media[page].enabled = true;
    }
    public void MediaClose()
    {
        //page = 0;
        MediaCommand.SetActive(false);
        InventoryControl.Instance.EnableIconInventory();
        QuestListUI.Instance.OpenQuestListUI();
        GameManager.Instance.EnableUIDisplay(true);
    }
}
