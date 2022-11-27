using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]GameObject MinigameUi;
    [SerializeField] GameObject Door;
    DoorLockAiRoom doorLock;
    private void Start()
    {
        Door.SetActive(false);
        doorLock = FindObjectOfType<DoorLockAiRoom>();
    }
    public void OpenTheDooe()
    {
        //MinigameUi.SetActive(false);
        Destroy(MinigameUi);
        GameManager.Instance.EnableUIDisplay(true);
        Door.SetActive(true);
        CursorManger.Instance.ResetCursor();
        doorLock.ClearMinigame();
    }

}
