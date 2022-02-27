using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : RandomSpawner
{
    

    // Start is called before the first frame update
    void Start()
    {
        print("start in child1");
        StartCoroutine(Spawn());
        print("start in child2");
    }


}
