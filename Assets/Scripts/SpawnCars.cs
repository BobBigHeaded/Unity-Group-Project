using System.Collections;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;

    
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
        //select lane
        float[] lanes = { -16.5f, 0, 23.5f };
        int temp = Random.Range(0, 3);

        //select vehicle
        string[] cars = { "car1", "car2", "car3", "Police 1", "Towtruck 1", "Truck 1", "Van 1", "VanBig" };
        toSpawn = cars[Random.Range(0, 3)];

        Vector3 spawnLocation = new Vector3(lanes[temp], 0.5f, 15f);

        Instantiate(car1, spawnLocation, transform.rotation);
    }

    IEnumerator delaySpawn()
    {
        Debug.Log("Start Coro");
        yield return new WaitForSeconds(5);
        spawnCar();
        StartCoroutine(delaySpawn());


        Debug.Log("End of delay");
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
