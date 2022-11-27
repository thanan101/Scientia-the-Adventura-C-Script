using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakerKitchenRoom : MonoBehaviour
{
    [SerializeField]GameObject useSwitchBraker;
    [SerializeField]GameObject isUsenow;
    [SerializeField] GameObject LightKitchenAndFoodRoom;
    [SerializeField] GameObject surpriseEnenmy;

    private void Start()
    {
        CheackLoad();
    }
    private void Update()
    {
        CheackLightOut();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            SreachIcon.Instance.OpenSreachIcon();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.CloseSreachIcon();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player" &&
            GameManager.Instance.useSwitchBraker == false)
            useSwitchBraker.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player" &&
            GameManager.Instance.useSwitchBraker == true)
            isUsenow.SetActive(true);
    }
    public void UseBraker()
    {
        GameManager.Instance.useSwitchBraker = true;
        LightKitchenAndFoodRoom.SetActive(false);
        SoundFxManager.Instance.PowerDown();
        if(surpriseEnenmy!=null)
            surpriseEnenmy.SetActive(true);
    }
    IEnumerator CheackLoad()
    {
        yield return new WaitForSeconds(3f);
        CheackLightOut();
    }
    void CheackLightOut()
    {
        if (GameManager.Instance.useSwitchBraker == true)
        {
            LightKitchenAndFoodRoom.SetActive(false);
            Debug.Log("ไฟดับแล้ว");
        }
        else
            LightKitchenAndFoodRoom.SetActive(true);
    }

}
