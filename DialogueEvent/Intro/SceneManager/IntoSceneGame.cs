using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntoSceneGame : MonoBehaviour
{
    
    private void OnDisable()
    {
        //Debug.Log("Go gogo");

        sceneManager.Instance.startGame();
    }


}
