using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField]Toggle selectMuteSoundToggle;
    SoundFxManager soundFxScript;
    AmbienceVolume[] soundAmbienceScript;
    //AmbienceVolume soundAmbienceBgmScript;
    [SerializeField] GameObject soundOptionUI;
    
    private void Awake()
    {
        soundFxScript = FindObjectOfType<SoundFxManager>();
        soundAmbienceScript = FindObjectsOfType<AmbienceVolume>();
        //selectMuteSoundToggle = GetComponentInChildren<Toggle>();
    }
    void Start()
    {
        selectMuteSoundToggle.onValueChanged.AddListener(delegate
        {
            ToggleValueChangedOccured(selectMuteSoundToggle);
        });
        volumeSlider.value = PlayerPrefsMusic.GetMasterVolume();
        SetVolumeToOtherSoundOBJ();
        soundOptionUI.SetActive(false);
    }

    public void SaveVolume()
    {
        SoundFxManager.Instance.ClickSoundFx();
        PlayerPrefsMusic.SetMasterVolume(volumeSlider.value);
        SetVolumeToOtherSoundOBJ();
    }
    void SetVolumeToOtherSoundOBJ()
    {
        if(soundFxScript!=null)
            soundFxScript.SetVolume(volumeSlider.value);
        if (soundAmbienceScript != null)
        {
            for(int i = 0; i < soundAmbienceScript.Length; i++)
            {
                soundAmbienceScript[i].SetVolume(volumeSlider.value);
            }
        }
        /*if(soundAmbienceBgmScript!=null)
            soundAmbienceBgmScript.SetVolume(volumeSlider.value);*/
    }
    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        SoundFxManager.Instance.ClickSoundFx();
    }
    //ToggleBtn
    void ToggleValueChangedOccured(Toggle tglvalue)
    {
        MuteSound(tglvalue.isOn);
    }
    public void MuteSound(bool isMute)
    {
        if (isMute == true)
        {
            volumeSlider.value = 0;
            volumeSlider.enabled = false;
        }
        else
        {
            volumeSlider.value = defaultVolume;
            volumeSlider.enabled = true;
        }
        SetVolumeToOtherSoundOBJ();
    }
    //ToggleBtn
    public void EnableSoundOptionUI(bool isEnable)
    {
        SoundFxManager.Instance.ClickSoundFx();
        if (isEnable == true)
        {
            soundOptionUI.SetActive(true);
            StartCoroutine(delayTimeScale());
        }
        else
        {
            soundOptionUI.SetActive(false);
            Time.timeScale = 1;
        }
            
    }
    IEnumerator delayTimeScale()
    {
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0;
    }
}
