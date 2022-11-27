using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnSurpriseEnemy : MonoBehaviour
{
    [SerializeField] GameObject surpriseEnenmy;
    bool isSpawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("isRandom");
            RandomEV();
            if (isSpawn)
            {
                surpriseEnenmy.SetActive(true);
            }
        }
    }
    void RandomEV()
    {
        int rate = Random.Range(0, 2);
        Debug.Log(rate);
        if (rate == 0)
            isSpawn = true;
        else
            isSpawn = false;
    }
}
