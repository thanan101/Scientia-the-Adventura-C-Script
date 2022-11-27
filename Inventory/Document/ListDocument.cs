using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListDocument : MonoBehaviour
{
    [SerializeField]GameObject detailPic;
    public string NameDocument;
    public Text TextNameDoc;
    public DocumentFleid documentFleid;
    private void OnEnable()
    {
        SetList();
    }
    public void SetList()
    {
        TextNameDoc.text = NameDocument;
    }
    public void SeeDetailThisDoc()
    {
        if(documentFleid.detailField!=null&& documentFleid.detail != null)
        {
            documentFleid.detailField.text = documentFleid.detail;
        }
        
        if (detailPic != null)
        {
            detailPic.SetActive(true);
        }
        
    }
}
