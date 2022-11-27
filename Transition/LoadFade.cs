using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFade : MonoBehaviour
{
    [SerializeField] GameObject fade; 
    void Start()
    {
        GameManager.Instance.EnableUIDisplay(false);
        fade.SetActive(true);
    }
}
