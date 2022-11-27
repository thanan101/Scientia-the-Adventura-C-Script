using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManger : MonoBehaviour
{
    /// <summary>
    private static CursorManger _instance;
    public static CursorManger Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("_CursorManger is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>
    /// 
    [SerializeField] private Texture2D DefCursor;
    private Vector2 cursorHotspot;
    private void Start()
    {
        ResetCursor();
    }
    public void ResetCursor()
    {

        cursorHotspot = new Vector2(DefCursor.width / 2, DefCursor.height / 2);
        Cursor.SetCursor(DefCursor, cursorHotspot, CursorMode.Auto);
    }
}
