using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTotureRoomEnd : AbstractFinishDialogue
{
    [SerializeField] DoorTorureRoom doorToTureRoom;
    public override void OnDisable()
    {
        doorToTureRoom.GetInRoom();
        base.OnDisable();
    }
}
