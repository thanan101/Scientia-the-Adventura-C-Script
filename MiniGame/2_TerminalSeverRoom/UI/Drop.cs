using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void CheackDropPosition()
    {
        if (rectTransform.position.x <= -277 && rectTransform.position.x >= -337)
        {
            rectTransform.position = new Vector3 (-307, -15, 0);
        }
    }
}
