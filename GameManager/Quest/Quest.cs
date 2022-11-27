using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quests
{   
    [TextArea(2, 10)]
    [SerializeField] public string questName;
    public bool complete;
}
[System.Serializable]
public class SideQuest
{   
    [TextArea(2, 10)]
    [SerializeField] public string sideQuestName;
    public bool complete;
}
public enum  QuestListEnum
{
    ExitFormAiRoom,
    DontCatchByRobot,
    FindwayGetInControlRoom,
    HelpOhm,
    HelpWatt,
    HelpVolt,
    Explore1F,
    FindAndHelpAmp,
    FindKeyAndHelpAMp,
    FindItemAndVoltThenEscapeFormMansion,
}
public enum SideQuestListEnum
{
    findScrew,
    HideformRombot,
    ExploThisAreaforFindFuse,
    UsePCUnlockDoor,
    UseRailgunSaveWatt,

}
