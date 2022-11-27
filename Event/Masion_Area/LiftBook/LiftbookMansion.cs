using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftbookMansion : MonoBehaviour
{
    [SerializeField] GameObject useLiftTextAnwser;
    public ItemListEnum itemInthisLift;
    public LiftRoom liftInRoom;
    LiftbookBtnUse liftbookBtn;
    void Start()
    {
        liftbookBtn = GetComponentInParent<LiftbookBtnUse>();
        StartCoroutine(DelayCheack());
    }
    IEnumerator DelayCheack()
    {
        yield return new WaitForEndOfFrame();
        Cheack();
    }
    void Cheack()
    {
        if (GameManager.Instance.LiftitemUse[(int)liftInRoom] == true &&
            InventoryManager.Instance.gotItem[(int)itemInthisLift] == false)
            liftbookBtn.itemDorpFormLift[(int)liftInRoom].SetActive(true);
        if (InventoryManager.Instance.gotItem[(int)itemInthisLift] == true)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" &&
            InventoryManager.Instance.gotItem[(int)itemInthisLift] == false)
            SreachIcon.Instance.OpenSreachIcon();
        Cheack();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" &&
            InventoryManager.Instance.gotItem[(int)itemInthisLift] == false)
            SreachIcon.Instance.CloseSreachIcon();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if (InventoryManager.Instance.gotItem[(int)itemInthisLift] == false
            && GameManager.Instance.LiftitemUse[(int)liftInRoom] == false)
            {
                useLiftTextAnwser.SetActive(true);
                liftbookBtn.item = (int)liftInRoom;
            }
            else if (InventoryManager.Instance.gotItem[(int)itemInthisLift] == false
                && GameManager.Instance.LiftitemUse[(int)liftInRoom] == true)
            {
                GameManager.Instance.EnableUIDisplay(false);
                Player.Instance.PlayerCanNotMove();
                liftbookBtn.cameraLift[(int)liftInRoom].SetActive(true);
                StartCoroutine(CameraOnLift());
            }
        }    
    }
    IEnumerator CameraOnLift()
    {
        yield return new WaitForSecondsRealtime(3f);
        liftbookBtn.cameraLift[(int)liftInRoom].SetActive(false);
        liftbookBtn.isUseListTextRoom[(int)liftInRoom].SetActive(true);
    }

}
