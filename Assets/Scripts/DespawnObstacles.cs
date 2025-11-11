using UnityEngine;

public class DespawnObstacles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Debug.Log("Object destroyed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
