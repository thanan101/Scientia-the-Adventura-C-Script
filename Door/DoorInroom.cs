using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInroom : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _spawnLocation;
    [SerializeField] GameObject _fadeON;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player.transform.position = _spawnLocation.transform.position;
            _fadeON.SetActive(true);
        }
    }
}
