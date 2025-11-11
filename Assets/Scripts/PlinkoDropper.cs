using UnityEngine;

public class PlinkoDropper : MonoBehaviour
{
    [Header("Positions to move between")]
    public GameObject start, end;
    
    [Header("Player Data")]
    [Range(1, 4)]
    public float speed;
    [Range(0, 100)]
    public int ballCount = 20;
    public GameObject ball;
    
    private bool _goingToStart = true;
    private int _winCount;
    private int _loseCount;
    
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

        if (ballCount <= 0)
        {
            if (_winCount >= _loseCount)
            {
                //gain a life
            }
        }
    }

    void OnJump()
    {
        if (ballCount <= 0) return;
        
        Instantiate(ball, transform.position, transform.rotation);
        ballCount--;
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Win":
                _winCount++;
                break;
            
            case "Lose":
                _loseCount++;
                break;
            
            case "Again":
                ballCount++;
                break;
        }
    }
}