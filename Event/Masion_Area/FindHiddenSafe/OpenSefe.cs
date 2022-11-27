using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSefe : MonoBehaviour
{
    [SerializeField] int WhatSefe;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SreachIcon.Instance.OpenSreachIcon();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SreachIcon.Instance.CloseSreachIcon();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player" && WhatSefe == 1)
        {
            if (InventoryManager.Instance.gotItem[(int)ItemListEnum.Memo1]==true)
            {

            }
            else
            {

            }
        }
        else if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player" && WhatSefe == 2)
        {
            if (InventoryManager.Instance.gotItem[(int)ItemListEnum.Memo2] == true)
            {

            }
            else
            {

            }
        }


    }
}
