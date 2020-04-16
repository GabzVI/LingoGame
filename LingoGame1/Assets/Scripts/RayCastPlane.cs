using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class RayCastPlane : MonoBehaviour
{

    Plane plane;
    Vector3 distanceFromCamera;
    public float distanceZ;
    bool isActive; // Checks if we were pressing something.
    List<GameObject> wordsObject;

    public GameObject currentObjectHit; // The current object we are hitting.

    public GameObject CanvasPos;
    public Vector3 hitPoint;

    // Start is called before the first frame update
    void Start()
    {
        //This is how far away from the Camera the plane is placed
        distanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - distanceZ);
        plane = new Plane(Vector3.forward, gameObject.transform.position);
        wordsObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("Draggable"));
    
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isActive && currentObjectHit != null)
        {
            currentObjectHit.GetComponent<DragWord>().Moved(); // Get the script "DragWord" from that thing we just hit
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Checks if finger hsa touched screen.
            if (touch.phase == TouchPhase.Moved)
            {
                //Create a ray from the tap/touch position
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

  

                float thePoint = 0.0f;     

                if (plane.Raycast(ray, out thePoint))
                {
                    //Constantly update the hitpoint, so we know which position on the plane we are every frame.
                    hitPoint = ray.GetPoint(thePoint);

                  
                    //Checks through the list of words in worldspace with the hitpoint we created.
                    foreach (GameObject objectInCanvas in wordsObject)
                    {
                        //  Debug.Log("Distance: " + Vector3.Distance(hitPoint, objectsInCanvas.transform.position));
                        if (objectInCanvas != null)
                        {
                            
                            //Calculates the distance between the point the raycast hit and the object we want to be hit.
                            if (Vector3.Distance(hitPoint, objectInCanvas.transform.position) <= 3.5f)
                            {
                                if (currentObjectHit == null)
                                { 
                                    //If the hit we want to make our currentobject to be the object we hit the raycast on.
                                    currentObjectHit = objectInCanvas.gameObject;
                                    isActive = true;
                                }
                            }
                        }
                     
                    }


                }

            }
            if (touch.phase == TouchPhase.Ended)
            {
                isActive = false;
                currentObjectHit = null;
            }
        }
    }
}
