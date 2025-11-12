using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawnCars : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    
    public int delayTime = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelaySpawn(delayTime));
    }

    void SpawnCar()
    {
        //select lane
        float[] lanes = { -3.7f, 0, 3.9f };
        int rnd = Random.Range(0, 3);

        //set spawn coordinates
        Vector3 spawnLocation = new Vector3(lanes[rnd], 0.15f, 15f);
        GameObject temp = obstacles[Random.Range(0, 9)];

        //spawn object
        Instantiate(temp, spawnLocation, temp.transform.rotation);
    }

    IEnumerator DelaySpawn(int delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnCar();
        StartCoroutine(DelaySpawn(delay));
    }
}
