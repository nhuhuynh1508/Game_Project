using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public float factor = 0.25f;
    public float limit = 0.8f;
 
    private Vector3 _center;
 
    void Start()
    {
        //Capture the starting position as a vector3
        _center = transform.parent.position;
    }
   
 
    void Update()
    {
        //Convert mouse pointer cords into a worldspace vector3
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;

        Vector3 pos = Camera.main.ScreenToWorldPoint (mousePos);
        
 
        //Create a dir target based on mouse vector * factor
        Vector3 dir = pos * factor;
 
        //Clamp the dir target
        dir = Vector3.ClampMagnitude(dir, limit);
 
        //Update the pupil position
        transform.position = _center + dir;
    }

}
