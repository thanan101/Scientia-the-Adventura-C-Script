using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckNumber : MonoBehaviour
{
    public int countBottonDown = 0;

    int numBer1;
    int numBer2;
    int numBer3;

    public int sumNumber;

    [SerializeField] Text DisplayText;

    [SerializeField] GameObject LightGreenBar;
    [SerializeField] GameObject LightRedBar;
    [SerializeField] Animator GreenBar;
    [SerializeField] Animator RedBar;

    

    void Start()
    {
        LightGreenBar.SetActive(false);
        LightRedBar.SetActive(false);

        GreenBar.enabled = false;
        RedBar.enabled = false;
    }

    public void calculator(int numBer)
    {
        if(countBottonDown <= 3)
        {
            countBottonDown++;
            if(countBottonDown == 1)
            {
                numBer1 = numBer;
                sumNumber = numBer1;
                DisplayObjective();
            }
            else if(countBottonDown == 2)
            {
                numBer2 = numBer;
                sumNumber = numBer2 + numBer1;
                DisplayObjective();
            }
            else if (countBottonDown == 3)
            {
                numBer3 = numBer;
                sumNumber = numBer3 + numBer2 + numBer1;
                DisplayObjective();
            }
        }
        
    }
    public void DisplayObjective()
    {
        int IncreaseNum = sumNumber;
        DisplayText.text = IncreaseNum.ToString();

    }

    public void playerAct()
    {

        if (sumNumber == 10)
        {
            LightGreenBar.SetActive(true);
            GreenBar.enabled = true;
            QuestManager.Instance.sideQuestsList[(int)SideQuestListEnum.UseRailgunSaveWatt].complete = true;
        }
        else
        {
            LightRedBar.SetActive(true);
            RedBar.enabled = true;
            QuestManager.Instance.sideQuestsList[(int)SideQuestListEnum.UseRailgunSaveWatt].complete = false;
        }

    }

    public void SetDefaults()
    {
        countBottonDown = 0;
        sumNumber = 0;
        Debug.Log(sumNumber);

        DisplayObjective();
    }
}
