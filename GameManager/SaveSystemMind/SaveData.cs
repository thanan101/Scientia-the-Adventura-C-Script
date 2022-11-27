using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveData 
{

    public List<Quests> saveQuestsList = new List<Quests>();
    public List<SideQuest> saveSideQuestsList = new List<SideQuest>();

    public float playerPositionX;
    public float playerPositionY;

    public List<bool> gotIemList = new List<bool>();
    public List<bool> gotDocumentList = new List<bool>();

    public List<bool> completeDialogueList = new List<bool>();
    public List<bool> completeQuetionDialogList = new List<bool>();

    public bool waterOnFloor1 ;
    public bool waterOnFloor2 ;

    public bool isDrainWaterNow;

    public List<bool> liftItemMansionAreaUse = new List<bool>();

    public bool useSwitchBraker;

    public bool useSwitchBookShelf;

    public bool knowVOltISGonenow;

    public List<bool> TeleportOhmAray;

    public List<bool> SurpriseEnemyAray;

    public bool powerIsGenerate;

    public bool inToGoodEnd;

    public bool EndingEvTrigger;

    public bool PlayerInMansionNow;

    public bool hintControlerTrigger;
}
