using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera2D : MonoBehaviour
{
    [SerializeField] float FollowSpeed =10f;
    [SerializeField] Transform Player;
    void Update()
    {
        Vector3 newPos = new Vector3(Player.position.x, Player.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
