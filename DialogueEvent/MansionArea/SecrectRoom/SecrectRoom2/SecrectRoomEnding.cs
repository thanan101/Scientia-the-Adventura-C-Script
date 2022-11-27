using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecrectRoomEnding : MonoBehaviour
{
    [SerializeField] DialoguePlayist goodEnding;
    [SerializeField] DialoguePlayist badEnding;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.Instance.PlayerCanNotMove();
            if (InventoryManager.Instance.gotItem[(int)ItemListEnum.Diary1] == true &&
            InventoryManager.Instance.gotItem[(int)ItemListEnum.Diary2] == true &&
            InventoryManager.Instance.gotItem[(int)ItemListEnum.Diary3] == true)
                goodEnding.TrigerPlaylist();
            else
                badEnding.TrigerPlaylist();
        }
        
    }
}
