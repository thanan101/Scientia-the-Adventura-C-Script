using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerGeneratorControl : MonoBehaviour
{
    public bool powerIsGenerate;
    [SerializeField] GameObject turnPowerGeneratorText;
    [SerializeField] Text textBoxTurnPower;
    [SerializeField] GameObject cellingLight;
    private void Update()
    {
        if (GameManager.Instance.powerIsGenerate == true)
            cellingLight.SetActive(true);
        else
            cellingLight.SetActive(false);
    }
    private void Start()
    {
        StartCoroutine(delaycheack());
    }
    IEnumerator delaycheack()
    {
        yield return new WaitForEndOfFrame();
        powerIsGenerate = GameManager.Instance.powerIsGenerate;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if (powerIsGenerate == true)
                turnPowerGeneratorText.SetActive(true);
            else
                turnPowerGeneratorText.SetActive(true);
            StartCoroutine(setText());
        } 
    }
    IEnumerator setText()
    {
        yield return new WaitForEndOfFrame();

        if (powerIsGenerate == true)
            textBoxTurnPower.text = "ต้องการ ปิด เครื่องปั่นไฟหรือไม่";
        else
            textBoxTurnPower.text = "ต้องการ เปิด เครื่องปั่นไฟหรือไม่";
    }
    public void TurnPowerGeneretor()
    {
        if (powerIsGenerate == true)
        {
            powerIsGenerate = false;
            SoundFxManager.Instance.PowerDown();
        }
        else
        {
            powerIsGenerate = true;
            SoundFxManager.Instance.PowerDown();
        }
        GameManager.Instance.powerIsGenerate = powerIsGenerate;
        turnPowerGeneratorText.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.OpenSreachIcon();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.CloseSreachIcon();
    }

}
