using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationNavigator : MonoBehaviour
{
    TextNavigator textNavigator;
    public string RoomName;
    private void Awake()
    {
        textNavigator = FindObjectOfType<TextNavigator>();
    }
    private void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            textNavigator.textNavi.text = RoomName;
    }
}
