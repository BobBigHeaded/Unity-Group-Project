using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float offset; //how much the player will move to get to the next lane
    public int maxLanes; //must be a multiple of 3
    
    private Vector3 _startingPosition;
    private Vector3 _maxLaneLeft;
    private Vector3 _maxLaneRight;
    private float _movementX;
    
    void Start()
    {
        //Ignore this
        //go left. and make right of left the middle. right of middle is not left, it is the right.
        //Ignore this
        
        _startingPosition =  transform.position;

        maxLanes /= 3;
        
        _maxLaneLeft = transform.position + new Vector3(offset*maxLanes, 0, 0);
        _maxLaneRight = transform.position - new Vector3(offset*maxLanes, 0, 0);
    }
    
    void Update()
    {
        Vector3 desiredPosition = transform.position + new Vector3(offset * _movementX, 0, 0);
        if (desiredPosition != transform.position)
        {
            
        }
    }

    void OnMove(InputValue movement)
    {
        Vector2 movementVector = movement.Get<Vector2>();

        if (movementVector.x > 0)
        {
            _movementX = 1;
        }else if (movementVector.x < 0)
        {
            _movementX = -1;
        }
        else
        {
            _movementX = 0;
        }
    }
}
