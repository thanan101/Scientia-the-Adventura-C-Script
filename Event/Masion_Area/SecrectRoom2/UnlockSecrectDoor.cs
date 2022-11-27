using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSecrectDoor : MonoBehaviour
{
    [SerializeField] GameObject secrectDoor;
    [SerializeField] GameObject needKeyEmblemText;
    [SerializeField] GameObject useKeyEmblemAnwser;
    [SerializeField] Animator doorAnimator;
    [SerializeField] GameObject winkFx;
    BoxCollider2D boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        secrectDoor.SetActive(false);
        boxCollider.enabled = false;
        winkFx.SetActive(false);
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForEndOfFrame();
        if (GameManager.Instance.knowVoltisGone == true)
        {
           boxCollider.enabled = true;
           winkFx.SetActive(true);
        }
    }
    private void Update()
    {
        if (GameManager.Instance.knowVoltisGone == true)
        {
            boxCollider.enabled = true;
            winkFx.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.OpenSreachIcon();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.CloseSreachIcon();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyEmblem1] == true &&
               InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyEmblem2] == true)
                useKeyEmblemAnwser.SetActive(true);
            else
                needKeyEmblemText.SetActive(true);
        }
    }
    public void OpenTheDoor()
    {
        doorAnimator.SetTrigger("Opened");
        //secrectDoor.SetActive(true);
    }
    
}
