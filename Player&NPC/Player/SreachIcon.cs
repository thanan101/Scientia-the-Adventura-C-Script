using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SreachIcon : MonoBehaviour
{
    /// <summary>
    private static SreachIcon _instance;
    public static SreachIcon Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("SreachIcon is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        Start();
    }
    /// </summary>

    SpriteRenderer spriteIconSreach;
    void Start()
    {
        spriteIconSreach = GetComponent<SpriteRenderer>();
    }
    public void OpenSreachIcon()
    {
        spriteIconSreach.enabled = true;
    }
    public void CloseSreachIcon()
    {
        spriteIconSreach.enabled = false;
    }
}
