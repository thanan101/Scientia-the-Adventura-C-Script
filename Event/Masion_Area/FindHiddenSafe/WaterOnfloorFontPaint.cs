using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterOnfloorFontPaint : MonoBehaviour
{
    public bool waterStillOnfloor = true;
    [SerializeField]GameObject waterIcon;
    [SerializeField] GameObject useMopTextAnwser;
    public int waterpaint;
    [SerializeField]CheackMopTextAnwser cheackUseMopText;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    //สำหรับTextAleart
    [SerializeField][TextArea] string useMopnowSentence;
    [SerializeField][TextArea] string noMopSentence;
    //[SerializeField] Text statusMopSentence;
    [SerializeField] GameObject textAleartUseMop;
    [SerializeField] GameObject textAleartNeedMop;

    [SerializeField] GameObject iconUseMop;
    [SerializeField] BoxCollider2D thisSefeAbroveWaterColider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        StartCoroutine(delayCheack());
    }
    IEnumerator delayCheack()
    {
        yield return new WaitForEndOfFrame();
        if (waterStillOnfloor == false)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"&& waterStillOnfloor == true )
        {
            if (InventoryManager.Instance.gotItem[(int)ItemListEnum.Mop] == true)
            {
                InteractWitchWaterOnly();
            }
            else if (GameManager.Instance.powerIsGenerate == false)
            {
                InteractWitchWaterOnly();
            }
            else if (GameManager.Instance.powerIsGenerate == true)
            {
                waterIcon.SetActive(true);
            }
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && waterStillOnfloor == true)
        {
            if (InventoryManager.Instance.gotItem[(int)ItemListEnum.Mop] == true)
            {
                iconUseMop.SetActive(false);
                waterIcon.SetActive(false);
                thisSefeAbroveWaterColider.enabled = true;
            }
            else if (GameManager.Instance.powerIsGenerate == false)
            {
                iconUseMop.SetActive(false);
                waterIcon.SetActive(false);
                thisSefeAbroveWaterColider.enabled = true;
            }
            else if (GameManager.Instance.powerIsGenerate == true)
            {
                waterIcon.SetActive(false);
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && waterStillOnfloor == true
            && Input.GetKeyDown(KeyCode.F))
        {
            cheackUseMopText.ThisWater(waterpaint);
            useMopTextAnwser.SetActive(true);
        }           
    }
    public void ThisWaterOnfloor()
    {
        //HaveMop
        if (InventoryManager.Instance.gotItem[(int)ItemListEnum.Mop] == true)
        {
            textAleartUseMop.SetActive(true);
            waterStillOnfloor = false;
            waterIcon.SetActive(false);
            iconUseMop.SetActive(false);
            thisSefeAbroveWaterColider.enabled = true;//เปิดให้สามารถมา Interact กับ Sefe ได้
            SoundFxManager.Instance.UseMop();//ใส่เสียงถูพื้น
            Destroy(gameObject);
        }
        else
        {
            textAleartNeedMop.SetActive(true);
        }
        
    }
    void InteractWitchWaterOnly()
    {
        iconUseMop.SetActive(true);
        waterIcon.SetActive(true);
        thisSefeAbroveWaterColider.enabled = false;
    }

}
