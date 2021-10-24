using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public Transform platformPrefab;
    PlatformFactory factory;
    public static int currentPlatformType = 1;

    // Start is called before the first frame update
    void Awake()
    {
        maincam = Camera.main;
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

                Platform platCommand = factory.CreatePlatformType(currentPlatformType, mousePosition, platformPrefab);
                CommandInvoker.AddCommand(platCommand);
            }
        }
    }
}
