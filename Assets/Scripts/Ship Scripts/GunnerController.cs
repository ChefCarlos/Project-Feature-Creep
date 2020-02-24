using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerController : MonoBehaviour
{

    public GameObject[] gunBarrels = new GameObject[2];
    public GameObject laserBullet;
    public float shootInput = 0f;
    public int currentBarrelNumber = 0;

    private bool canShoot = true;
    private GameObject currentGunBarrel;

    void Start()
    {
        
    }

    

    void Update()
    {
        getInput();

        startShooting();
    }

    void getInput()
    {
        
    }

    void startShooting()
    {
        if (canShoot)
            StartCoroutine("Shoot");
           
    }

    IEnumerator Shoot()
    {
        if (Input.GetAxis("Shoot") > 0)
        {
            currentGunBarrel = gunBarrels[currentBarrelNumber];
            currentBarrelNumber += 1;
            if(currentBarrelNumber >= gunBarrels.Length)
            {
                currentBarrelNumber = 0;
            }
            Instantiate(laserBullet, currentGunBarrel.transform.position, currentGunBarrel.transform.rotation);
            canShoot = false;
            yield return new WaitForSeconds(.5f);
            canShoot = true;
        }
    }
}
