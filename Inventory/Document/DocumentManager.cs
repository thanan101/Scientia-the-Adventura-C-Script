using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocumentManager : MonoBehaviour
{
    [SerializeField]public List<bool> gotItemLearnDoc;
    [SerializeField]List<GameObject> BtnLearningDocument;
    //[SerializeField] public bool[] gotItemStoryDoc;
    //[SerializeField]GameObject[] BtnStoryDocument;

    private void Start()
    {
        for(int i = 0; i < BtnLearningDocument.Count; i++)
        {
            if (gotItemLearnDoc[i] == true)
            {
                BtnLearningDocument[i].SetActive(true);
            }
            else
            {
                BtnLearningDocument[i].SetActive(false);
            }
            
        }
        /*for (int i = 0; i < BtnStoryDocument.Length; i++)
        {
            BtnStoryDocument[i].SetActive(false);
        }*/
    }  
    public void GetDocCumentLearn(int id)
    {
        gotItemLearnDoc[id] = true;
        BtnLearningDocument[id].SetActive(true);
        gotItemLearnDoc[id] = true;
    }
    /*public void GetDocCumentStory(int id)
    {
        gotItemStoryDoc[id] = true;
        BtnStoryDocument[id].SetActive(true);
    }*/

    /// <summary>
    private static DocumentManager _instance;
    public static DocumentManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("DocumentManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>
}
