using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhmAnimControl : MonoBehaviour
{
    /// <summary>
    private static OhmAnimControl _instance;
    public static OhmAnimControl Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("OhmAnimControl is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>

    Animator _anim;
    [SerializeField] GameObject _selfOhm;

    public bool HelpOhm=false;
    private void Update()
    {
        if (QuestManager.Instance.questsList[(int)
            QuestListEnum.HelpOhm].complete == true)
        {
            HelpOhm = true;
            SetAnimation();
            SetnewLocation();
        }
    }
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();       
        StartCoroutine(StandbyCheack());

    }
    IEnumerator StandbyCheack()
    {
        yield return new WaitForSeconds(1.5f);
        if (QuestManager.Instance.questsList[(int)
            QuestListEnum.HelpOhm].complete == true)
        {
            HelpOhm = true;
            SetnewLocation();
        }
        SetAnimation();
    }
    public void SetAnimation()
    {
        if (HelpOhm == false)
        {
            _anim.SetBool("inCapsule", true);
        }
        else
        {
            _anim.SetBool("inCapsule", false);
        }
    }
    public void SetnewLocation()
    {
        _selfOhm.transform.position = new Vector3(-24, -13, 11);
    }
    public void CantSaveOhm()
    {
        _selfOhm.SetActive(false);
    }

    
}
