using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPainting : MonoBehaviour
{
    [SerializeField] bool isHaveItemInThisLocker=false;
    [SerializeField] GameObject InteractButNoItem;
    [SerializeField] GameObject NoPower;
    [SerializeField] GameObject FoundSefeText;
    [SerializeField] GameObject insertPassWordText_Anwser1;
    [SerializeField] GameObject insertPassWordText_Anwser2;
    [SerializeField] GameObject KeyEmblemDrop;
    [SerializeField] ItemListEnum emblemDrop;

    [SerializeField] string thisSefePassword;
    [SerializeField] GameObject uiInputPassword1;
    [SerializeField] GameObject uiInputPassword2;
    [SerializeField] GameObject Password1;
    [SerializeField] GameObject Password2;
    [SerializeField] Text Fieldtext1;
    [SerializeField] Text Fieldtext2;
    [SerializeField] GameObject needPasswordTextaleart;
    [SerializeField] Text fneedPasswordSentence;

    [SerializeField] GameObject waterOnfloor;
    [SerializeField] BoxCollider2D waterOnfloorColider;
    [SerializeField] GameObject waterIcon;

    [SerializeField] GameObject HintShockCircuitText;
    bool foundSefe = false;
    public bool sefeIsOpen=false;
    private void Start()
    {
        TextFieldPasswordSetActive(false);
        if (sefeIsOpen == false&& KeyEmblemDrop != null)
            KeyEmblemDrop.SetActive(false);
        else if (sefeIsOpen == true && KeyEmblemDrop != null)
            MemoDrop();
        if (InventoryManager.Instance.gotItem[(int)emblemDrop] == true)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.OpenSreachIcon();
            if (waterOnfloor != null && isHaveItemInThisLocker == true)
            {
                waterOnfloorColider.enabled = false;
                StartCoroutine(delayForWaterIcon());
            }
            if (GameManager.Instance.powerIsGenerate == true)
                Player.Instance.VfxElectroON(true);
        }
    }
    IEnumerator delayForWaterIcon()
    {
        yield return new WaitForEndOfFrame();
        waterIcon.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SreachIcon.Instance.CloseSreachIcon();
            if (waterOnfloorColider != null && isHaveItemInThisLocker == true)
                waterOnfloorColider.enabled = true;
            if (GameManager.Instance.powerIsGenerate == true)
                Player.Instance.VfxElectroON(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            //เช็คมีน้ำไหมถ้ามีตาย
            if (GameManager.Instance.powerIsGenerate == true && waterOnfloor != null)
            {
                HintShockCircuitText.SetActive(true);
                //Dead();  //เรียกผ่าน BTN
            }
            //กรอกรหัสไหม
            else if (foundSefe == true)
            {
                if (insertPassWordText_Anwser1 != null)
                    insertPassWordText_Anwser1.SetActive(true);
                else if (insertPassWordText_Anwser2 != null)
                    insertPassWordText_Anwser2.SetActive(true);
            }
            //สำรวจได้และเจอไอเทม
            else if (GameManager.Instance.powerIsGenerate == true
                && isHaveItemInThisLocker == true)
            {
                FoundSefeText.SetActive(true);
                FoundSefe();
                //ใส่เสียงแจ้งเตือน
                SoundFxManager.Instance.Notification();
            }
            //สำรวจได้แต่ไม่มีไอเทม
            else if (GameManager.Instance.powerIsGenerate == true && 
                isHaveItemInThisLocker == false)
            {
                InteractButNoItem.SetActive(true);
            }
            //ไม่สามารถสำรวจได้เนื่องจากไม่มีกระแสไฟฟ้าให้ไขควงตรวจกระแสไฟฟ้าได้
            else if (GameManager.Instance.powerIsGenerate == false && 
                isHaveItemInThisLocker == false)
            {
                NoPower.SetActive(true);
            }
            else if (GameManager.Instance.powerIsGenerate == false &&
                isHaveItemInThisLocker == true)
            {
                NoPower.SetActive(true);
            }
        }
    }
    public void Dead()
    {
        Player.Instance.PlayeDieAnimation();
        SoundFxManager.Instance.ShockCirkit();
        //ใส่เสียงไฟช็อต
    }
    public void FoundSefe()
    {
        foundSefe = true;
    }
    public void CheckOpenSefeCondition()
    {
        //หารหัสมาใส่ //ไม่โดนไฟช็อค
        if (foundSefe == true)
        {
            //aleartText.text = "ต้องกรอกรหัสเพื่อเปิดตู้เซฟนี้";
            CloseBugUI();
            TextFieldPasswordSetActive(true);
        }
    }
    public void CheackSefePassWord()
    {
        if (Fieldtext1 != null)
        {
            if (Fieldtext1.text == thisSefePassword)
            {
                CorrectSefe();
            }
            else
            {
                needPasswordTextaleart.SetActive(true);
                fneedPasswordSentence.text = "ต้องมีรหัสผ่านที่ถูกต้อง..";
            }
        TextFieldPasswordSetActive(false);
        }
        else if (Fieldtext2 != null)
        {
            if (Fieldtext2.text == thisSefePassword)
            {
                CorrectSefe();
            }
            else
                needPasswordTextaleart.SetActive(true);

        }
        TextFieldPasswordSetActive(false);
    }
    public void MemoDrop()
    {
        KeyEmblemDrop.SetActive(true);
    }
    void CorrectSefe()
    {
        GameManager.Instance.EnableUIDisplay(false);
        KeyEmblemDrop.SetActive(true);
        SoundFxManager.Instance.SefeOpen();
        Destroy(gameObject);
    }
    void TextFieldPasswordSetActive(bool isActive)
    {
        if (Password1 != null)
            Password1.SetActive(isActive);
        else if (Password2 != null)
            Password2.SetActive(isActive);
        if (uiInputPassword1 != null)
            uiInputPassword1.SetActive(isActive);
        else if (uiInputPassword2 != null)
            uiInputPassword2.SetActive(isActive);
    }
    public void CloseBugUI()
    {
        StartCoroutine(DelayDiasabelUI());
    }
    IEnumerator DelayDiasabelUI()
    {
        yield return new WaitForEndOfFrame();
        GameManager.Instance.EnableUIDisplay(false);
    }

}
