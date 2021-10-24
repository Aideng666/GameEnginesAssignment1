using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void SmallPlatformSelect()
    {
        InputPlane.currentPlatformType = 0;
    }

    public void RegularPlatformSelect()
    {
        InputPlane.currentPlatformType = 1;
    }

    public void LargePlatformSelect()
    {
        InputPlane.currentPlatformType = 2;
    }

    public void FinalPlatformSelect()
    {
        InputPlane.currentPlatformType = 3;
    }

    public void GrassSelect()
    {
        InputPlane.currentPlatformType = 4;
    }
}