using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragWord : MonoBehaviour
{
  
    public Vector3 wordPosition;
    private Rigidbody2D rb2D;
    private GameObject word;
    private float deltaX, deltaY;//I no longer need to use these because i am using world coordinates instead of the canvas.
    private float moveSpeed = 15.0f;

    public GameObject _canv;


    // Start is called before the first frame update
    void Start()
    {
        deltaX = (float)Screen.width / 2.0f;
        deltaY = (float)Screen.height / 2.0f;
        rb2D = GetComponent<Rigidbody2D>();
        word = GameObject.FindGameObjectWithTag("Draggable");
        _canv = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Moved()
    {
        //Handles Screen touches
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            { 
            
                //The code below is no longer needed as we aint using the canvas coordinates anymore and we are using world space coordinates, so that the movement of words are smoother and in the 
                //same world space.
                //Vector2 pos;
                //pos.x = _canv.GetComponent<RayCastPlane>().hitPoint.x;
                //pos.y =  _canv.GetComponent<RayCastPlane>().hitPoint.y;


                //pos.x = (pos.x - deltaX) / deltaX;
                //pos.y = (pos.y - deltaY) / deltaY;
                //wordPosition = new Vector3(pos.x, pos.y, 0.0f);

                //// Position the cube.
                //transform.Translate(wordPosition * Time.deltaTime * moveSpeed);            

                //This will change the position of the word by making it go towards the hitpoint of our finger in the canvas.
                transform.position = Vector3.MoveTowards(transform.position, _canv.GetComponent<RayCastPlane>().hitPoint, moveSpeed * Time.deltaTime);


            }
        }
    }

}
