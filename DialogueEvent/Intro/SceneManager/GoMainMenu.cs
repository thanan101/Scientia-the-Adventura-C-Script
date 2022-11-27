using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMainMenu : MonoBehaviour
{
    private void OnDisable()
    {
        //sceneManager.Instance.goMainMenu();
        sceneManager.Instance.goCreditMenu();
    }
}
