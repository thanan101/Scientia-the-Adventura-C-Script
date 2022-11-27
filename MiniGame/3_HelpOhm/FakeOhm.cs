using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FakeOhm : MonoBehaviour
{
    [SerializeField] GameObject[] _fakeOhm;

    public bool StartMiniGame = false;

    public void CheackBlink(bool startminiGame)
    {
        StartMiniGame = startminiGame;
        if (StartMiniGame == true)
        {
            StartCoroutine(OutBlink1());
            StartCoroutine(OutBlink2());
        }
        

    }
    public void Done()
    {
        StopAllCoroutines();
    }
    IEnumerator OutBlink1()//ค่าตายตัว ตัวปลอมที่ 1
    {
        yield return new WaitForSeconds(4.5f);
        _fakeOhm[0].SetActive(false);
        StartCoroutine(InBlink1());
    }
    IEnumerator InBlink1()//ค่าตายตัว ตัวปลอมที่ 1
    {
        yield return new WaitForSeconds(0.2f);
        _fakeOhm[0].SetActive(true);
        StartCoroutine(OutBlink1());
    }
    //ตัวที่ 2
    IEnumerator OutBlink2()//ค่าตายตัว ตัวปลอมที่ 1
    {
        yield return new WaitForSeconds(14.5f);
        _fakeOhm[1].SetActive(false);
        StartCoroutine(InBlink2());
    }
    IEnumerator InBlink2()//ค่าตายตัว ตัวปลอมที่ 1
    {
        yield return new WaitForSeconds(0.2f);
        _fakeOhm[1].SetActive(true);
        StartCoroutine(OutBlink2());
    }
}
