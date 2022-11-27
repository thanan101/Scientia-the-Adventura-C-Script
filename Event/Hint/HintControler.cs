using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintControler : MonoBehaviour
{
    [SerializeField] GameObject hintControler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.hintControlerTrigger==false)
        {
            hintControler.SetActive(true);
            Player.Instance.PlayerCanNotMove();
            GameManager.Instance.hintControlerTrigger = true;
            GameManager.Instance.EnableUIDisplay(false);
            SoundFxManager.Instance.ClickSoundFx();
        }

    }
    public void CloseUI()
    {
        hintControler.SetActive(false);
        Player.Instance.PlayerCanMove();
        GameManager.Instance.EnableUIDisplay(true);
        SoundFxManager.Instance.ClickSoundFx();
    }
}

