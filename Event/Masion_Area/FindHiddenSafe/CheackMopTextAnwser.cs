using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheackMopTextAnwser : MonoBehaviour
{
    int waterpaint;
    public WaterOnfloorFontPaint[] waterOnfloorFontPaint;
    public void ThisWater(int thiswater)
    {
        waterpaint = thiswater;
    }
    public void UseMop()
    {
        if (waterpaint == 1)
        {
            waterOnfloorFontPaint[0].ThisWaterOnfloor();
        }
        else if (waterpaint == 2)
        {
            waterOnfloorFontPaint[1].ThisWaterOnfloor();
        }
    }
}
