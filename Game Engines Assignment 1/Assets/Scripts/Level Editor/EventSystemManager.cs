using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
{
    private EventSystem eventSystem;
    private GameObject lastSelected = null;

    public GameObject undoButton;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventSystem != null)
        {
            if (eventSystem.currentSelectedGameObject != null)
            {
                lastSelected = eventSystem.currentSelectedGameObject;
            }
            else 
            {
                eventSystem.SetSelectedGameObject(lastSelected);
            }     

            if (eventSystem.currentSelectedGameObject == undoButton)
            {
                lastSelected = eventSystem.currentSelectedGameObject;
                eventSystem.SetSelectedGameObject(lastSelected);
            }
        }
    }

    public void DeselectClickedButton(GameObject button)
    {
        if (EventSystem.current.currentSelectedGameObject == button)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}