using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseEnemyDirectionEnd : MonoBehaviour
{
    [SerializeField] GameObject thisEnemy;
    [SerializeField] SurpriseEnemy surpriseEnemyScript;
    [SerializeField] int dirctionChange;
    [SerializeField] bool endSurpriseEnemy = false;
    [SerializeField] int surpriseEnemyAray_IndexID;
    [SerializeField] float delayStandEnemy=3f;
    [SerializeField] bool siggleTimeEv = false;
    private void Start()
    {
        if(siggleTimeEv==true)
            StartCoroutine(delayCheackStart());
    }
    IEnumerator delayCheackStart()
    {
        yield return new WaitForEndOfFrame();
        if (GameManager.Instance.SurpriseEnemyAray[surpriseEnemyAray_IndexID] == true)
        {
            DestroyOBJ();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (GameManager.Instance.SurpriseEnemyAray[surpriseEnemyAray_IndexID] == false
                && siggleTimeEv == true)
            {
                /*if (surpriseEnemyScript.stopAllCuroutine == true)
                {
                    StopAllCoroutines();
                }
                else*/ if (endSurpriseEnemy == false)
                {
                    surpriseEnemyScript.direction = 0;
                    StartCoroutine(delayUTune());
                }
                else if (endSurpriseEnemy == true)
                {
                    GameManager.Instance.SurpriseEnemyAray[surpriseEnemyAray_IndexID] = true;
                    DestroyOBJ();
                }
            }
            else if (siggleTimeEv == false)
            {
                if (endSurpriseEnemy == false)
                {
                    surpriseEnemyScript.direction = 0;
                    StartCoroutine(delayUTune());
                }
                else if (endSurpriseEnemy == true)
                {
                    DestroyOBJ();
                }
            }
            
        }
    }
    void DestroyOBJ()
    {
        BgmManager.Instance.EnemyPursue(false);
        if (siggleTimeEv == true)
        {
            Destroy(thisEnemy);
            Destroy(gameObject);
        }
        else if(siggleTimeEv == false)
        {
            thisEnemy.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    IEnumerator delayUTune()
    {
        yield return new WaitForSeconds(delayStandEnemy);
        surpriseEnemyScript.direction = dirctionChange;
    }
}
