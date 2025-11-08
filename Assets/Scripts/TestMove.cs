using UnityEngine;

public class TestMove : MonoBehaviour
{
    [Range(0, 5)]
    public float moveSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * (moveSpeed * Time.deltaTime);
    }
}
