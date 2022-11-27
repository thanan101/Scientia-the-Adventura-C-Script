using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRoomDoorIcon : MonoBehaviour
{
    [SerializeField] GameObject _icondoor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _icondoor.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _icondoor.SetActive(false);
        }
    }
}
