using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAmbienceManager : MonoBehaviour
{
    //MainMenu,Airoom,TrashRoom,ServerRoom,TrashControlRoom,UndergroundTrashRoom,Hallway ตามลำดับ
    //[SerializeField][Tooltip("List ห้องทั้งหมด")] string[] Room; //มีไว้แค่เทียบค่า Index กับ soundInRoom ว่าเป็นห้องไหนเท่านั้น

    //[SerializeField][Tooltip("List เสียงโดยให้สอดคล้องกับ index ArrayRoom")]
    //AudioSource[] soundInRoom;//ใส่เสียงให้ตรงกับArray Room นั้นๆ  
    //[SerializeField][Tooltip("เช็คว่ามีปิดไฟไหมตามลำดับ List ห้องทั้งหมด")] 
    //bool[] LightRoomOut;

    /// <summary>
    private static SoundAmbienceManager _instance;
    public static SoundAmbienceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("SoundAmbienceManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>
    /// 

    public int CurrentRoom = 0;
    [SerializeField] AudioSource _serverRoomEv;

    public List<RoomSoundData> roomSoundDatas = new List<RoomSoundData>();

    public bool evSoundBgmPlay = false;
    public void PlayRoomSound()
    {
        if (GameManager.Instance.EndingEvTrigger == false)
        {
            if (evSoundBgmPlay == false)
            {
                DisableRoomSound();
                if (roomSoundDatas[CurrentRoom].LightRoomOut == false)
                {
                    roomSoundDatas[CurrentRoom].thisRoomSound.Play();
                }
                else
                {
                    DisableRoomSound();
                }
            }
        }
    }
    public void DisableRoomSound()
    {
        for (int i = 0; i < roomSoundDatas.Count; i++)
        {
            if(roomSoundDatas[i].thisRoomSound != null)
                roomSoundDatas[i].thisRoomSound.Stop();
        }
    }
    public void PlayHallWayAB()
    {
        _serverRoomEv.Play();
    }
}
