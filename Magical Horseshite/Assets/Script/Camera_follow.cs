using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{

    private Transform _playerTransform;
    private float _offsetY = 0f;
    private float _offsetX = 0f;
    int side = 1;



    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update() 
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        if (direction.x < 0)
        {
            side = -1;
        }
        else if (direction.x >0) side = 1;
    
    }


    // LateUpdate is called AFTER all the updates
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = _playerTransform.position.x + _offsetX*side;
        temp.y = _playerTransform.position.y + _offsetY;
        transform.position = temp;


    }
}
