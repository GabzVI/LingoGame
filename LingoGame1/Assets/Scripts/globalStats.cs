using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalStats : MonoBehaviour
{
    public int colliderCounter = 0;
   
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {

        if (colliderCounter == 8)
        {
            Debug.Log("all pcitures assigned");
 
            gameObject.GetComponent<Scoringsystem>().CalculateScore();
        }
    }

    
}
