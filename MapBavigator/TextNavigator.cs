using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextNavigator : MonoBehaviour
{
   public  Text textNavi;
    void Start()
    {
        textNavi = GetComponent<Text>();
    }
}
