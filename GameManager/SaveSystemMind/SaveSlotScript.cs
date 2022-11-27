    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotScript : MonoBehaviour
{
    [SerializeField] GameObject saveSlotUI;
    [SerializeField] GameObject SaveOrLoadUI;
    public void SelectThisSlot(int slotNuber)
    {
        SaveLoadManager.Instance.SetPathsSlot(slotNuber);
        SoundFxManager.Instance.ClickSoundFx();
        SaveOrLoadUI.SetActive(true);
        saveSlotUI.SetActive(false);
    }
    public void CloseUI()
    {
        SaveOrLoadUI.SetActive(false);
    }

}
