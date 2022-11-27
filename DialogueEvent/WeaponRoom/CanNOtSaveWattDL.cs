using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanNOtSaveWattDL : MonoBehaviour
{
    private void OnDisable()
    {
        sceneManager.Instance.goGameover();
    }
}
