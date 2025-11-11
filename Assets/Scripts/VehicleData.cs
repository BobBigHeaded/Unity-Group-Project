using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VehicleCollisionValues : MonoBehaviour
{
    [Header("Basic Values")]
    [Range(6, 10)]
    public float bounceForce;
    [Range(1, 3)]
    public int damage = 1;
    
    [Header("All possible materials")]
    public List<Material> materials = new List<Material>();

    private void Start()
    {
        var materialNum = Random.Range(0, materials.Count);
        
        this.GetComponent<MeshRenderer>().material = materials[materialNum];
    }
}
