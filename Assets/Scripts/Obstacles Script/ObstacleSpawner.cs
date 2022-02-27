using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float MaxSpawnOffset = 20f;
    public float MinSpawnOffset = 10f;
    public Transform[] guidLines;

    private Vector3 spawnPosition;
    private float roadHalfSize;
    private float playerSpeed;
    private Vector3 playerPosition;
    private VehicleController player;
    // Start is called before the first frame update
    void Start()
    {
        CalculateHalfSize(); //TODO it is better to move it in another class
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<VehicleController>();
        playerSpeed = player.forwardSpeed;
        StartCoroutine(SpawnObstacles());
    }

   IEnumerator SpawnObstacles()
    {
        float timer = Random.Range(10f, 40f) / playerSpeed;
        yield return new WaitForSeconds(timer);
        //instantiate a  random obstaclePrefabs at random guidLines with random range between max and min
        InstantiateObstacle();

        StartCoroutine(SpawnObstacles());
    }

    void CalculateHalfSize()
    {
        float startZ = GameObject.FindGameObjectWithTag("start").transform.position.z;
        float endZ   = GameObject.FindGameObjectWithTag("end").transform.position.z;
        roadHalfSize = Mathf.Abs(startZ - endZ) / 2;
    }

    void RandomPosition(ref Vector3 position)
    {

        int chance = Random.Range(0, 10);
        //by 60% we are going to spawn obstacle
        if(chance < 6)
        {
            int index = Random.Range(0, 3);
            position = guidLines[index].position;
            position.z = roadHalfSize + player.gameObject.transform.position.z + Random.Range(MinSpawnOffset , MaxSpawnOffset);
        }

    }
    
    void InstantiateObstacle()
    {
        Vector3 position = Vector3.zero;
        RandomPosition(ref position);
        print(position);
        if(position != Vector3.zero)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            var newObject = Instantiate(obstaclePrefabs[index], position, Quaternion.identity);
            //puting new obstacles in a parent for organization reasons
            newObject.transform.parent = GameObject.Find("Obstacles").transform;
        }
    }
}
