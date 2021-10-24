using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// References used:
// https://www.youtube.com/watch?v=R6scxu1BHhs&t=789s
// https://answers.unity.com/questions/827834/click-and-drag-camera.html

public class CameraDrag : MonoBehaviour
{
    [SerializeField] float panSpeed = 10f;
    
    [SerializeField] private Camera cam;

    [SerializeField] private float zoomStep, minCamSize, maxCamSize;

    // Update is called once per frame
    void Update()
    {
        PanCamera();

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0.0f)
        {
            ZoomIn();
        }
        else if (scroll < 0.0f)
        {
            ZoomOut();
        }
    }

    void PanCamera()
    {
        if (Input.GetMouseButton(1))
        {
            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime * 30f;
            newPosition.y = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime * 30f;

            transform.Translate(-newPosition);
        }
    }

    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
}