using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLCloseCamera : MonoBehaviour
{
    [SerializeField] GameObject cameraVolt;
    private void OnDisable()
    {
        cameraVolt.SetActive(false);
    }
}
