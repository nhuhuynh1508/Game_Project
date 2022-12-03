using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;
    [SerializeField]
    private Vector2 _playerPosition;
    private Vector2 _position;
    Rigidbody2D rb;

    public float moveSpeed = 0.0001f;

    private void Awake() 
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("rb is null");

        _player = Player.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardPlayer();
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(_position);  
    }





    void moveTowardPlayer()
    {
        _playerPosition = _player.transform.position;

        _position = Vector2.Lerp(transform.position, _playerPosition, moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }



}






