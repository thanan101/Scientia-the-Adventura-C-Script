using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonNumber : MonoBehaviour
{
    public int thisBottonNumber;

    CheckNumber checkNumber;
    

    void Start()
    {
        checkNumber = GetComponentInParent<CheckNumber>();

    }

    public void pressBTN()
    {
        checkNumber.calculator(thisBottonNumber);
    }
}
