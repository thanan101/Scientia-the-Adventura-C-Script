using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashFollowMouse : MonoBehaviour
{
    public Transform FlashAim;

    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        lookDirection = Camera.main.WorldToScreenPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        FlashAim.rotation = Quaternion.Euler(0, 0, lookAngle);
    }
}
