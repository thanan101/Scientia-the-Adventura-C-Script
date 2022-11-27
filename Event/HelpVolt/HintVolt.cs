using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintVolt : MonoBehaviour
{
    [SerializeField]GameObject hintVoltText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            hintVoltText.SetActive(true);
    }
}
