using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    /// <summary>
    private static InventoryControl _instance;
    public static InventoryControl Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("InventoryControl is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>
    /// 

    [SerializeField] GameObject[] InventoryUI;
    [SerializeField] GameObject IconInventory;
    MediaDocControl mediaDocControl;
    InventoryManager inventoryManager;
    bool uiInventoryisEnable = false;

    private void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
        mediaDocControl = GetComponentInChildren<MediaDocControl>();
        for(int i = 0; i < InventoryUI.Length; i++)
        {
            InventoryUI[i].SetActive(false);
        }
    }
    private void Update()
    {
        if (uiInventoryisEnable == false && Input.GetKeyDown(KeyCode.I))
            EnableInventoryUI();
        else if (uiInventoryisEnable == true && Input.GetKeyDown(KeyCode.I))
            DisableInventoryUI();
    }

    public void EnableInventoryUI()
    {
        SoundFxManager.Instance.ClickSoundFx();
        for(int i = 0; i < InventoryUI.Length; i++)
        {
            InventoryUI[i].SetActive(true);
        }
        InventoryUI[1].SetActive(false);
        DisableIconInventory();
        QuestListUI.Instance.CloseQuestListUI();
        GameManager.Instance.EnableUIDisplay(false);
        Player.Instance.PlayerCanNotMove();
        uiInventoryisEnable = true;
        Time.timeScale = 0;
    }
    public void DisableInventoryUI()
    {
        SoundFxManager.Instance.ClickSoundFx();
        for (int i = 0; i < InventoryUI.Length; i++)
        {
            InventoryUI[i].SetActive(false);
        }
        mediaDocControl.ResetMediaLeatnPic();
        EnableIconInventory();
        QuestListUI.Instance.OpenQuestListUI();
        GameManager.Instance.EnableUIDisplay(true);
        Player.Instance.PlayerCanMove();
        uiInventoryisEnable = false;
        Time.timeScale = 1;
        inventoryManager.ResetItemDetail();
    }
    public void DisableIconInventory()
    {
        //IconInventory.SetActive(false);
    }
    public void EnableIconInventory()
    {
        //IconInventory.SetActive(true);
    }
}
