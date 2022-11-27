using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleartenemyIcon : MonoBehaviour
{
    /// <summary>
    private static AleartenemyIcon _instance;
    public static AleartenemyIcon Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("AleartenemyIcon is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>

    SpriteRenderer spriteIconAleartenemy;
    void Start()
    {
        spriteIconAleartenemy = GetComponent<SpriteRenderer>();
    }
    public void OpenAleartEnemyIcon()
    {
        spriteIconAleartenemy.enabled = true;
    }
    public void CloseAleartEnemyIcon()
    {
        spriteIconAleartenemy.enabled = false;
    }
}
