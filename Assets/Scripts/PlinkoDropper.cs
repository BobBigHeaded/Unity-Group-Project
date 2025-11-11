using System;
using UnityEngine;

public class PlinkoDropper : MonoBehaviour
{
    [Header("Positions to move between")]
    public GameObject start, end;
    
    [Header("Player Data")]
    [Range(1, 4)]
    public float speed;
    public GameObject ball;
    
    
    private bool _goingToStart = true;
    
    // Update is called once per frame
    void Update()
    {
        if (_goingToStart)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.position.x > start.transform.position.x)
            {
                _goingToStart = false;
            }
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.position.x < end.transform.position.x)
            {
                _goingToStart = true;
            }
        }
    }

    void OnJump()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }
}
