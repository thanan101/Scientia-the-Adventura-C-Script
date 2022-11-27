using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMemoFixbugWontDestroy : MonoBehaviour
{
    public ItemListEnum itemIndex;
    private void Update()
    {
        if (InventoryManager.Instance.gotItem[(int)itemIndex] == true)
            Destroy(gameObject);

    }
}
