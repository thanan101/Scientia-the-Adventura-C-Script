using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2Dontdie : AbstractQuest
{
    [SerializeField]Quest1GetoutFormThisRoom quest1;
    [SerializeField]GameObject Enemy;
    [SerializeField] GameObject blockEnemy;
    [SerializeField] GameObject fadeScreenFx;
    [SerializeField] float delayDisableUI;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
          if (quest1 != null)
          {
                quest1.QuestComplete();
          }
        base.OnTriggerEnter2D(collision);
        StartCoroutine(delay());
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
        Destroy(blockEnemy);
    }
    IEnumerator DelayDisableUI()
    {
        yield return new WaitForSeconds(delayDisableUI);
        GameManager.Instance.EnableUIDisplay(false);
    }

}
