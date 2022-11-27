using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalSeverRoom : MonoBehaviour
{
    [SerializeField] GameObject _allLight;
    [SerializeField] GameObject _terminal;
    [SerializeField] GameObject _doorSever;
    [SerializeField] float _delayHintSec=5.0f;
    [SerializeField] GameObject _HintTxt;
    [SerializeField] GameObject[] _fixFuse;
    
    [SerializeField] GameObject _noFuse;
    [SerializeField] InsertFuseAnim _insertFuseAnim;

    [SerializeField] GameObject _soundABThisRoom;

    [SerializeField] TrshRoomLock _unlockTrashRoom;

    [SerializeField] GameObject _gameOverText;
    int numberOfFuse = 0;//มีทั้งหมด 3
    public bool UseRedFuse = false;
    public bool UseGreenFuse = false;
    public bool UseYellowFuse = false;

    [SerializeField] GameObject unlockdoorText;//แสดงแจ้งเตือนปลดล็อคประตู
    private void Start()
    {
        
    }
    public void UnlockTrashControlRoom()//เรียกผ่าน Btn
    {
        if (UseRedFuse == true && UseGreenFuse == true && UseYellowFuse == true)
        {
            //ใส่ปลดล็อคประตูตรงนี้
            unlockdoorText.SetActive(true);
            SoundFxManager.Instance.DoorUnlock();

            SideQuest4UnlockControlRoomdoor sideQuest4 = FindObjectOfType<SideQuest4UnlockControlRoomdoor>();
            sideQuest4.QuestComplete();

            _unlockTrashRoom.unlockDoorTrashControlRoom = true;
            Debug.Log("ปลดลอค");
            _terminal.SetActive(false);
        }
    }
    public void Powercut()
    {
        if (UseRedFuse == false && UseGreenFuse == false && UseYellowFuse == false)
        {
            
            _allLight.SetActive(false);
            _terminal.SetActive(false);
            _doorSever.SetActive(false);
            SoundAmbienceManager.Instance.DisableRoomSound();
            _soundABThisRoom.SetActive(false);
            SoundFxManager.Instance.PowerDown();
            SoundAmbienceManager.Instance.PlayHallWayAB();
            CheackPlayerHaveFuse3025Yet();
            
        }
            
    }
    public void LightOn()
    {
        _allLight.SetActive(true);
        _terminal.SetActive(true);
        _doorSever.SetActive(true);
        SoundFxManager.Instance.PowerDown();
        _soundABThisRoom.SetActive(true);
    }
    IEnumerator HintWhatHappend()
    {
        yield return new WaitForSeconds(_delayHintSec);
        _HintTxt.SetActive(true);
        for(int i = 0; i < _fixFuse.Length; i++)
        {
            _fixFuse[i].SetActive(true);
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(_delayHintSec);
        _gameOverText.SetActive(true);
    }
    public void UseFuseForFix(int boxid)
    {
        if (boxid == 1)
        {
            int itemID = 2;
            FixFuse(itemID);
        }
        else if (boxid == 2)
        {
            int itemID = 3;
            FixFuse(itemID);
        }
        else if (boxid == 3)
        {
            int itemID = 4;
            FixFuse(itemID);
        }

    }
    public void FixFuse(int itemID)
    {
        int ItemID = itemID;
        if (InventoryManager.Instance.gotItem[ItemID] == true)//เช็คว่ามีไอเทมในกระเป่าเก็บของยังโดยกรอกเลขไอดีไอเทมใน[]
        {
            switch (ItemID)
            {
                case 2:
                    UseRedFuse = true;
                    numberOfFuse++;
                    _fixFuse[0].SetActive(false);
                    break;
                case 3:
                    UseGreenFuse = true;
                    numberOfFuse++;
                    _fixFuse[1].SetActive(false);
                    break;
                case 4:
                    UseYellowFuse = true;
                    numberOfFuse++;
                    _fixFuse[2].SetActive(false);
                    break;              
            }
            _insertFuseAnim.EnableFuseAnime();
            //ใส่เสียงตรงนี้เพื่อแสดงว่าซ่อมเสร็จแล้ว
            StartCoroutine(DelayEnableDisplay());
        }
        else
        {
            _noFuse.SetActive(true);
            InventoryControl.Instance.DisableIconInventory();//ต้องเรียกใช้เพื่อกันไอคอนโชว
        }
    }
    IEnumerator DelayEnableDisplay()
    {
        yield return new WaitForEndOfFrame();
        GameManager.Instance.EnableUIDisplay(false);//ต้องเรียกใช้เพื่อกันไอคอนโชว
    }
    public void CheackCompleteFixFuse() //เรียกผ่าน BTN
    {
        if (numberOfFuse >= 3)
        {
            if (UseRedFuse == true && UseGreenFuse == true && UseYellowFuse == true)
            {
                LightOn();
            }
            else
            {
                //GameOver;
            }
        }
        else
        {
            //ยังซ่อมไม่ครบ
        }
        
    }
    public void CheackPlayerHaveFuse3025Yet()
    {
        if (InventoryManager.Instance.gotItem[3] == false || InventoryManager.Instance.gotItem[4] == false)
            StartCoroutine(GameOver());
        else
            StartCoroutine(HintWhatHappend()); ;
    }
    public void GameOverButton()
    {
        Player.Instance.PlayeDieAnimation();
    }
}
