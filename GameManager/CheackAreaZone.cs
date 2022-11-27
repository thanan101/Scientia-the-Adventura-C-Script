using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AreaZoneEnum
{
    ResreachB1F,
    ResreachB2F,
    ResreachA,

}
public class CheackAreaZone : MonoBehaviour
{
    public AreaZoneEnum areaZoneID;
    GameManager gameManager;
    bool isnowinArea = false;
    private void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&isnowinArea==false)
        {
            if (areaZoneID == AreaZoneEnum.ResreachB1F)
            {
                gameManager.PlayerIsNowReserchB1F();
            }
        }
    }
}
