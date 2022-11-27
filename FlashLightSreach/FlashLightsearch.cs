using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightsearch : MonoBehaviour
{
    [SerializeField] GameObject VFX;
    private void Start()
    {
        VFX.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag == "FlasLight")
            VFX.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FlasLight")
            VFX.SetActive(false);
    }
}
