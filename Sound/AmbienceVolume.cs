using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceVolume : MonoBehaviour
{
    public AudioSource[] _audioControler;
    public float soundVolume;
    private void Awake()
    {
        _audioControler = GetComponentsInChildren<AudioSource>();
    }
    private void Start()
    {
        SetVolume(PlayerPrefsMusic.GetMasterVolume());
    }
    public void SetVolume(float volume)
    {
        soundVolume = volume;
        for (int i = 0; i < _audioControler.Length; i++)
        {
            _audioControler[i].volume = soundVolume;
            _audioControler[i].ignoreListenerPause = true;//ไม่หยุดเสียงเวลา TimeScale = 0
        }
    }
    public void Mute(bool isMute)
    {
        if (isMute == true)
        {
            for (int i = 0; i < _audioControler.Length; i++)
            {
                _audioControler[i].enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < _audioControler.Length; i++)
            {
                _audioControler[i].enabled = true;
            }
        }
    }
}
