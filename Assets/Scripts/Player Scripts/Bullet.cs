using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletForwardSpeed = 2000f;    
    Rigidbody mybody;


    private void Start()
    {
        mybody = GetComponent<Rigidbody>();
        Move();
    }

    void Move()
    {
        
        mybody.AddForce(transform.forward* bulletForwardSpeed);
        Invoke("Disapear", 2.5f);
    }

    void Disapear()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
         gameObject.SetActive(false);
    }

}
