using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //styling how it looks in the inspector
    [Header("Movement Settings")]
    [Space(5)]
    
    [Range(2, 10)]
    public float speed = 3f;
    [Range(2, 10)]
    public float jumpForce = 2.8f;
    
    //Values
    private int _health;
    //Components
    private Rigidbody _rb;
    
    //Horizontal
    private float _movementX;
    
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
        
        _isGrounded = BeneathCheck("Walkable");
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
        _isGrounded = BeneathCheck("Walkable");
        
        if (_isGrounded)
        {
            //add velocity to the player to simulate jumping
            _rb.linearVelocity += (Vector3.up *  jumpForce);
        }
    }

    bool BeneathCheck(string tagName)
    {
        //Raycast from the player to see if there is ground beneath them
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _height+0.1f))
        {
            //if collided
            Debug.DrawRay(transform.position, Vector3.down, Color.darkGreen);

            if (hit.collider.CompareTag(tagName))
            {
                return true;
            }
        }
        //otherwise
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        return false;
    }

    void OnCollisionEnter(Collision collision)
    {
        var hitPlayer = false;
        
        //check if object can be bounce or ridden
        switch (collision.gameObject.tag)
        {
            case ("Bounceable"):
                //ensure it is beneath us and we haven't touched the side
                if (BeneathCheck("Bounceable"))
                {
                    //get bounce force from the collided object
                    var bounceForce = collision.gameObject.GetComponentInParent<VehicleCollisionValues>().bounceForce;
                    //add velocity up to simulate a bounce
                    _rb.linearVelocity += (Vector3.up * bounceForce);
                    
                }else hitPlayer = true;
                
                break;
            case ("Walkable"):

                if (!BeneathCheck("Walkable"))
                {
                    hitPlayer = true;
                }
                
                break;
        }
        //Take a life from the player
        if (hitPlayer == true)
        {
            _health -= collision.gameObject.GetComponentInParent<VehicleCollisionValues>().damage;
        }
    }
}
