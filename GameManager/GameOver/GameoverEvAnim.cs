using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverEvAnim : MonoBehaviour
{
    public void Gameover()
    {
        sceneManager.Instance.goGameover();
    }
}
