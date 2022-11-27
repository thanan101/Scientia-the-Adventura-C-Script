using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuest3FindItem : AbstractSideQuest
{
    public override void Update()
    {
        base.Update();
        if (InventoryManager.Instance.gotItem[(int)ItemListEnum.Fuse30] == true)
        {
            QuestComplete();
        }
        
    }
}
