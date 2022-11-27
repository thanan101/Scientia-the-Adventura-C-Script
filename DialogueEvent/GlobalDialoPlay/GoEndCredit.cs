using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoEndCredit : MonoBehaviour
{
    [SerializeField] bool goodEnd;
    private void OnDisable()
    {
        if (goodEnd == true)
            sceneManager.Instance.goCreditMenu();
        else
            sceneManager.Instance.goGameover();
    }
}
