using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    //Instance////
    private static MapManager _instance;
    public static MapManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("MapManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;

    }
    /// </summary>

    [SerializeField]GameObject showMapUI;
    [SerializeField]Image mapImage;
    [SerializeField]List<Sprite> listMapPicture;
    bool mapUIisEnable = false;

    private void Start()
    {
        showMapUI.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)&&mapUIisEnable==false)
        {
            EnableMapUI(true);
        }
        if (Input.GetKeyDown(KeyCode.M) && mapUIisEnable == true)
        {
            EnableMapUI(false);
        }
    }
    
    IEnumerator DelaySameButon(bool isEnable)
    {
        yield return new WaitForEndOfFrame();
        if (isEnable == true)
            mapUIisEnable = true;
        else
            mapUIisEnable = false;
    }
    public void EnableMapUI(bool isEnable)
    {
        SoundFxManager.Instance.ClickSoundFx();
        if (isEnable == true) //เปิดหน้า UI
        {
            StartCoroutine(DelaySameButon(isEnable));
            GameManager.Instance.EnableUIDisplay(false);
            showMapUI.SetActive(true);
            if(GameManager.Instance.playerInMansionNow == false)
            {
                mapImage.sprite = listMapPicture[0];
            }
            else
            {
                mapImage.sprite = listMapPicture[1];
            }
            Player.Instance.PlayerCanNotMove();
            Time.timeScale = 0;
        }
        else if (isEnable == false)// ปิดหน้า UI
        {
            StartCoroutine(DelaySameButon(isEnable));
            GameManager.Instance.EnableUIDisplay(true);
            showMapUI.SetActive(false);
            Player.Instance.PlayerCanMove();
            Time.timeScale = 1;
        }
    }

}
