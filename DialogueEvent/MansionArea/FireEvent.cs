using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent : MonoBehaviour
{
    [SerializeField] GameObject fireAnimation;
    [SerializeField] GameObject doorToWestHllway;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.useSwitchBraker == false)
        {
            fireAnimation.SetActive(true);
            doorToWestHllway.SetActive(false);
        }
    }
}
