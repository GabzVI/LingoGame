using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordCollisionwithPicture : MonoBehaviour
{
    Vector3 offset;
    public bool hitPicture;
    GameObject worldObject;

    private void Start()
    { 
      worldObject = GameObject.Find("WorldSpace");
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Draggable")
        {
            offset.x = 25.0f;
            hitPicture = true;
            other.gameObject.GetComponent<TextMeshProUGUI>().color = Color.yellow;

            //other.gameObject.transform.position = Vector3.MoveTowards(other.transform.position, this.transform.position + new Vector3(offset.x, 0.0f, 0.0f), 80.0f * Time.deltaTime);
          
            if(other.gameObject.name == this.gameObject.name)
            {
                worldObject.GetComponent<Scoringsystem>().Score++;
                
            }

            worldObject.GetComponent<globalStats>().colliderCounter++;

            Debug.Log("collided with picture");
            Debug.Log("Score =" + worldObject.GetComponent<Scoringsystem>().Score);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Draggable")
        {
            worldObject.GetComponent<globalStats>().colliderCounter--;

            if(other.gameObject.name == this.gameObject.name)
            {
                worldObject.GetComponent<Scoringsystem>().Score--;
            }

            other.gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
            Debug.Log("Score =" + worldObject.GetComponent<Scoringsystem>().Score);
        }
    }

}



