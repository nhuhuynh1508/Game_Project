using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20f;
    private Rigidbody2D rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) >= 30)
        {
            Destroy(this.gameObject);
        }

    }
}
