using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRoomCameraControl : MonoBehaviour
{
    [SerializeField] GameObject AiRoomCamera;
    [SerializeField] bool isActiveCamera;
    private void OnEnable()
    {
        if (isActiveCamera == true)
            AiRoomCamera.SetActive(true);
    }
    private void OnDisable()
    {
        if (isActiveCamera == false)
            AiRoomCamera.SetActive(false);
    }
}
