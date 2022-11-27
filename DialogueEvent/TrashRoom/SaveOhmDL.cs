using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOhmDL : MonoBehaviour
{
    [SerializeField] GameObject Event3A;
    [SerializeField] GameObject Event3B;
    [SerializeField] GameObject itemKeyCardDrop;
    //public bool saveOhm = false;
    private void Update()
    {
        KEyCardDrop();
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpOhm].complete == true &&
            CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event3A] == true &&
            InventoryManager.Instance.gotItem[(int)ItemListEnum.KeyCardAreaB] == true)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(DelyathisFunc());
    }
   
    IEnumerator DelyathisFunc()
    {
        yield return new WaitForSeconds(3);
        if (Event3A != null && Event3B != null)
        {
            Event3A.SetActive(false);
            Event3B.SetActive(false);
            itemKeyCardDrop.SetActive(false);
        }
        if (QuestManager.Instance.questsList[(int)QuestListEnum.HelpOhm].complete == true)
        {
            SaveOhm();
        }
        KEyCardDrop();
    }
    public void SaveOhm()
    {
        Event3A.SetActive(true);
        Destroy(Event3B);
        CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event3B] = true;
    }
    public void CannotSaveOhm()
    {
        Event3B.SetActive(true);
        Destroy(Event3A);
        CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event3A] = true;
    }
    public void KEyCardDrop()
    {
        if (CompleteDialogueEv.Instance.DialogueComplete[(int)dialogueNameList.Event3A] == true)
            itemKeyCardDrop.SetActive(true);
    }




}
