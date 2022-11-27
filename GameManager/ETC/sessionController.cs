using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sessionController : MonoBehaviour
{
    [SerializeField] Canvas MainMenuCanvas;
    [SerializeField] Canvas OptionCanvas;

    private void Start()
    {
        MainMenuCanvas.enabled = true;
        OptionCanvas.enabled = false;
    }

    public void optionCanvas()
    {
        MainMenuCanvas.enabled = false;
        OptionCanvas.enabled = true;


    }

    public void MenuCavas()
    {
        MainMenuCanvas.enabled = true;
        OptionCanvas.enabled = false;
    }
}
