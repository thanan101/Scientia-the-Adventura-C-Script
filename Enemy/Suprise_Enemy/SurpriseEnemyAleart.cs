using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseEnemyAleart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            AleartenemyIcon.Instance.OpenAleartEnemyIcon();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            AleartenemyIcon.Instance.CloseAleartEnemyIcon();
    }
}
