using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : RandomSpawner
{
    
    // Start is called before the first frame update
    void Start()
    {
        print("start in child3");
        StartCoroutine(Spawn());
        print("start in child4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
