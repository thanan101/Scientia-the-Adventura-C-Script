using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingOnWater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WaterOnFloor")
            SoundFxManager.Instance.WalkOnWater(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WaterOnFloor")
            SoundFxManager.Instance.WalkOnWater(false);
    }
}
