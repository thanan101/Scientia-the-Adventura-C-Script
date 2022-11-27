using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusCrew : MonoBehaviour
{
    [SerializeField]GameObject screwLightStatus;
    [SerializeField] Color ErectricColor;
    [SerializeField]Color noErectircColor;
    [SerializeField] float delayTurnTime=2;
    [SerializeField] GameObject textHintScrewAndHand;
    public void TrueWire()
    {
        if (screwLightStatus != null)
        {
            screwLightStatus.SetActive(true);
            StartCoroutine(TrunToBlackColor());
        }
    }
    IEnumerator TrunToBlackColor()
    {
        yield return new WaitForSecondsRealtime(delayTurnTime);
        if (screwLightStatus != null)
            screwLightStatus.SetActive(false);
    }
    public void WrongWire()
    {
        if (screwLightStatus != null)
        {
            StopCoroutine(TrunToBlackColor());
            screwLightStatus.SetActive(false);
        }
    }
    public void Hint()
    {
        Debug.Log("True");
        textHintScrewAndHand.SetActive(true);
    }
}
