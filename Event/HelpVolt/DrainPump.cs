using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainPump : MonoBehaviour
{
    [SerializeField] CheackWineRoom cheackWineRoomScript;
    [SerializeField] GameObject turnpumpTextAwanser;
    [SerializeField] GameObject drainWaterTextAleart;
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
            if (collision.tag == "Player" &&
            GameManager.Instance.isDrainWater == false)
                turnpumpTextAwanser.SetActive(true);
            else if (collision.tag == "Player"
                && GameManager.Instance.isDrainWater == true)
                drainWaterTextAleart.SetActive(true);
        }        
    }
    public void TurnPump()//call by Btn
    {
        GameManager.Instance.isDrainWater = true;
        cheackWineRoomScript.UnlockDoorWineRoom();
        SoundFxManager.Instance.PumpWater(true);
    }
}
