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
        SoundFxManager.Instance.ClickSoundFx();//���§����
    }
    public void OpenTextAlert() //������Ѻ�͹��ͨҡ Text Anws ���͡ѹ�Ѥ���� ��ҹBtn�������¡��
    {
        textAlert.SetActive(true);
        InventoryControl.Instance.DisableIconInventory();
        SoundFxManager.Instance.ClickSoundFx();//���§����͹
    }
}
