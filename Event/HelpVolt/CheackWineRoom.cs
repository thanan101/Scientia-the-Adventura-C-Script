using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheackWineRoom : MonoBehaviour
{
    [SerializeField] GameObject water;
    [SerializeField] public GameObject cameraVolt;
    [SerializeField] List<GameObject> doorWineRoom;
    [SerializeField] DialoguePlayist Dialogue7o2;

    [SerializeField] Animator animatorWine;
    private void Start()
    {
        UnlockDoorWineRoom();
    }
    public void UnlockDoorWineRoom()
    {
        StartCoroutine(DelayCheck());
    }
    IEnumerator DelayCheck()
    {
        yield return new WaitForEndOfFrame();
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpVolt].complete == false)
        {
            if (GameManager.Instance.isDrainWater == false)
            {
                LoopDoor(false);
                animatorWine.SetBool("isDrainWater", false);
            }
            else if(GameManager.Instance.isDrainWater==true)
            {
                LoopDoor(true);
                animatorWine.SetBool("isDrainWater", true);
                cameraVolt.SetActive(true);
                Destroy(gameObject);
            }
        }
        
    }
    void LoopDoor(bool isEnable)
    {
        for (int i = 0; i < doorWineRoom.Count; i++)
        {
            doorWineRoom[i].SetActive(isEnable);
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
        if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player"
            && GameManager.Instance.isDrainWater == false)
        {
            cameraVolt.SetActive(true);
            Dialogue7o2.TrigerPlaylist();
        }
        else if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player"
            && GameManager.Instance.isDrainWater ==true)
        {
            LoopDoor(true);
            Destroy(gameObject);
        }
    }

}
