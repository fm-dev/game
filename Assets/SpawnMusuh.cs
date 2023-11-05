using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMusuh : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObject()
    {
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
   
    
}
