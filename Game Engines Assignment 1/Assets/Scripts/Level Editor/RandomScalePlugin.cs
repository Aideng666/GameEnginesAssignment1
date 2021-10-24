using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class RandomScalePlugin : MonoBehaviour
{
    List<Platform> platforms;
    List<RegularPlatform> originalPositions;

    int currentCount;
    int lastCount;

    bool isRandomApplied;

    [DllImport("GameEnginesAssignment2DLL")]
    private static extern float RandomScaleValue(float minValue, float maxValue);

    void Start()
    {
        currentCount = FindObjectOfType<CommandInvoker>().GetHistory().Count - 1;
    }

    private void Update()
    {
        platforms = FindObjectOfType<CommandInvoker>().GetHistory();
        currentCount = platforms.Count;

        if (currentCount > lastCount)
        {
            originalPositions.Add(new RegularPlatform(platforms[platforms.Count - 1].Position, platforms[platforms.Count - 1].Platform));
        }

        lastCount = currentCount;
    }

    public void ApplyRandomScale()
    {
        isRandomApplied = !isRandomApplied;

        if (isRandomApplied)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].Platform.localScale = new Vector3(platforms[i].Platform.localScale.x * RandomScaleValue(0.8f, 1.2f), 1, 1);

                FindObjectOfType<CommandInvoker>().SetHistory(platforms);
            }
        }
        else
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].Platform.localScale = originalPositions[i].Platform.localScale;

                FindObjectOfType<CommandInvoker>().SetHistory(platforms);
            }
        }
    }
}
