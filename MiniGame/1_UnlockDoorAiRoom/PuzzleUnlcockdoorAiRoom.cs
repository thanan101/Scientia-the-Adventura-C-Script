using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleUnlcockdoorAiRoom : MonoBehaviour
{
    /// <summary> �Ѵ����ͤ͹
    [SerializeField] private Texture2D ScrewIcon;
    [SerializeField] private Texture2D HandIcon;
    private Vector2 cursorHotspot;
    /// </summary>

    public int Unscrew = 4;
    [SerializeField] GameObject CoverObj;
    [SerializeField] Button Cover;
    [SerializeField] Button[] Knot;
    [SerializeField] Button[] Wire;
    [SerializeField] Button[] Switch;
    [SerializeField] GameObject screwStatus;
    private void Start()
    {
        CoverObj.SetActive(true);
        DisableCoverBtn();
        DisableKnotAndWireAndBtn();
        DisableSwitch();
    }
    private void OnEnable()
    {
        GameManager.Instance.EnableUIDisplay(false);
    }
    public void UnscrewCount()//�礹�͵���ѹ�͡����
    {
        Unscrew--;      
    }
    public void EnableCoverBtn()//�Ǻ����һԴ
    {
        if (Unscrew <= 0)
        {
            Cover.enabled = true;
        }
    }
    public void DisableCoverBtn()//�Ǻ����һԴ
    {
        Cover.enabled = false;
    }
    public void EnableKnotAndWireAndBtn()//�Դ�������ö�ѹ��͵�� �������¡��ҹ Btn Screw
    {
        for (int i = 0; i < Knot.Length; i++)
        {
            Knot[i].enabled = true;
        }
        for (int i = 0; i < Wire.Length; i++)
        {
            Wire[i].enabled = true;
        }
        for(int i = 0; i < Switch.Length; i++)
        {
            Switch[i].enabled = false;
        }
    }
    public void DisableKnotAndWireAndBtn() //�Դ���ѹ��͵����͹仡� Btn �������
    {
        for (int i = 0; i < Knot.Length; i++)
        {
            Knot[i].enabled = false;
        }
        for (int i = 0; i < Wire.Length; i++)
        {
            Wire[i].enabled = false;
        }
        
    }
    public void DisableSwitch()
    {
        for (int i = 0; i < Switch.Length; i++)
        {
            Switch[i].enabled = false;
        }
    }
    public void SelectScrew()
    {
        cursorHotspot = new Vector2(ScrewIcon.width / 2, ScrewIcon.height / 2);
        Cursor.SetCursor(ScrewIcon, cursorHotspot, CursorMode.Auto);
        screwStatus.SetActive(true);
        DisableSwitch();
    }
    public void SelectHand()
    {
        cursorHotspot = new Vector2(HandIcon.width / 2, HandIcon.height / 2);
        Cursor.SetCursor(HandIcon, cursorHotspot, CursorMode.Auto);
        screwStatus.SetActive(false);
        for (int i = 0; i < Switch.Length; i++)
        {
            Switch[i].enabled = true;
        }
    }
}
