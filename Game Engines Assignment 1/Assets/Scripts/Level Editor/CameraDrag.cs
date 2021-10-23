using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// References used:
// https://answers.unity.com/questions/827105/smooth-2d-camera-zoom.html
// https://answers.unity.com/questions/827834/click-and-drag-camera.html

public class CameraDrag : MonoBehaviour
{
    [SerializeField] float panSpeed = 10f;

    [SerializeField] float zoomSpeed = 10f;
    [SerializeField] float targetOrtho;
    [SerializeField] float smoothSpeed = 2.0f;
    [SerializeField] float minOrtho = 1.0f;
    [SerializeField] float maxOrtho = 20.0f;

    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        // Hold right mouse button to pan camera
       if (Input.GetMouseButton(1))
        {
            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime * 30f;
            newPosition.y = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime * 30f;

            transform.Translate(-newPosition);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }
}