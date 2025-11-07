using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float offset; //how much the player will move to get to the next lane
    public int additionalSideLanes; //additional lanes on both sides
    
    private Vector3 _startingPosition;
    
    void Start()
    {
        //Ignore this
        //go left. and make right of left the middle. right of middle is not left, it is the right.
        //Ignore this
        
        _startingPosition =  transform.position;
        
    }
    
    void Update()
    {
        
    }

    void OnMove(InputValue movement)
    {
        Vector2 movementVector = movement.Get<Vector2>();

        if (movementVector.x > 0)
        {
            Vector3 desiredPosition = transform.position + new Vector3(offset, 0, 0);
            float maxX = _startingPosition.x + (offset * additionalSideLanes);

            if (desiredPosition.x <= maxX)
            {
                transform.position += new Vector3(offset, 0, 0);   
            }
            
        }else if (movementVector.x < 0)
        {
            Vector3 desiredPosition = transform.position - new Vector3(offset, 0, 0);
            float maxX = _startingPosition.x - (offset * additionalSideLanes);

            if (desiredPosition.x >= maxX)
            {
                transform.position -= new Vector3(offset, 0, 0);
            }
        }
    }
}
