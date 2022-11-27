using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftResreachArea : MonoBehaviour
{
    [SerializeField] GameObject _fadeONLift;
    [SerializeField] GameObject _eIcon;
    [SerializeField] GameObject panelCanvasLiftButtonUse;
    [SerializeField] GameObject _spawnPoint_1F;
    [SerializeField] GameObject _spawnPoint_2F;
    [SerializeField] GameObject _spawnPoint_Exit;
    [SerializeField] GameObject _cantGoExitYetText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _eIcon.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _eIcon.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Player.Instance.PlayerCanNotMove();
            panelCanvasLiftButtonUse.SetActive(true);
            GameManager.Instance.EnableUIDisplay(false);
            Time.timeScale = 0;
            SoundFxManager.Instance.ClickSoundFx();
        }
    }
    
    public void Select1F()
    {
        _fadeONLift.SetActive(true);
        Player.Instance.transform.position = _spawnPoint_1F.transform.position;
        ClickFnc();
    }
    public void Select2F()
    {
        _fadeONLift.SetActive(true);
        Player.Instance.transform.position = _spawnPoint_2F.transform.position;
        ClickFnc();
    }
    public void SelectExit()
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpWatt].complete == true)
        {
            _fadeONLift.SetActive(true);
            Player.Instance.transform.position = _spawnPoint_Exit.transform.position;
        }
        else
            _cantGoExitYetText.SetActive(true);
        ClickFnc();
    }
    public void ClickFnc()
    {
        SoundFxManager.Instance.ClickSoundFx();
        panelCanvasLiftButtonUse.SetActive(false);
        Player.Instance.PlayerCanMove();
        CloseLiftButton();
    }
    public void CloseLiftButton()
    {
        GameManager.Instance.EnableUIDisplay(true);
        Time.timeScale = 1;
    }

}
