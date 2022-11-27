using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrshRoomLock : MonoBehaviour
{
    public bool unlockDoorTrashControlRoom=false;
    [SerializeField] GameObject textAleart;
    [SerializeField] GameObject doorTrashControlroom;
    [SerializeField] GameObject greenLight;
    [SerializeField] GameObject redLight;
    [SerializeField] GameObject iconRoom;

    private void Update()
    {
        if (unlockDoorTrashControlRoom == false)
        {
            greenLight.SetActive(false);
            doorTrashControlroom.SetActive(false);
        }
        else
        {
            RoomUnlockLight();
        }
        if (QuestManager.Instance.sideQuestsList[(int)SideQuestListEnum.UsePCUnlockDoor].complete == true)
        {
            unlockDoorTrashControlRoom = true;
        }
    }    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (unlockDoorTrashControlRoom == false)
            {
                doorTrashControlroom.SetActive(false);
                iconRoom.SetActive(true);
            }
            else
            {
                doorTrashControlroom.SetActive(true);
                RoomUnlockLight();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && unlockDoorTrashControlRoom == false)
            {
                textAleart.SetActive(true);
            }         
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            iconRoom.SetActive(false);
            textAleart.SetActive(false);
        }
    }
    public void RoomUnlockLight()
    {
        greenLight.SetActive(true);
        redLight.SetActive(false);
    }
   
}
