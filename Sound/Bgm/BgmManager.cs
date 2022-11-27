using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    /// <summary>
    private static BgmManager _instance;
    public static BgmManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("BgmManager is NULL");
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

    [SerializeField] AudioSource enemyPursue;

    public void EnemyPursue(bool value)
    {
        if (value == true)
        {
            SoundAmbienceManager.Instance.evSoundBgmPlay = true;
            SoundAmbienceManager.Instance.DisableRoomSound();
            enemyPursue.ignoreListenerPause = true;
            enemyPursue.Play();
        }
        else
        {
            enemyPursue.Stop();
            SoundAmbienceManager.Instance.evSoundBgmPlay = false;
        }
            
    }
}
