using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotSaveOhmGameOver : MonoBehaviour
{
    private void OnDisable()
    {
        sceneManager.Instance.goGameover();
    }
}
