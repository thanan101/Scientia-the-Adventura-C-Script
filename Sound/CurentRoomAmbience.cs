using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurentRoomAmbience : MonoBehaviour
{
    [SerializeField][Tooltip("��������Ţ��ͧ�Ѩ�غѹ")]public RoomListEnum CourentRoom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundAmbienceManager.Instance.CurrentRoom = (int)CourentRoom;
            SoundAmbienceManager.Instance.PlayRoomSound();
        }
    }
}
