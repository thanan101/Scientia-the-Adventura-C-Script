using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    /// <summary>
    private static sceneManager _instance;
    public static sceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("sceneManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>

    private int currentSceneIndex;
    [SerializeField] float waitTime;
    
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex==0)
            StartCoroutine(PlayIntro());
        if(currentSceneIndex == 5)
        {
            StartCoroutine(PlayCredit());
        }
    }
    IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(waitTime);
        goMainMenu();
    }
    IEnumerator PlayCredit()
    {
        yield return new WaitForSeconds(waitTime);
        goMainMenu();
    }
    public void Intro()
    {
        SceneManager.LoadScene("InroStory");
        Time.timeScale = 1;
    }
    public void startGame()
    {
        SceneManager.LoadScene("Test-Area1");
        Time.timeScale = 1;
    }
    public void goMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void goGameover()
    {
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 1;
    }
    public void goCreditMenu()
    {
        SceneManager.LoadScene("CreditScene");
        Time.timeScale = 1;
    }

    //public void optionScene()
    //{
    //    SceneManager.LoadScene("optionScene");
    //    Time.timeScale = 1;
    //}

    //public void backMenu()
    //{
    //    SceneManager.LoadScene("MainMenu");

    //}

    public void quitGame()
    {
        Application.Quit();
    }
}
