using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtAlert : MonoBehaviour
{
    [TextArea(7, 15)] public string Text;
    [SerializeField] public Text textBox;
    [SerializeField] GameObject textAlert;
    void Start()
    {
        textBox.text = Text;
    }
    private void OnEnable()
    {
        SoundFxManager.Instance.ClickSoundFx();
        Player.Instance.PlayerCanNotMove();
        //GameManager.Instance.EnableUIDisplay(false);
        StartCoroutine(DelayDisableUI());
    }
    IEnumerator DelayDisableUI()
    {
        yield return new WaitForEndOfFrame();
        GameManager.Instance.EnableUIDisplay(false);
    }
    public void CloseTextAlert()
    {
        textAlert.SetActive(false);
        InventoryControl.Instance.EnableIconInventory();
        //SoundFxManager.Instance.ClickSoundFx();//���§���� �պѤ�ͺ�ӧҹ�ͧ�͹�����
        Player.Instance.PlayerCanMove();
        GameManager.Instance.EnableUIDisplay(true);
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
    public void ShowtextAndEnable(bool isShow,string text)
    {
        if (isShow == true)
        {
            textBox.text = text;
            OpenTextAlert();
            
        }
        else
        {
            CloseTextAlert();
        }
    }

}
