using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenuPlayfabs : MonoBehaviour
{
    
    public void LoadGame()
    {
        PlayerPrefs.SetInt("isLoad", 1);
    }
}
