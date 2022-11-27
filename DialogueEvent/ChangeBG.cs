using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeBG : MonoBehaviour
{
    [SerializeField] Sprite[] bgVisualNovel;
    [SerializeField] Image ImmageCompenent;
    public int visualNovel;
    private void OnDisable()
    {
        ImmageCompenent.sprite = bgVisualNovel[(int)visualNovel];
    }
}
