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
        //play anim
        print("ff");
        mybody.AddForce(transform.forward* bulletForwardSpeed);
        Invoke("Disapear", 4f);
    }

    void Disapear()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            //destroy that object
            //destroy bullet
        }
    }
}
