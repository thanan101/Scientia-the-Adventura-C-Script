using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtAlertOptimized : MonoBehaviour
{
    [TextArea(7, 15)] public string Text;
    [SerializeField] Text textBox;
    [SerializeField] GameObject textAlert;
    void Start()
    {
        textBox.text = Text;
    }
    public void CloseTextAlert()
    {
        textAlert.SetActive(false);
        InventoryControl.Instance.EnableIconInventory();
    }
    public void ClickFx()
    {
        SoundFxManager.Instance.ClickSoundFx();//เสียงปุ่ม
    }
    public void OpenTextAlert() //ใช้สำหรับตอนต่อจาก Text Anws เพื่อกันบัคปุ่ม ผ่านBtnหรือเรียกใช้
    {
        textAlert.SetActive(true);
        InventoryControl.Instance.DisableIconInventory();
        SoundFxManager.Instance.ClickSoundFx();//เสียงแจ้งเตือน
    }
}
