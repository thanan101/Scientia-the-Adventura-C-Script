using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActtiveMedia : MonoBehaviour
{
    //[SerializeField]GameObject searchIcon;
    [SerializeField]GameObject mediaShow;
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (Input.GetKey(KeyCode.F)&&other.tag == "Player")
        {
            //Debug.Log("Open");
            mediaShow.SetActive(true);
            InventoryControl.Instance.DisableIconInventory();
            SoundFxManager.Instance.ClickSoundFx();
            DocumentManager.Instance.GetDocCumentLearn(0); //���Ѻ�͡���
            DocumentManager.Instance.GetDocCumentLearn(1); //���Ѻ�͡���
            DocumentManager.Instance.GetDocCumentLearn(2); //���Ѻ�͡���
            //�պѤ��ͧ�� UI ����������º����������觼�ҹ������ �·� Prefab ���� !!�ѧ�����
            GameManager.Instance.EnableUIDisplay(false);
            QuestListUI.Instance.CloseQuestListUI();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //searchIcon.SetActive(true);
            SreachIcon.Instance.OpenSreachIcon();
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //searchIcon.SetActive(false);
            SreachIcon.Instance.CloseSreachIcon();
        }
    }
}
