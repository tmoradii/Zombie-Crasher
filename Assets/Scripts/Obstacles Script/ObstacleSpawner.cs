using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float MaxSpawnOffset = 15f;
    public float MinSpawnOffset = 5f;
    public Transform[] guidLines;

    private Vector3 spawnPosition;
    private float roadHalfSize;
    
    // Start is called before the first frame update
    void Start()
    {
        CalculateHalfSize(); //TODO it is better to move it in another class
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(1f);
        //instantiate a  random obstaclePrefabs at random guidLines with random range between max and min
        SpawnObstacles();
    }

    void CalculateHalfSize()
    {
        float startZ = GameObject.FindGameObjectWithTag("start").transform.position.z;
        float endZ   = GameObject.FindGameObjectWithTag("end").transform.position.z;
        roadHalfSize = Mathf.Abs(startZ - endZ) / 2;
        print(roadHalfSize);
    }
}
