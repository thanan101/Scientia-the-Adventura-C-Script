using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractSaveStaion : MonoBehaviour
{
    //[SerializeField] SpriteRenderer searchIcon;
    [SerializeField] GameObject uiSave;
    [SerializeField] GameObject saveSlotUI;
    [SerializeField] Text textDetail;
    [TextArea(2, 10)]
    [SerializeField] string idleText;
    SaveLoadManager saveLoad;
    sceneManager sceneManagerF;
    private bool keyDown = false;
    public virtual void Start()
    {
        saveLoad = GetComponentInParent<SaveLoadManager>();
        sceneManagerF = FindObjectOfType<sceneManager>();
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //searchIcon.enabled = true;
        if(collision.tag=="Player")
            SreachIcon.Instance.OpenSreachIcon();
    }
    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player" && keyDown == false)
        {
            OpenUI();
            //OpenSlotSaveUI();
            keyDown = true;
            SoundFxManager.Instance.ClickSoundFx();
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        //searchIcon.enabled = false;
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.CloseSreachIcon();
            CloseUI();
        }
            
    }
    public void CloseUI()
    {
        uiSave.SetActive(false);
        Player.Instance._canMove = true;
        keyDown = false;
        //QuestListUI.Instance.OpenQuestListUI();
        GameManager.Instance.EnableUIDisplay(true);
    }
    public void OpenUI()
    {
        uiSave.SetActive(true);
        //QuestListUI.Instance.CloseQuestListUI();
        GameManager.Instance.EnableUIDisplay(false);
        Player.Instance._canMove = false;
    }
    public void OpenSlotSaveUI()
    {
        saveSlotUI.SetActive(true);
        GameManager.Instance.EnableUIDisplay(false);
        Player.Instance._canMove = false;
    }
    public void SaveBTN()
    {
        textDetail.text = ("Save ข้อมูลสำเร็จแล้ว....");
        saveLoad.SaveByJson();
        StopAllCoroutines();
        StartCoroutine(saveComplete());
    }
    public void LoadBTN()
    {
        textDetail.text = ("Load ข้อมูลสำเร็จแล้ว....");
        PlayerPrefs.SetInt("isLoad", 1);
        Debug.Log("Load" + PlayerPrefs.GetInt("isLoad"));
        StopAllCoroutines();
        StartCoroutine(loadComplate());
    }
    IEnumerator saveComplete()
    {
        yield return new WaitForSeconds(3f);
        textDetail.text = idleText; ;
        SoundFxManager.Instance.Notification();
    }
    IEnumerator loadComplate()
    {
        yield return new WaitForSeconds(3f);
        textDetail.text = idleText;
        sceneManagerF.startGame();
        SoundFxManager.Instance.Notification();
    }
}
