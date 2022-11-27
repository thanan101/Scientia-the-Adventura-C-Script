using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffFlashlight : MonoBehaviour
{
    [SerializeField] GameObject[] flashLightAndBoxColider;
    [SerializeField] GameObject falshLightHintText;
    [SerializeField] Image flashLightImage_Icon;
    [SerializeField] Sprite[] flashLightIconStatus;
    bool hintFlashLight_trigger=false;
    public bool flashLightTrriger=false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (flashLightTrriger == false)
                FlashLightOn();
            else if (flashLightTrriger == true)
                FlashLightOff();
        }
    }
    public void ButtonFlashLight()
    {
        if (flashLightTrriger == false)
            FlashLightOn();
        else if (flashLightTrriger == true)
            FlashLightOff();
    }
     void FlashLightOn()
    {
        CheckHint();
        EnableFlashLight(true);
        StartCoroutine(SetFlashLightTrigger(true));
        flashLightImage_Icon.sprite = flashLightIconStatus[0];
    }
     void FlashLightOff()
    {
       CheckHint();
        EnableFlashLight(false);
        StartCoroutine(SetFlashLightTrigger(false));
        flashLightImage_Icon.sprite = flashLightIconStatus[1];
    }
    IEnumerator SetFlashLightTrigger(bool trigger)
    {
        yield return new WaitForSeconds(1f);
        flashLightTrriger = trigger;
    }
    void CheckHint()
    {
        if (hintFlashLight_trigger == false)
        {
            falshLightHintText.SetActive(true);
            hintFlashLight_trigger = true;
        }
    }
    void EnableFlashLight(bool trigger)
    {
        SoundFxManager.Instance.FlashlightOnOff();
        for (int i = 0; i < flashLightAndBoxColider.Length; i++)
            flashLightAndBoxColider[i].SetActive(trigger);
    }
}
