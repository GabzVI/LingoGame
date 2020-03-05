using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordCollisionwithPicture : MonoBehaviour
{
    Vector3 offset;
    bool hitPicture;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == this.gameObject.name)
        {
            offset.x = 25.0f;
            

            hitPicture = true;
            other.gameObject.tag = "locked";
            other.gameObject.GetComponent<TextMeshProUGUI>().color = Color.yellow;
            //  other.gameObject.transform.position = this.transform.position + new Vector3(offset.x, 0.0f, 0.0f);
            
            other.gameObject.transform.position = Vector3.MoveTowards( other.transform.position, this.transform.position + new Vector3(offset.x, 0.0f, 0.0f), 50.0f * Time.deltaTime);
            Debug.Log("collided with picture");
            
        }
       

    }
}
  
