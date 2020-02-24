using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody rbody;
    private float bulletSpeed = 1000; 
    void Start()
    {
        DestroyObjectDelayed();
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbody.velocity = transform.forward * bulletSpeed;
    }



    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(this.gameObject, 5);
    }
}
