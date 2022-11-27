using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    /// <summary>
    private static PauseGame _instance;
    public static PauseGame Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("PulseGame is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>

    public bool gameIsPulse = false;
    [SerializeField] GameObject uiPulseGame;
    private void Start()
    {
        uiPulseGame.SetActive(false);
    }
    void Update()
    {
        if (gameIsPulse == false && Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePauseGameUI(true);
        }
        if (gameIsPulse == true && Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePauseGameUI(false);
        }
    }
    IEnumerator DelaySameInputFunction(bool isEnable)
    {
        yield return new WaitForEndOfFrame();
        if (isEnable == true)
            gameIsPulse = true;
        else
            gameIsPulse = false;
    }
    public void EnablePauseGameUI(bool isEnable)
    {
        SoundFxManager.Instance.ClickSoundFx();
        if (isEnable == true)//Pulsegame
        {
            uiPulseGame.SetActive(true);
            StartCoroutine(DelaySameInputFunction(isEnable));
            Time.timeScale = 0;
            GameManager.Instance.EnableUIDisplay(false);
        }
        else
        {
            GameManager.Instance.EnableUIDisplay(true);
            Time.timeScale = 1;
            uiPulseGame.SetActive(false);
            StartCoroutine(DelaySameInputFunction(isEnable));
        }
    }
    public void DisablePauseGameUI()
    {
        SoundFxManager.Instance.ClickSoundFx();
        GameManager.Instance.EnableUIDisplay(true);
        Time.timeScale = 1;
        uiPulseGame.SetActive(false);
        gameIsPulse = false;        
    }
}
