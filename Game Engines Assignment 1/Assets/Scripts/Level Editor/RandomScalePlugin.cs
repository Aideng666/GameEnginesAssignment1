using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class RandomScalePlugin : MonoBehaviour
{
    [DllImport("GameEnginesAssignment2DLL")]
    private static extern float RandomScaleValue(float minValue, float maxValue);

    public Vector3 ApplyRandomScale(Vector3 scale)
    {
        return new Vector3(scale.x * RandomScaleValue(0.8f, 1.2f), 1, 1);
    }
}