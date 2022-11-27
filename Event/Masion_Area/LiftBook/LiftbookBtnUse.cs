using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftbookBtnUse : MonoBehaviour
{
    [SerializeField] public GameObject[] itemDorpFormLift;
    [SerializeField] public GameObject[] isUseListTextRoom;
    [SerializeField] public GameObject[] cameraLift;
    public int item;
    public void DropItem()
    {
        itemDorpFormLift[item].SetActive(true);
        GameManager.Instance.LiftitemUse[item] = true;
        cameraLift[item].SetActive(true);
        GameManager.Instance.EnableUIDisplay(false);
        Player.Instance.PlayerCanNotMove();
        SoundFxManager.Instance.LiftBookFx();
        StartCoroutine(CameraAtLift());
    }
    IEnumerator CameraAtLift()
    {
        yield return new WaitForSecondsRealtime(3f);
        cameraLift[item].SetActive(false);
        isUseListTextRoom[item].SetActive(true);
    }
}
