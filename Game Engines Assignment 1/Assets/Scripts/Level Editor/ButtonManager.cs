using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{
    public static event Action clicked;

    public void SmallPlatformSelect()
    {
        InputPlane.currentPlatformType = 0;

        clicked?.Invoke();
    }

    public void RegularPlatformSelect()
    {
        InputPlane.currentPlatformType = 1;

        clicked?.Invoke();
    }

    public void LargePlatformSelect()
    {
        InputPlane.currentPlatformType = 2;

        clicked?.Invoke();
    }

    public void FinalPlatformSelect()
    {
        InputPlane.currentPlatformType = 3;

        clicked?.Invoke();
    }

    public void GrassSelect()
    {
        InputPlane.currentPlatformType = 4;

        clicked?.Invoke();
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}