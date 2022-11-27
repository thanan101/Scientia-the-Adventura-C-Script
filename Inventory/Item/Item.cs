using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //[SerializeField] GameObject _inventoryIcon;
    //[SerializeField] SpriteRenderer searchIcon;
    [SerializeField] FoundItem UIFoundItem;
    [SerializeField] ItemListEnum itemId;

    private void Start()
    {
        StartCoroutine(delayCheack());
    }
    IEnumerator delayCheack()
    {
        yield return new WaitForEndOfFrame();
        if (InventoryManager.Instance.gotItem[(int)itemId] == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (Input.GetKey(KeyCode.F) && other.tag == "Player")
        {
            //Debug.Log("Open");
            UIFoundItem.EnableFoundItemUI();
            UIFoundItem.ShowDeatailItem((int)itemId);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SreachIcon.Instance.OpenSreachIcon();
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SreachIcon.Instance.CloseSreachIcon();
            UIFoundItem.DisableFoundItemUI();
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
