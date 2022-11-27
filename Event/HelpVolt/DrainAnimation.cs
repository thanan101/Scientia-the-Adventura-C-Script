using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainAnimation : MonoBehaviour
{
    [SerializeField] CheackWineRoom cheackWineScript;
    public void SwitchCamera()
    {
        cheackWineScript.cameraVolt.SetActive(false);
        SoundFxManager.Instance.PumpWater(false);
    }
}
