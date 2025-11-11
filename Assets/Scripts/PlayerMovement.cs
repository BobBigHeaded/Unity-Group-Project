using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //styling how it looks in the inspector
    [Header("Movement Settings")]
    [Space(5)]
    
    [Range(0, 3)]
    public float speed = 3f;
    [Range(0, 10)]
    public float jumpForce = 2.8f;
    
    private Rigidbody _rb;
    //Horizontal
    private float _movementX = 0;
    //Vertical 
    private bool _isGrounded;
    private float _height;
    
    void Start()
    {
        _height = GetComponent<BoxCollider>().bounds.size.y;
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Use the rigidbody movement to ensure that collisions are considered when moving
        _rb.MovePosition(_rb.position + new Vector3(_movementX * Time.fixedDeltaTime, 0, 0));
        
        GroundCheck();
    }

    void OnMove(InputValue movement)
    {
        //basically x-axis is horizontal (A and D) movement and y is vertical (W and S)
        Vector2 movementVector = movement.Get<Vector2>();

        _movementX = movementVector.x * speed;
    }

    void OnJump(InputValue jump)
    {
        //ensure the player is on the ground
        GroundCheck();
        
        if (_isGrounded)
        {
            //add velocity to the player to simulate jumping
            _rb.linearVelocity += (Vector3.up *  jumpForce);
        }
    }

    void GroundCheck()
    {
        //Raycast from the player to see if there is ground beneath them
        if (Physics.Raycast(transform.position, Vector3.down, _height/2 + 0.1f))
        {
            _rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
            
            _isGrounded = true;
        }else
        {
            _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            _isGrounded = false;
        }
    }
}