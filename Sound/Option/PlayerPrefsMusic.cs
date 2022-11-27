using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsMusic : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    /// <Instance>
    private static PlayerPrefsMusic _instance;

    public static PlayerPrefsMusic Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("PlayerPrefsMusic");

            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    ///
    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }

    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

}
