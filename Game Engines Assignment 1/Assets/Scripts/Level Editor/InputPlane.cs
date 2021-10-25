using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputPlane : MonoBehaviour
{
    public static event Action clicked;

    public Transform platformPrefab;
    public Transform grassPrefab;
    PlatformFactory factory;
    public static int currentPlatformType = 1;

    bool isRandomApplied;
    bool shouldSpawnPlatform = true;

    // Start is called before the first frame update
    void Awake()
    {
        factory = new PlatformFactory();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            clicked?.Invoke();

            if (GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                if (shouldSpawnPlatform)
                {
                    if (currentPlatformType != 4)
                    {
                        Platform platCommand = factory.CreatePlatformType(currentPlatformType, mousePosition, platformPrefab, isRandomApplied);
                        CommandInvoker.AddCommand(platCommand);
                    }
                    else if (currentPlatformType == 4)
                    {
                        Platform platCommand = factory.CreatePlatformType(currentPlatformType, mousePosition, grassPrefab, isRandomApplied);
                        CommandInvoker.AddCommand(platCommand);
                    }
                }
            }
        }
    }

    public void ToggleRandomScale()
    {
        isRandomApplied = !isRandomApplied;
    }

    public void DeactivateShouldSpawn()
    {
        shouldSpawnPlatform = false;
    }

    public void ActivateShouldSpawn()
    {
        shouldSpawnPlatform = true;
    }
}
