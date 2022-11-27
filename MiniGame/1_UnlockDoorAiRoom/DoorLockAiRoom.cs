using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockAiRoom : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] TxtAlert TextAlert;
    [SerializeField] TxtAlert TextAlert2;
    [SerializeField] GameObject Minigame;
    void Start()
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.ExitFormAiRoom].complete == false)
        {
            Door.SetActive(false);
            //TextAlert.CloseTextAlert();

            Minigame.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            if (InventoryManager.Instance.gotItem[1] == true)//เช็คว่ามีไอเทมในกระเป่าเก็บของยัง
            {
                TextAlert.CloseTextAlert();
                TextAlert2.OpenTextAlert();
            }
            else
            {
                TextAlert.OpenTextAlert();
            }
                      
        }
        
    }
    public void PlayMiniGame()
    {
        Minigame.SetActive(true);
        GameManager.Instance.EnableUIDisplay(false);
    }
    public void ClearMinigame()
    {
        Destroy(gameObject);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            TextAlert.CloseTextAlert();
        }
    }
}
