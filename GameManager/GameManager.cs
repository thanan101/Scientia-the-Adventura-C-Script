using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemListEnum
{
    blank,
    Screw,
    Fuse20,
    Fuse30,
    Fuse25,
    KeyCardAreaB,
    Diary1,
    Batery,
    Moter,
    ManaulCellEngy,
    NewCellBatery,
    Memo1,
    Memo2,
    KeyTorTureRoom,
    Mop,
    Diary2,
    Diary3,
    KeyEmblem1,
    KeyEmblem2,

}
public enum MediaListEnum
{
    วงจรไฟฟ้าภายในบ้าน1,
    วงจรไฟฟ้าภายในบ้าน2,
    ภาพวงไฟฟ้า,
    กระแสไฟฟ้า,
    หลักการใช้ฟิวส์ที่ถูกต้อง,
    เครื่องใช้ไฟฟ้าที่ให้พลังงานกล,
    สูตรพลังงานไฟฟ้าและกำลังไฟฟ้า,
    วงจรไฟฟ้าแบบอนุกรมและแบบขนาน,
    การต่อตัวต้านทานและแบตเตอร์รี่1,
    การต่อตัวต้านทานและแบตเตอร์รี่2,
    แรงเคลื่อนไฟฟ้าและความต่างศักย์,

    LightElectronic,
    ElectroMitor,
    ShortCircuit,
    ElectricShock,
    ProtectFormElectricShock,
    CalculatorPower,
    ElectricalConductivity,
    Temperature,
    HeatElectronic,
    
}
public enum LiftRoom
{
    LiftLibrary,
    LiftBedRoom3
}

public class GameManager : MonoBehaviour
{
    //Instance////
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;

    }
    /// </summary>

    
    
    DocumentMaster documentMaster;
    SpawnPointMaster spawnPointMaster;
    [SerializeField] public List<Sprite> mediaListPictureData;
    [SerializeField] public GameObject[] allUIDisplay;
    [SerializeField] GameObject enemyResreachA;
    [SerializeField] List<GameObject> allObjectInResreachA;   
    SaveStaion saveFunc;

    [SerializeField] SpriteRenderer searchIcon;

    //ForDisableGameobjectNoUse
    public bool playerInMansionNow = false;
    [SerializeField] List<GameObject> ResearchObj;

    //DainWater
    public bool isDrainWater=false;

    //LiftbookMansionArea
    public List<bool> LiftitemUse;//save

    //SwitchBrakerKitchenRoom
    public bool useSwitchBraker;//save

    //SwitchBookShelf
    public bool useSwitchBookShelf;//save

    //KnowVoltIsGone
    public bool knowVoltisGone;//save

    //AllEnemyInmansionForSaveDialogue
    public GameObject mansionEnemy;

    //ForDisableEnemyByKill
    public bool _enemyKillPlayer = false;

    //TelepoetOhm
    public List<bool> TeleportOhmAray;//save

    //SurpriseEnemy
    public List<bool> SurpriseEnemyAray;//save

    //powerIsGenerate
    public bool powerIsGenerate=true;

    //EndingEvStart
    public bool EndingEvTrigger;

    //IntoBad OR GoodEnd
    public bool inToGoodEndStory;

    //HintTrigger
    public bool hintControlerTrigger;
    void Start()
    {
        documentMaster = GetComponent<DocumentMaster>();
        spawnPointMaster = GetComponent<SpawnPointMaster>();

        saveFunc = GetComponent<SaveStaion>();

        //StartCoroutine(CheackPlayerInWhatArea());
        if (playerInMansionNow == true)
            PlayerIsNotinResearchArea();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CheackPlayerInWhatArea()
    {
        yield return new WaitForSeconds(3f);
        if (playerInMansionNow == true)
            PlayerIsNotinResearchArea();
    }
    public void EnableUIDisplay(bool isEnable)
    {
        if (isEnable == true)
        {
            for (int i = 0; i < allUIDisplay.Length; i++)
            {
                allUIDisplay[i].SetActive(true);
                if(_enemyKillPlayer==false)
                    mansionEnemy.SetActive(true);
            }
                
        }
        else
        {
            for (int i = 0; i < allUIDisplay.Length; i++)
            {
                allUIDisplay[i].SetActive(false);
                if (_enemyKillPlayer == false)
                    mansionEnemy.SetActive(false);
            }
            searchIcon.enabled = false;
        }
        
    }
    public void PlayerIsNowReserchB1F()
    {
        enemyResreachA.SetActive(false);
        saveFunc.OpenUI();
        for(int i = 0; i < allObjectInResreachA.Count; i++)
        {
            allObjectInResreachA[i].SetActive(false);
        }
    }
    public void PlayerIsNotinResearchArea()
    {       
        for(int i = 0; i < ResearchObj.Count; i++)
        {
            ResearchObj[i].SetActive(false);
        }
    }
}
