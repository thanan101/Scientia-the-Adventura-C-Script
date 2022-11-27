using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DocumentFleid
{
    //public  GameObject LearnDocumentBtn;
    public Text detailField;    
    [TextArea(9, 20)]
    public string detail;
    
}