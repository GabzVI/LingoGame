using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    GameObject pauseMenu;
    Plane plane;
    public float distanceZ;
    Vector3 distanceFromCamera;
    Vector3 hitPoint;

    bool activate;


    // Start is called before the first frame update
    void Start()
    {
        //This is how far away from the Camera the plane is placed
        distanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - distanceZ);
        plane = new Plane(Vector3.forward, gameObject.transform.position);
        pauseMenu = GameObject.Find("PausePanel");
        activate = false;
        pauseMenu.SetActive(activate);
    }

    public void ActivatePauseMenu()
    {
        activate = !activate;
        pauseMenu.SetActive(activate);
    }
}
