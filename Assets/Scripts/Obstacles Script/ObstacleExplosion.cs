using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleExplosion : MonoBehaviour
{

    public ParticleSystem FX_explosion;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(FX_explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);

    }
}
