using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawnCars : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;
    public GameObject car7;
    public GameObject car8;
    public GameObject car9;

    public List<GameObject> obstacles = new List<GameObject>();

    private IEnumerator coroutine;
    private float delayTime = 3;
    private string toSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(delaySpawn());
    }

    void spawnCar()
    {
        Debug.Log("Start spawn");

        //select lane
        float[] lanes = { -3.7f, 0, 3.9f };
        int rnd = Random.Range(0, 3);

        Vector3 spawnLocation = new Vector3(lanes[rnd], 0.15f, 15f);
        GameObject temp = obstacles[Random.Range(0, 9)];

        Instantiate(temp, spawnLocation, temp.transform.rotation);
        Debug.Log("End spawn");
    }

    IEnumerator delaySpawn()
    {
        yield return new WaitForSeconds(4);
        spawnCar();
        StartCoroutine(delaySpawn());
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
