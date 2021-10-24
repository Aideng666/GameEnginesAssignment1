using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class RandomScalePlugin : MonoBehaviour
{
    [DllImport("GameEnginesAssignment2DLL")]
    private static extern float RandomScaleValue(float minValue, float maxValue);

    //public void ApplyRandomScale()
    //{
    //    isRandomApplied = !isRandomApplied;

    //    if (isRandomApplied)
    //    {
    //        for (int i = 0; i < platforms.Count; i++)
    //        {
    //            platforms[i].Platform.localScale = new Vector3(platforms[i].Platform.localScale.x * RandomScaleValue(0.8f, 1.2f), 1, 1);

    //            FindObjectOfType<CommandInvoker>().SetHistory(platforms);
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < platforms.Count; i++)
    //        {
    //            platforms[i].Platform.localScale = originalScales[i];

    //            FindObjectOfType<CommandInvoker>().SetHistory(platforms);
    //        }
    //    }


    //}

    public Vector3 ApplyRandomScale(Vector3 scale)
    {
        return new Vector3(scale.x * RandomScaleValue(0.8f, 1.2f), 1, 1);
    }
}
