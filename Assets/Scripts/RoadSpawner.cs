using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject road;
    public float roadOffset = 200f;

    Transform currentRoadPos;

    // Start is called before the first frame update
    void Awake()
    {
        currentRoadPos = GetComponent<Transform>().parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 roadPos = currentRoadPos.position;
        roadPos.z += roadOffset;
        GameObject.Instantiate(road, roadPos, Quaternion.Euler(-90f, 0, 0));
    }
}
