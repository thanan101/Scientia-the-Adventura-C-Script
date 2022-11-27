using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellEnegy : MonoBehaviour
{
    BoxCollider2D boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (InventoryManager.Instance.gotItem[(int)ItemListEnum.NewCellBatery] == true)
        {
            boxCollider.enabled = true;
        }
    }
}
