using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap_Base : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //CHeck ground
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
            Debug.Log("ground");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
