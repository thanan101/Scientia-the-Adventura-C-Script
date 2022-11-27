using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMainQuest : MonoBehaviour
{
    public Text mainQuestText;
    void Start()
    {
        mainQuestText = GetComponent<Text>();
    }
}
