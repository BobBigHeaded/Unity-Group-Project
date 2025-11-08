using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [Range(0f, 1f)]
    public float cameraYOff = 0.608f;
    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+cameraYOff, transform.position.z);
    }
}
