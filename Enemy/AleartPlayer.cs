using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleartPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AleartenemyIcon.Instance.OpenAleartEnemyIcon();
            SoundFxManager.Instance.CatchinEnemy(true);
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AleartenemyIcon.Instance.CloseAleartEnemyIcon();
            SoundFxManager.Instance.CatchinEnemy(true);
        }
            
    }
}
