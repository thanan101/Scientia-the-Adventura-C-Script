using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpOhm : MonoBehaviour
{
    [SerializeField] GameObject _hintHelpOhm1Text;
    [SerializeField] OhmAnimControl _ohmAnim;
    public bool HelpOhmComplete = false; //Key SaveData
    public bool _minigameComplete = false; //Key SaveData
    GirlSceam1 girlSceam1;
    private void Start()
    {
        girlSceam1 = FindObjectOfType<GirlSceam1>();
    }
    private void Update()
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpOhm].complete == true)
        {
            _ohmAnim.HelpOhm = true;
            _ohmAnim.SetnewLocation();
            _ohmAnim.SetAnimation();
            Destroy(gameObject);
        }
       /* if (_minigameComplete == true && HelpOhmComplete == true) //ช่วยโอมได้
        {
            // Set Anim ของโอห์มและย้ายออกมาจากตู้
            _ohmAnim.HelpOhm = true;
            _ohmAnim.SetnewLocation();
            _ohmAnim.SetAnimation();
        }
        else if (_minigameComplete == true && HelpOhmComplete == false) //ช่วยโอมไม่ได้
        {
            // ปิดตัวละครทำหมดและ Capsule
            _ohmAnim.HelpOhm = false;
            _ohmAnim.CantSaveOhm();

        }*/
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&HelpOhmComplete==false&&_minigameComplete==false)
        {
            _hintHelpOhm1Text.SetActive(true);
            if(girlSceam1!=null)
                girlSceam1.RemoveThisEv();
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&HelpOhmComplete == false)
        {
            _hintHelpOhm1Text.SetActive(false);
        }
    }
}
