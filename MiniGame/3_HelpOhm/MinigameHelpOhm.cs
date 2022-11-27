using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameHelpOhm : MonoBehaviour
{
    [SerializeField] [Tooltip("Colider แท่นควบคุม")] 
    GameObject _terminal; //Colider แท่นควบคุม

    [SerializeField] GameObject _miniGame; 
    [SerializeField] FakeOhm _fakeOhmScript;
    [SerializeField] HelpOhm _helpOhmSript;
    [SerializeField] GameObject _textHelpCommplete;
    [SerializeField] GameObject _textFailureHelp;
    [SerializeField] Quest4HelpOhm _helpOhmQuest;

    [SerializeField] GameObject _allCapsuleTrashRoom;
    [SerializeField] GameObject[] _capsuleTrashRoom;
    [SerializeField] [Tooltip("โอห์มทั้งหมดที่เห็นในหน้าต่าง และพื้นหลังหน้าต่าง")] 
    GameObject []_allOhmInWindow;//โอห์มทั้งหมดที่เห็นในหน้าต่าง จำเป็นในการโหลดซีนถ้ามี

    public int _dontHelp = 0; //นับจำนวนครั้งที่กดยกเลิกหากครบ 3 จะไม่สามารถช่วยโอมได้
    [SerializeField] public bool _minigameStartcountdown = false;

    [SerializeField] DialoguePlayist dialoguePlayDeadEventB;

    [SerializeField] GameObject cameraMinigame;
    //Timmer
    [SerializeField]public float timeLeft;
    public bool TimerOn = false;
    [SerializeField] Text TimerTxt;
    private void Start()
    {
        StartCoroutine(StandByStart());
        if (_helpOhmSript._minigameComplete == false)//UseSaveData
        {
            _terminal.SetActive(true);
        }
        
    }
    IEnumerator StandByStart()
    {
        yield return new WaitForSeconds(0.1f);
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpOhm].complete == true)
        {
            WindowIsBlack();
        }

    }
    private void Update()
    {
        
        if (TimerOn)
        {
            
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                //ช่วยเพื่อนไม่ได้1
                _helpOhmSript.HelpOhmComplete = false;
                _allCapsuleTrashRoom.SetActive(true);
                Result();

                dialoguePlayDeadEventB.TrigerPlaylist();
            }
        }
    }
    private void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerTxt.text = string.Format("{0:00}", seconds);
    }

    public void PlayMiniGameHelpOhm()
    {
        _miniGame.SetActive(true);
        _minigameStartcountdown = true;
        Player.Instance._canMove = false;//ทำให้ pLayer ขยับไม่ได้
        _fakeOhmScript.CheackBlink(true);
        TimerOn = true;//เริ่มนับเวลา
        cameraMinigame.SetActive(true);
        StartCoroutine(delayDisableUI());
    }
    IEnumerator delayDisableUI()
    {
        yield return new WaitForEndOfFrame();
        GameManager.Instance.EnableUIDisplay(false);
    }
    public void DontHelp()//เรียกใช้ผ่านปุ่ม ยกเลิก ช่วยเพื่อนไม่ได้2
    {
        _dontHelp++;
        if (_dontHelp >= 3)
        {
            //AllCapsule Falling
            Result();
            _helpOhmSript.HelpOhmComplete = false;
            //_textFailureHelp.SetActive(true);
            dialoguePlayDeadEventB.TrigerPlaylist();

        }
    }
    public void SelectCapsule(int capsule)
    {
        if (capsule == 3)//เลือกถูกข่วยเพื่อนได้
        {
            _helpOhmSript.HelpOhmComplete = true;
            _textHelpCommplete.SetActive(true);
            _helpOhmQuest.QuestComplete();//Quest4Ohm
            for (int i=0; i < _capsuleTrashRoom.Length; i++)
            {
                _capsuleTrashRoom[i].SetActive(false);
            }
            //Capslue ที่เป็นตัวปลอดตกลงไปข้างล่าง
        }
        else //ช่วยเพื่อนไม่ได้3
        {
            _helpOhmSript.HelpOhmComplete = false;
            //_textFailureHelp.SetActive(true);
            _allCapsuleTrashRoom.SetActive(false);

            dialoguePlayDeadEventB.TrigerPlaylist();
        }
        Result();
    }
    public void Result()
    {
        cameraMinigame.SetActive(false);
        _miniGame.SetActive(false);
        _helpOhmSript._minigameComplete = true;
        _fakeOhmScript.StartMiniGame = false;
        _fakeOhmScript.Done();
        timeLeft = 0;
        TimerOn = false;
        Player.Instance._canMove = true;
        _terminal.SetActive(false);
        GameManager.Instance.EnableUIDisplay(true);
        WindowIsBlack();


    }
    void WindowIsBlack()
    {
        for (int i = 0; i < _allOhmInWindow.Length; i++)
        {
            _allOhmInWindow[i].SetActive(false);//สั่งให้หน้าตางมืดดำ
        }
    }
    
}
