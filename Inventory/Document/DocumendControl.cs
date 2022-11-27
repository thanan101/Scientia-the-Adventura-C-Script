using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumendControl : MonoBehaviour
{
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject Document;
    public int currentPageDocument = 1;
    [SerializeField] GameObject[] pageDocument; //ใส่หน้าไอเทมหน้าอื่นๆ
    private void Start()
    {
        ResetPage();
    }
    public void ChangeUiToInventory()
    {
        Inventory.SetActive(true);
        Document.SetActive(false);
    }
    public void ChangeUiToDocument()
    {
        Inventory.SetActive(false);
        Document.SetActive(true);
    }
    public void NextBtnChangePage()
    {
        currentPageDocument++;
        if (currentPageDocument > 3)
        {
            currentPageDocument = 1;
        }
        ResetPage();
    }
    public void BackBtnChangePage()
    {
        currentPageDocument--;
        if (currentPageDocument < 1)
        {
            currentPageDocument = 3;
        }
        ResetPage();
        
    }
    public void ResetPage()
    {
        for (int i = 0; i < pageDocument.Length; i++)
        {
            pageDocument[i].SetActive(false);
        }
        pageDocument[currentPageDocument].SetActive(true);
    }
}
