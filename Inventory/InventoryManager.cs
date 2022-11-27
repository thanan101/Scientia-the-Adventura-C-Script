using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    /// <summary>
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("InventoryManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>
    [SerializeField]public List<bool> gotItem;
    //[SerializeField] public bool[] gotItem;
    public int itemID;
    [SerializeField] GameObject[] ListItemIMG;
    [SerializeField] Image[] ItemDetailImg;
    [TextArea(7, 15)] public string[] textDetail;
    //[SerializeField] Text txtUI;
    [SerializeField] List<Sprite> detailTextPic;
    [SerializeField] Image showDetailItemImage;
    public void Start()
    {
        ResetItemDetail();
    }
    public void ResetItemDetail()
    {
        //txtUI.text = textDetail[0];
        showDetailItemImage.sprite = detailTextPic[0];
        for (int i = 0; i < ItemDetailImg.Length; i++)
        {
            //gotItem[i] = false;
            ListItemIMG[i].SetActive(false);
            ItemDetailImg[i].enabled = false;
            if (gotItem[i] == true)
            {
                ListItemIMG[i].SetActive(true);
            }
        }
    }
    public void GotItem(int itemId)
    {
        itemID = itemId;
        //Debug.Log(itemID);
        ListItemIMG[itemID].SetActive(true);
        gotItem[itemID] = true;
    }
    public void CheackItem(int itemidUI)
    {
        for (int i = 0; i < ItemDetailImg.Length; i++)
        {
            ItemDetailImg[i].enabled = false;
        }
        //txtUI.text = textDetail[itemidUI];
        showDetailItemImage.sprite = detailTextPic[itemidUI];
        ItemDetailImg[itemidUI].enabled = true;
        //ใส่เสียงปุ่ม
        SoundFxManager.Instance.ClickSoundFx();
    }
    
}
