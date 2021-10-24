using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    public Transform platformPrefab;
    public Transform grassPrefab;
    PlatformFactory factory;
    public static int currentPlatformType = 1;

    bool isRandomApplied;

    // Start is called before the first frame update
    void Awake()
    {
        factory = new PlatformFactory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Type: 0");
            currentPlatformType = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Type: 1");
            currentPlatformType = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Type: 2");
            currentPlatformType = 2;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                //ICommand command = new PlacePlatformCommand(mousePosition, platformPrefab);
                //CommandInvoker.AddCommand(command);

                if (currentPlatformType != 3)
                {
                    Platform platCommand = factory.CreatePlatformType(currentPlatformType, mousePosition, platformPrefab, isRandomApplied);
                    CommandInvoker.AddCommand(platCommand);
                }
                else if (currentPlatformType == 3)
                {
                    Platform platCommand = factory.CreatePlatformType(currentPlatformType, mousePosition, grassPrefab, isRandomApplied);
                    CommandInvoker.AddCommand(platCommand);
                }

                //Platform platCommand = factory.CreatePlatformType(currentPlatformType, mousePosition, platformPrefab, isRandomApplied);
                //CommandInvoker.AddCommand(platCommand);

               
            }
        }
    }

    public void ToggleRandomScale()
    {
        isRandomApplied = !isRandomApplied;
    }
}
