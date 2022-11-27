using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuest1FindScrew : AbstractSideQuest
{
    public override  void Update()
    {
        if (InventoryManager.Instance.gotItem[1] == true)
        {
            QuestComplete();
            //Debug.Log("Im Runn");
            Destroy(gameObject);
        }
        base.Update();
    }
}
