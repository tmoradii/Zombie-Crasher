using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class RandomSpawner : MonoBehaviour
{
    public GameObject[] Prefabs;
    public float MaxSpawnOffset = 20f;
    public float MinSpawnOffset = 10f;
    public Transform[] guidLines;
    public GameObject parent;

    protected float playerForwardSpeed { get; set; }
    protected float roadHalfSize { get; set; }

    private VehicleController player;

    // Start is called before the first frame update
    void Awake()
    {
        CalculateHalfSize(); //TODO it is better to move it in another class
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<VehicleController>();
        playerForwardSpeed = player.forwardSpeed;
        //StartCoroutine(Spawn());
        print("start in parent");
    }

    protected IEnumerator Spawn()
    {
        float timer = Random.Range(10f, 40f) / playerForwardSpeed;
        yield return new WaitForSeconds(timer);
        //instantiate a  random obstaclePrefabs at random guidLines with random range between max and min
        InstantiateObjectAtRandomPos();

        StartCoroutine(Spawn());
    }

    private void CalculateHalfSize()
    {
        float startZ = GameObject.FindGameObjectWithTag("start").transform.position.z;
        float endZ = GameObject.FindGameObjectWithTag("end").transform.position.z;
        roadHalfSize = Mathf.Abs(startZ - endZ) / 2;
    }

    private void RandomPosition(ref Vector3 position)
    {

        int chance = Random.Range(0, 10);
        //by 60% we are going to spawn obstacle
        if (chance < 6)
        {
            int index = Random.Range(0, 3);
            position = guidLines[index].position;
            position.z = roadHalfSize + player.gameObject.transform.position.z + Random.Range(MinSpawnOffset, MaxSpawnOffset);
        }

    }

    void InstantiateObjectAtRandomPos()
    {
        Vector3 position = Vector3.zero;
        RandomPosition(ref position);
        if (position != Vector3.zero)
        {
            int index = Random.Range(0, Prefabs.Length);
            var newObject = Instantiate(Prefabs[index], position, Quaternion.identity);
            //puting new obstacles in a parent for organization reasons
            newObject.transform.parent = parent.transform;
        }
    }

   
}
