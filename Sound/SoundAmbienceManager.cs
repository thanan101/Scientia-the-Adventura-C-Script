using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAmbienceManager : MonoBehaviour
{
    //MainMenu,Airoom,TrashRoom,ServerRoom,TrashControlRoom,UndergroundTrashRoom,Hallway ����ӴѺ
    //[SerializeField][Tooltip("List ��ͧ������")] string[] Room; //���������º��� Index �Ѻ soundInRoom �������ͧ�˹��ҹ��

    //[SerializeField][Tooltip("List ���§������ʹ���ͧ�Ѻ index ArrayRoom")]
    //AudioSource[] soundInRoom;//������§���ç�ѺArray Room ����  
    //[SerializeField][Tooltip("������ջԴ��������ӴѺ List ��ͧ������")] 
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
