using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveLoadManager : MonoBehaviour
{
    //Instance////
    private static SaveLoadManager _instance;
    public static SaveLoadManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("SaveLoadManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        
    }
    /// </summary>
    public int pathSlot = 1;
    public string jsonPathSlot = "";
    private string persistentPath = "";
    //WateronFloorMinigame
    [SerializeField] WaterOnfloorFontPaint[] waterOnfloorClass;
    // Start is called before the first frame update
    void StartWithAwake()
    {
        Debug.Log(" SaveloadManagerRunn!");
        SetPathsSlot(1);
        if (PlayerPrefs.GetInt("isLoad") == 1)
        {
            LoadByJson();
            PlayerPrefs.SetInt("isLoad",0);
            Debug.Log("Load" + PlayerPrefs.GetInt("isLoad"));
        }
    }
    private void Start()
    {
        StartWithAwake();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
            SaveByJson();
        if (Input.GetKeyDown(KeyCode.F10))
            LoadByJson();
    }
    private SaveData createSaveGameObject()
    {
        SaveData save = new SaveData();
        //นำค่ามาใส่ใน SaveData
        save.saveQuestsList = QuestManager.Instance.questsList;
        save.saveSideQuestsList = QuestManager.Instance.sideQuestsList;
        //PlayerPosition
        save.playerPositionX = Player.Instance.transform.position.x;
        save.playerPositionY = Player.Instance.transform.position.y;

        save.gotIemList = InventoryManager.Instance.gotItem;
        save.gotDocumentList = DocumentManager.Instance.gotItemLearnDoc;

        save.completeDialogueList = CompleteDialogueEv.Instance.DialogueComplete;
        save.completeQuetionDialogList = CompleteDialogueEv.Instance.QuestionComplete;

        save.isDrainWaterNow = GameManager.Instance.isDrainWater;

        save.waterOnFloor1 = waterOnfloorClass[0].waterStillOnfloor;
        save.waterOnFloor2 = waterOnfloorClass[1].waterStillOnfloor;

        save.useSwitchBraker = GameManager.Instance.useSwitchBraker;

        save.liftItemMansionAreaUse = GameManager.Instance.LiftitemUse;

        save.useSwitchBookShelf = GameManager.Instance.useSwitchBookShelf;

        save.knowVOltISGonenow = GameManager.Instance.knowVoltisGone;
        save.TeleportOhmAray = GameManager.Instance.TeleportOhmAray;

        save.SurpriseEnemyAray = GameManager.Instance.SurpriseEnemyAray;

        save.powerIsGenerate = GameManager.Instance.powerIsGenerate;

        save.inToGoodEnd = GameManager.Instance.inToGoodEndStory;

        save.EndingEvTrigger = GameManager.Instance.EndingEvTrigger;
        save.PlayerInMansionNow = GameManager.Instance.playerInMansionNow;
        save.hintControlerTrigger = GameManager.Instance.hintControlerTrigger;
        return save;
    }
    public void SetPathsSlot(int numSlot)
    {
        //persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "TestSavedataJson.json";
        pathSlot = numSlot;
        switch (pathSlot)
        {
            case 1:
                jsonPathSlot = Application.dataPath + Path.AltDirectorySeparatorChar + "SavedataSlot1.json";
                break;
            case 2:
                jsonPathSlot = Application.dataPath + Path.AltDirectorySeparatorChar + "SavedataSlot2.json";
                break;
            case 3:
                jsonPathSlot = Application.dataPath + Path.AltDirectorySeparatorChar + "SavedataSlot3.json";
                break;
            case 4:
                jsonPathSlot = Application.dataPath + Path.AltDirectorySeparatorChar + "SavedataSlot4.json";
                break;
            case 5:
                jsonPathSlot = Application.dataPath + Path.AltDirectorySeparatorChar + "SavedataSlot5.json";
                break;
            case 6:
                jsonPathSlot = Application.dataPath + Path.AltDirectorySeparatorChar + "SavedataSlot6.json";
                break;
            case 7:
                jsonPathSlot = Application.dataPath + Path.AltDirectorySeparatorChar + "SavedataSlot7.json";
                break;
            case 8:
                jsonPathSlot = Application.dataPath + Path.AltDirectorySeparatorChar + "SavedataSlot8.json";
                break;
        }
    }
    public void SaveByJson()//แปลงค่าเป็น Json type
    {
        SaveData save = createSaveGameObject();

        string JsonString = JsonUtility.ToJson(save); //แปลง save obj เป็น Json(String)
        StreamWriter streamWriter = new StreamWriter(jsonPathSlot);//ที่เก็บไฟล์
        streamWriter.Write(JsonString);
        streamWriter.Close();
        Debug.Log("Saved...");
    }
    public void LoadByJson()
    {
        if (File.Exists(jsonPathSlot))
        {
            //LoadGame
            StreamReader streamReader = new StreamReader(jsonPathSlot);
            string JsonString = streamReader.ReadToEnd();
            streamReader.Close();
            //convert Json to the obj(save)
            SaveData save = JsonUtility.FromJson<SaveData>(JsonString); //into the Save Obj
            Debug.Log("Loaded....");

            //Maker Load Data to the game

            QuestManager.Instance.questsList = save.saveQuestsList;
            QuestManager.Instance.sideQuestsList = save.saveSideQuestsList;

            Player.Instance.transform.position = new Vector2(save.playerPositionX, save.playerPositionY);

            InventoryManager.Instance.gotItem = save.gotIemList;
            DocumentManager.Instance.gotItemLearnDoc = save.gotDocumentList;

            CompleteDialogueEv.Instance.DialogueComplete = save.completeDialogueList;
            CompleteDialogueEv.Instance.QuestionComplete = save.completeQuetionDialogList;

            GameManager.Instance.isDrainWater = save.isDrainWaterNow;

            waterOnfloorClass[0].waterStillOnfloor = save.waterOnFloor1;
            waterOnfloorClass[1].waterStillOnfloor = save.waterOnFloor2;

            GameManager.Instance.LiftitemUse = save.liftItemMansionAreaUse;

            GameManager.Instance.useSwitchBraker = save.useSwitchBraker;

            GameManager.Instance.useSwitchBookShelf = save.useSwitchBookShelf;

            GameManager.Instance.knowVoltisGone = save.knowVOltISGonenow;

            GameManager.Instance.TeleportOhmAray = save.TeleportOhmAray;

            GameManager.Instance.SurpriseEnemyAray = save.SurpriseEnemyAray;

            GameManager.Instance.powerIsGenerate = save.powerIsGenerate;

            GameManager.Instance.inToGoodEndStory = save.inToGoodEnd;

            GameManager.Instance.EndingEvTrigger = save.EndingEvTrigger;

            GameManager.Instance.playerInMansionNow = save.PlayerInMansionNow;
            GameManager.Instance.hintControlerTrigger = save.hintControlerTrigger;
        }
        else
        {
            Debug.Log("Not Fond File");
        }
    }
}
