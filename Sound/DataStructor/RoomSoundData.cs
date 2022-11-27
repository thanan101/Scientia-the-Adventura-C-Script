using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RoomListEnum
{
    //Research
    MainMenu,
    AiRoom,
    Hallway,
    ServerRoom,
    TrashRoom,
    ControlRoom,
    UnderGround,
    HallwayB1F,
    HallwayB2F,
    CellPowerRoom,
    WeaponRoom,
    BedRoom1,
    BedRoom2,
    BedRoom3,
    Exit,
    //Mansion
    BasementHallWay,
    DrainRoom,
    WineRoom,
    LibaryEast1F,
    OldResearchRoom,
    EastHallway1F,
    MainHall1F,
    WestHallWay1F,
    LivingRoom,
    FoodRoom,
    KitchenRoon,
    //Mansion 2F
    MainHall2F,
    EastHallWay2F,
    tortureChamber,
    Libaly2F,
    SecretHidenRoom,
    WestHallway2F,
    BathRoom,
    MansionBedRoom3,
    MansionBedRoom2,
    MansionBedRoom1


}
[System.Serializable]
public class RoomSoundData
{
    public RoomListEnum NameRoom;
    [SerializeField]
    [Tooltip("List เสียงโดยให้สอดคล้องกับ index ArrayRoom")]
    public AudioSource thisRoomSound;//ใส่เสียงให้ตรงกับArray Room นั้นๆ  
    [SerializeField]
    [Tooltip("เช็คว่ามีปิดไฟไหมตามลำดับ List ห้องทั้งหมด")]
    public bool LightRoomOut;
}

