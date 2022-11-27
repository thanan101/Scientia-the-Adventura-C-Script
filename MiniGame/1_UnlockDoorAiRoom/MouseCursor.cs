using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour
{
    public RectTransform MovingObj;
    public Vector3 offset;
    public RectTransform BasicObj;
    public Camera cam;
    private void Update()
    {
        MoveObj();
    }
    public void MoveObj()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = BasicObj.position.z;
        MovingObj.position = cam.ScreenToWorldPoint(pos);
    }
}
