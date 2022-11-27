using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpVoltFirst : MonoBehaviour
{
    [SerializeField]GameObject doorToLibary;
    [SerializeField]GameObject helpVoltText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpVolt].complete == true)
            {
                doorToLibary.SetActive(true);
                Destroy(gameObject);
            }
            else
                helpVoltText.SetActive(true);
                
        }
    }
}
