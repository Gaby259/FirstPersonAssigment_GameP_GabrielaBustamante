using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour

{
    private CharacterController _controller;
    private MovingPlatform _currentmovingPlatform;
    
    [Header("Movement")]
    [SerializeField] private float _movementSpeed = 6f;
    [SerializeField] private float _jumpHeight = 10f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _doubleJumpMultiplier = 3f;
    private Vector3 _direction;
    private float _directionY;
    private bool _canDoubleJump = false;
    
    
    [Header("Rotation")]
    private Vector2 _currentMouseDelta;
    private float _xRotation;
    private Vector2 _currentMouseVelocity;
    [SerializeField] private float _smoothTime = 0.1f;
    [SerializeField] private float _xCameraBounds = 80f;
    [SerializeField] private Camera _camera;
    
    [Header("PickUp")]
    private bool _pickUpKeyPressed;
    public PlayerPickUp _pickUp;
    
    [Header("Gun")]
    [SerializeField] public GravityGun _equippedWeapon;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      Movement();
      Rotation();
      Jump();
      EquippedWeapon();
    }

    void Movement()
    {
        //fix that when you rotate the axis ar moving as well 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _direction = horizontal * transform.right + vertical * transform.forward;
        
    }

    void Rotation()
    {
        //Rotation 
        float mouseX = Input.GetAxis("Mouse X");//left and right
        float mouseY = Input.GetAxis("Mouse Y");// up and down
      
        Vector2 targetDelta = new Vector2(mouseX, mouseY);
        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, targetDelta, ref _currentMouseVelocity, _smoothTime);
        _xRotation -= _currentMouseDelta.y;
        _xRotation = Mathf.Clamp(_xRotation,-_xCameraBounds, _xCameraBounds);
        transform.Rotate(Vector3.up, _currentMouseDelta.x);
        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
    }

    void Jump()
    {
        //Jump
        if (_controller.isGrounded) //this helps to end the infinity jumps 
        {
            _canDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                _directionY = _jumpHeight; 
            }
        }
        else if (Input.GetButtonDown("Jump") && _canDoubleJump)
        {
            _directionY = _jumpHeight*_doubleJumpMultiplier;
            _canDoubleJump = false;
        }

        _directionY -= _gravity;//smooth the jump;
        _direction.y = _directionY;
       _controller.Move(_direction * _movementSpeed * Time.deltaTime);
    }

    public bool IsPickUpKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_pickUp != null)
            {
                _pickUp.Release();
                _pickUp = null;
            }
            else
            {
                _pickUpKeyPressed = true;
            }
        }
        else
        {
            _pickUpKeyPressed = false;
        }
        return _pickUpKeyPressed;
    }

   public  void EquippedWeapon()
    {
        if  (Input.GetKeyDown(KeyCode.P))
        {
            if (_equippedWeapon)
            {
                _equippedWeapon.Shoot();
            }
        }
    }
}
