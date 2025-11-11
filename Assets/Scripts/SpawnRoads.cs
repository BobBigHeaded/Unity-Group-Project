using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawnRoads : MonoBehaviour
{
    [Range(0,20)]
    public float spawnTimer = 10;

    private Vector3 spawnLocation = new Vector3(-0.7f, 0, 29.5f);

    public GameObject road;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(road, spawnLocation, transform.rotation);

        StartCoroutine(delaySpawn());
    }

    IEnumerator delaySpawn()
    {
        yield return new WaitForSeconds(spawnTimer);

        Instantiate(road, spawnLocation, transform.rotation);

        StartCoroutine(delaySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
