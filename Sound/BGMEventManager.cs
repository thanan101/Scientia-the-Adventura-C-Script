using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMEventManager : MonoBehaviour
{
    /// <summary>
    private static BGMEventManager _instance;
    public static BGMEventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("BGMEventManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    /// </summary>
    /// 

    [SerializeField] AudioSource _bgmGoodEnd;
    [SerializeField] AudioSource _bgmBadEnd;
    private void Start()
    {
    }
    public void GoodEndBGM()
    {
        _bgmBadEnd.Stop();
        if (_bgmGoodEnd.isPlaying == false)
            _bgmGoodEnd.Play();
    }
    public void BadEndBGM()
    {
        _bgmGoodEnd.Stop();
        if (_bgmBadEnd.isPlaying != true)
            _bgmBadEnd.Play();
    }
}
