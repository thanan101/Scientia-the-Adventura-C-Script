using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaCommandSingle : MonoBehaviour
{
    public GameObject MediaCommand;
    public void MediaClose()
    {
        //page = 0;
        MediaCommand.SetActive(false);
        //InventoryControl.Instance.EnableIconInventory();
        QuestListUI.Instance.OpenQuestListUI();
        GameManager.Instance.EnableUIDisplay(true);
    }
}
