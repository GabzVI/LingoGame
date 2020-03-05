using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RayCastUI : MonoBehaviour
{

    GraphicRaycaster m_Raycaster; // The Graphic Raycaster that we will get from the Canvas.
    bool isActive; // Checks if we were pressing something.
    public GameObject currentObjectHit; // The current object we are hitting.
    
    // Start is called before the first frame update
    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {

        if(isActive && currentObjectHit != null)
        {
            currentObjectHit.GetComponent<DragWord>().Moved(); // Get the script "DragWord" from that thing we just hit.
        }

        //Handles Screen touches
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                PointerEventData ed = new PointerEventData(EventSystem.current); // creates a new event system.
                ed.position = touch.position; // Gives the event system the fingers position.

                //Raycast using the Graphics Raycaster and finger touch position
                m_Raycaster.Raycast(ed, results);

                //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.CompareTag("Draggable")) // If what we are hitting is a draggable.
                    {
                        isActive = true;
                        currentObjectHit = result.gameObject;
                        Debug.Log("Hit " + result.gameObject.name);
                    }
                   
                }
            }
           
            if(touch.phase == TouchPhase.Ended)
            {
                isActive = false;
                currentObjectHit = null;
            }

        }
    }
}
