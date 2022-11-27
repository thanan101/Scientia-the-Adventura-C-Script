using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxOnEnable : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool isOnEnable;
    private void OnEnable()
    {
        if (isOnEnable == true)
            audioSource.Play();
    }
    private void OnDisable()
    {
        if (isOnEnable == false)
            audioSource.Play();
    }
}
