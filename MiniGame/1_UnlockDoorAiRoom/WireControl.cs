using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireControl : MonoBehaviour
{
    /// <summary>
    private static WireControl _instance;
    public static WireControl Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("WireControl is NULL");
            }
            return _instance;
        }        
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>
    
    [SerializeField] private Texture2D TrueCursorScrew;
    [SerializeField] private Texture2D WorngCursorScrew;
    private Vector2 cursorHotspot;
    public void TrueWireFunc()
    {
        cursorHotspot = new Vector2(TrueCursorScrew.width / 2, TrueCursorScrew.height / 2);
        Cursor.SetCursor(TrueCursorScrew, cursorHotspot, CursorMode.Auto);
    }
    public void WrongWireFunc()
    {
        cursorHotspot = new Vector2(WorngCursorScrew.width / 2, WorngCursorScrew.height / 2);
        Cursor.SetCursor(WorngCursorScrew, cursorHotspot, CursorMode.Auto);
    }
}
