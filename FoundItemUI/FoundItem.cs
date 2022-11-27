using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoundItem : MonoBehaviour
{
    /// <summary>
    private static FoundItem _instance;
    public static FoundItem Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("FoundItem is NULL");
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

    [SerializeField] GameObject FoundItemUI;
    private int ItemID;
    [SerializeField] string[] ItemName; 
    [SerializeField] Image[] _itemImmage;
    [SerializeField][Tooltip("คือ Colรderที่เราเจอไอเทมนั้นๆ")] GameObject[] _coliderGameObjectItem;
    [SerializeField] Text _nameTxt;

    private void OnEnable()
    {
        Player.Instance._canMove = false;
        SoundFxManager.Instance.ClickSoundFx();
        QuestListUI.Instance.CloseQuestListUI();
        GameManager.Instance.EnableUIDisplay(false);
    }
    private void OnDisable()
    {
        SoundFxManager.Instance.ClickSoundFx();
        Player.Instance._canMove = true;
        QuestListUI.Instance.OpenQuestListUI();
    }
    public void DisableFoundItemUI()
    {
        FoundItemUI.SetActive(false);
       // _inventoryIcon.SetActive(true);
        //Player.Instance._canMove = true;
        GameManager.Instance.EnableUIDisplay(true);

    }
    
    public void EnableFoundItemUI()
    {
        FoundItemUI.SetActive(true);
        //_inventoryIcon.SetActive(false);
        //_soundFxManager.ClickSoundFx();//ใส่เสียง
    }
    public void TakeItem()
    {
        DisableFoundItemUI();
        InventoryManager.Instance.GotItem(ItemID);
        Destroy(_coliderGameObjectItem[ItemID]);
        /// ส่งค่าไปยัง Class "InventoryManager"
    }
    public void ShowDeatailItem(int itemId)
    {
        ItemID = itemId;
        for (int i = 0; i < ItemName.Length; i++)
        {
            _itemImmage[i].enabled = false;
        }
        _itemImmage[ItemID].enabled = true;
        _nameTxt.text = ItemName[ItemID];
    }

}
