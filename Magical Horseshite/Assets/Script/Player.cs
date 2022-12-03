using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    private float _speed = 4.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    private float _jumpHeight = 10.0f;
    private CharacterController _controller;
   
    private float _yVelocity;
    private bool _doubleJump = true;

    [SerializeField]
    private int _lives = 3;

    private bool _FacingRight = true;
    [SerializeField]
    private GameObject _bulletPrefab;
    private float _fireRate = 2f, _canFire = -1f;

    private Animator _playerAnimator; 
    [SerializeField]
    private int _side = 1;

    private static Player _instance;
    public static Player GetPlayer()
    {
        return _instance;
    }
    // Awake Method
    private void Awake() 
    {
        _instance = this;
    }
    
    // public UnityEvent OnLandEvent;
    // [System.Serializable]
	// public class BoolEvent : UnityEvent<bool> { }
    

    // Start is called before the first frame update
    void Start()
    {   
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
        {
            Debug.LogError("Controller is null");
        }

        _playerAnimator = GetComponent<Animator>();
        if (_playerAnimator == null)
        {
            Debug.LogError("Player animator is NULL");
        }

        // if (OnLandEvent == null)
		// {	
        //     Debug.Log("Land event");
        //     OnLandEvent = new UnityEvent();
        // }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time >= _canFire)
        {
            Firing();
        }
        else Movement();
    }


    void Movement()
    {       
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 _velocity = direction * _speed;

        if (_controller.isGrounded == true)
        {
            _playerAnimator.SetBool("Vertical", false);
            if (Input.GetButtonDown("Jump"))        //Jump  _jumpheight = 15
            {
                _yVelocity = _jumpHeight;
                _doubleJump = true;

                _playerAnimator.SetBool("Vertical", true);
            }   
        }
        else if (_controller.isGrounded == false)                            
        {
            if (Input.GetButtonDown("Jump") && (_doubleJump == true))       
            {
                _yVelocity = _jumpHeight;
                _doubleJump = false;

                _playerAnimator.SetBool("Vertical", true);
            }  
            _yVelocity -= _gravity;
        }
        
        _velocity.y = _yVelocity;
        _controller.Move(_velocity * Time.deltaTime);
        CheckBoundary();


        if (_velocity.x > 0 && !_FacingRight)
		    Flip();
		else if (_velocity.x < 0 && _FacingRight)
			Flip();
        
        //Movement Animation
        float horizontalMove = Input.GetAxis("Horizontal");
        _playerAnimator.SetFloat("Horizontal", 1); //Mathf.Abs(horizontalMove)
        float verticalMove = Input.GetAxis("Vertical");
    }

    //Check out of bounds
    private void CheckBoundary()
    {
        if (transform.position.y <= -25f)
        {
            transform.position = new Vector3(0, 1, 0);
            Damage();
        }
    }

    //Lives system
    public void Damage()
    {
        _lives -= 1;
        
    }

    //Flip player
    private void Flip()
    {
        _FacingRight = !_FacingRight;
        transform.Rotate(0f, 180f, 0f);
        _side *= -1;
    }

    //Firing system
    private void Firing()
    { 
        StartCoroutine(FireAnim());

        // if (Time.time+1.7 >= _canFire) _playerAnimator.SetBool("Fire", false);
        Instantiate(_bulletPrefab, new Vector3((transform.position.x), transform.position.y + 0.2f,transform.position.z), transform.rotation); 
        _canFire = Time.time + _fireRate;
    }
    private IEnumerator FireAnim()
    {
        transform.Translate(Vector3.zero);
        
        yield return new WaitForSeconds(1f);
    }


}
