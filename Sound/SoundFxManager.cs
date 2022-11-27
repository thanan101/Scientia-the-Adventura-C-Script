using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxManager : MonoBehaviour
{
    /// <summary>
    private static SoundFxManager _instance;
    public static SoundFxManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("SoundFxManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        StartWithAwake();
    }
    /// </summary>
    /// 

    [SerializeField] AudioSource _clickSound;
    [SerializeField] AudioSource _screw;
    [SerializeField] AudioSource _switch;
    [SerializeField] AudioSource _selectScrew;
    [SerializeField] AudioSource _selectHand;
    [SerializeField] AudioSource _doorErictricUnlock;
    [SerializeField] AudioSource _powerDown;
    [SerializeField] AudioSource _grilScream1;
    [SerializeField] AudioSource _grilScream2;
    [SerializeField] AudioSource _fallingCapsule;
    [SerializeField] AudioSource _beamShot;
    [SerializeField] AudioSource _lift;
    [SerializeField] AudioSource _wattScream;
    [SerializeField] AudioSource _voltScream;
    [SerializeField] AudioSource _blink;
    [SerializeField] AudioSource _robotFx;
    [SerializeField] AudioSource _hitByEnemy;
    [SerializeField] AudioSource _flashLight;
    [SerializeField] AudioSource _sefeOpen;
    [SerializeField] AudioSource _splashingWater;
    [SerializeField] AudioSource _highVolt;
    [SerializeField] AudioSource _secrectDoor;
    [SerializeField] AudioSource _girlScream3;
    [SerializeField] AudioSource _girlScream4;
    [SerializeField] AudioSource _fireFx;
    [SerializeField] AudioSource _doorArea1;
    [SerializeField] AudioSource _doorArea2;
    [SerializeField] AudioSource _footStepDoor;
    [SerializeField] AudioSource _machineGun;
    [SerializeField] AudioSource _machineGunMeme;
    [SerializeField] AudioSource _pumpWaterFx;
    [SerializeField] AudioSource _switchCrank;
    [SerializeField] AudioSource _hideFx;
    [SerializeField] AudioSource _mopFx;
    [SerializeField] AudioSource _notification;
    [SerializeField] AudioSource _catchinhEnemy;

    public AudioSource []_audioControler;
    public float soundVolume;
    void StartWithAwake()
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


    public void ClickSoundFx()
    {
        _clickSound.Play();
    }
    public void ScrewFx()
    {
        _screw.Play();
    }
    public void SwitchFx()
    {
        _switch.Play();
    }
    public void SelectScrew()
    {
        _selectScrew.Play();
    }
    public void SelectHand()
    {
        _selectHand.Play();
    }
    public void DoorUnlock()
    {
        _doorErictricUnlock.Play();
    }
    public void PowerDown()
    {
        _powerDown.Play();
    }
    public void GirlSceam1()
    {
        _grilScream1.Play();
    }
    public void GrilSceam2()
    {
        _grilScream2.Play();
    }
    public void FallingCapsule()
    {
        _fallingCapsule.Play();
        _fallingCapsule.volume = 0.5f;
    }
    public void BeamFX()
    {
        _beamShot.Play();
    }
    public void LiftBookFx()
    {
        _lift.Play();
    }
    public void WattScreamFx()
    {
        _wattScream.Play();
    }
    public void VoltScreamFx()
    {
        _voltScream.Play();
    }
    public void BlinkFx()
    {
        _blink.Play();
    }
    public void RobotFx()
    {
        _robotFx.Play();
    }
    public void HitByEnemy()
    {
        _hitByEnemy.Play();
    }
    public void FlashlightOnOff()
    {
        _flashLight.Play();
    }
    public void SefeOpen()
    {
        _sefeOpen.Play();
    }
    public void WalkOnWater(bool value)
    {
        if (value == true)
            _splashingWater.Play();
        else
            _splashingWater.Stop();
    }
    public void ShockCirkit()
    {
        _highVolt.Play();
    }
    public void SecrectDoor()
    {
        _secrectDoor.Play();
    }
    public void GirlScream3()
    {
        _girlScream3.Play();
    }
    public void GirlScream4()
    {
        _girlScream4.Play();
    }
    public void FireSoundFx(bool value)
    {
        if (value == true)
            _fireFx.Play();
        else
            _fireFx.Stop();
    }
    public void DoorArea1()
    {
        _doorArea1.Play();
    }
    public void DoorArea2()
    {
        _doorArea2.Play();
    }
    public void FootStepDoor()
    {
        _footStepDoor.Play();
    }
    public void MachineGun()
    {
        _machineGun.Play();
    }
    public void MachineGunMeme()
    {
        _machineGunMeme.Play();
    }
    public void PumpWater(bool value)
    {
        if (value == true)
            _pumpWaterFx.Play();
        else
            _pumpWaterFx.Stop();
    }
    public void SwitchCrank()
    {
        _switchCrank.Play();
    }
    public void HideFx()
    {
        _hideFx.Play();
    }
    public void UseMop()
    {
        _mopFx.Play();
    }
    public void Notification()
    {
        _notification.Play();
    }
    public void CatchinEnemy(bool value)
    {
        if (value == true)
            _catchinhEnemy.Play();
        else
            _catchinhEnemy.Stop();
    }
}
