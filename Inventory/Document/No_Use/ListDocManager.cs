using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListDocManager : MonoBehaviour
{
    [SerializeField] public Button[] LearnDocumentBtnList;
    [SerializeField] public Text[] textsNameDocList;
    // Start is called before the first frame update
    void Start()
    {
        LearnDocumentBtnList = GetComponentsInChildren<Button>();
        textsNameDocList = GetComponentsInChildren<Text>();
        for (int i=0;i< LearnDocumentBtnList.Length; i++)
        {
            LearnDocumentBtnList[i].enabled = false;
            textsNameDocList[i].enabled = false;
        }
        textsNameDocList[0].enabled = true;//เปิด Text 0
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
