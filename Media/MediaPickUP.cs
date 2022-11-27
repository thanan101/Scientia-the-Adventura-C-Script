using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaPickUP : MonoBehaviour
{
    //[SerializeField] SpriteRenderer searchIconPlayer;
    [SerializeField] GameObject displayMediaUI;
    [SerializeField] Image mediaDisplay;
    public MediaListEnum mediaList;
    private void Start()
    {
        if (DocumentManager.Instance.gotItemLearnDoc[(int)mediaList] == true)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.OpenSreachIcon();

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.CloseSreachIcon();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& Input.GetKey(KeyCode.F))
        {
            GameManager.Instance.EnableUIDisplay(false);
            SoundFxManager.Instance.ClickSoundFx();//เพื่อเปลี่ยนเสียง
            Player.Instance._canMove = false;
            DocumentManager.Instance.GetDocCumentLearn((int)mediaList);
            displayMediaUI.SetActive(true);
            mediaDisplay.sprite = GameManager.Instance.mediaListPictureData[(int)mediaList];
        }
    }
    public void CloseMedia()
    {
        GameManager.Instance.EnableUIDisplay(true);
        SoundFxManager.Instance.ClickSoundFx();
        Player.Instance._canMove = true;
        displayMediaUI.SetActive(false);


    }
}
