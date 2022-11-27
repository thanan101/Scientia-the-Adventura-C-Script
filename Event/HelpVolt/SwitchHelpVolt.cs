using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHelpVolt : MonoBehaviour
{
    [SerializeField] GameObject useSwtichTextAwnser;
    [SerializeField] GameObject baseVolt;
    [SerializeField] GameObject cameraAtVolt;
    [SerializeField] HelpVoltDialogue helpVoltDialog;
    [SerializeField] DialoguePlayist helpVoltDialogeSentence;
    private void Start()
    {
        StartCoroutine(DelayCheack());
    }
    IEnumerator DelayCheack()
    {
        yield return new WaitForEndOfFrame();
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpVolt].complete == true)
        {
            Destroy(baseVolt);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.OpenSreachIcon();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SreachIcon.Instance.CloseSreachIcon();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player")
        {
            useSwtichTextAwnser.SetActive(true);
        }
    }
    public void UseSwitch()
    {
        if (GameManager.Instance.isDrainWater == true)
        {
            Destroy(baseVolt);
            cameraAtVolt.SetActive(true);
            //StartCoroutine(ClosUpCamera());
            VoltAnimation voltAnimation = FindObjectOfType<VoltAnimation>();
            voltAnimation.SetVoltAnimation();
            helpVoltDialog.SetCamera(cameraAtVolt);
            StartCoroutine(DelayForANimationBug());
            SoundFxManager.Instance.SwitchCrank();
        }
        
    }
    IEnumerator DelayForANimationBug()
    {
        yield return new WaitForSecondsRealtime(2f);
        helpVoltDialogeSentence.TrigerPlaylist();
        Destroy(gameObject);
    }
    IEnumerator ClosUpCamera()
    {
        yield return new WaitForSecondsRealtime(3f);
        cameraAtVolt.SetActive(false);
        Destroy(gameObject);
    }
}
