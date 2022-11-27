using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1DLPlay : MonoBehaviour
{
    [SerializeField] GameObject Quest;
    [SerializeField] GameObject blockEnemy;
    private void OnDisable()
    {
        Quest.SetActive(true);
        if (blockEnemy != null)
        {
            Destroy(blockEnemy);
        }
    }
    private void OnDestroy()
    {
        Quest.SetActive(true);
        if (blockEnemy != null)
        {
            Destroy(blockEnemy);
        }
    }
}
