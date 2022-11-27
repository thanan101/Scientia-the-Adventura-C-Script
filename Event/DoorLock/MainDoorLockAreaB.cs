using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorLockAreaB : MonoBehaviour
{
    [SerializeField] GameObject maindoor;
    [SerializeField] GameObject textAlertMaindoorLock;
    [SerializeField] GameObject textAlertGoNextAreaB;
    //SreachIcon searchIcon;
    BoxCollider2D boxCollider;
    bool doorisUnlock = false;
    private void Start()
    {       
            maindoor.SetActive(false);
    }
    private void Update()
    {
        if (doorisUnlock == true)
        {
            maindoor.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.tag == "Player"&& InventoryManager.Instance.gotItem
            [(int)NameItem.KeyCardAreaB]==false)
        {
            textAlertMaindoorLock.SetActive(true);
        }
        else if (collision.tag == "Player" && InventoryManager.Instance.gotItem
            [(int)NameItem.KeyCardAreaB] == true)
        {
            textAlertGoNextAreaB.SetActive(true);
            doorisUnlock = true;
            boxCollider = GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;
        }*/
        SreachIcon.Instance.OpenSreachIcon();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SreachIcon.Instance.CloseSreachIcon();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if (InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyCardAreaB] == false)
            {
                Debug.Log("Hello");
                textAlertMaindoorLock.SetActive(true);
            }
            else if (InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyCardAreaB] == true )
            {
                doorisUnlock = true;
                textAlertGoNextAreaB.SetActive(true);
                boxCollider = GetComponent<BoxCollider2D>();
                boxCollider.enabled = false;
            }
        }
        
    }
}
