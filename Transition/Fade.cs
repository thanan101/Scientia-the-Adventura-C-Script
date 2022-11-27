using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] GameObject fadeUI;
    
    public void FadeOFF()
    {
        GameManager.Instance.EnableUIDisplay(true);
        fadeUI.SetActive(false);
    }
    public void CloseAllUI()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.EnableUIDisplay(false);
    }
}
