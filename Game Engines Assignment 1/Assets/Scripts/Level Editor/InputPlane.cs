using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public Transform platformPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (GetComponent<Collider2D>().OverlapPoint(mousePosition))
                {
                    Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                    //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

                    ICommand command = new PlacePlatformCommand(mousePosition, c, platformPrefab);
                    CommandInvoker.AddCommand(command);
                }
            }
        }

    }
}
