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
        //basically x-axis is horizontal (A and D) movement and y is vertical (W and S)
        Vector2 movementVector = movement.Get<Vector2>();

        if (movementVector.x > 0)//above 0 is right
        {
            //calculate where we want to be with current input
            Vector3 desiredPosition = transform.position + new Vector3(offset, 0, 0);
            //calculate the maximum point we can be at
            //possible optimisation by defining this at the start
            float maxX = _startingPosition.x + (offset * additionalSideLanes);

            if (desiredPosition.x <= maxX) //if desired point is equal to or below or maximum then
            {
                //move the player by the offset
                transform.position += new Vector3(offset, 0, 0);   
            }
            
        }else if (movementVector.x < 0)// below 0 is left
        {
            //same as above but for negative
            Vector3 desiredPosition = transform.position - new Vector3(offset, 0, 0);
            float maxX = _startingPosition.x - (offset * additionalSideLanes);

            if (desiredPosition.x >= maxX)
            {
                transform.position -= new Vector3(offset, 0, 0);
            }
        }
    }
}
