using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpScreamFXDialog : MonoBehaviour
{
    private void OnEnable()
    {
        SoundFxManager.Instance.GirlScream3();
    }
}
