using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHelpFriend : MonoBehaviour
{
    
    /// <summary>
    private static ShowHelpFriend _instance;
    public static ShowHelpFriend Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("ShowHelpFriend is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>
    
    [SerializeField]List<GameObject> greyHeadIcon;
    [SerializeField]List<GameObject> normalHeadIcon;

    private void Start()
    {
        for (int i = 0; i < normalHeadIcon.Count; i++)
            normalHeadIcon[i].SetActive(false);
        StartCoroutine(PrepareStart());
    }
    IEnumerator PrepareStart()
    {
        yield return new WaitForSeconds(0.5f);
        CheackHelpFriend();
    }
    private void Update()
    {
        CheackHelpFriend();
    }
    public void CheackHelpFriend()//ให้ฟัง Script Quest ที่เกี่ยวข้องเรียกใช้
    {
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpOhm].complete == true)
            normalHeadIcon[0].SetActive(true); 
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpWatt].complete == true)
            normalHeadIcon[1].SetActive(true);
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpVolt].complete == true)
        {
            /*if(GameManager.Instance.knowVoltisGone==true)
                normalHeadIcon[2].SetActive(false);
            else
                normalHeadIcon[2].SetActive(true);*/
            normalHeadIcon[2].SetActive(true);
        }
            
        if (QuestManager.Instance.questsList[(int)QuestListEnum.FindKeyAndHelpAMp].complete == true)
            normalHeadIcon[3].SetActive(true);

    }
}
