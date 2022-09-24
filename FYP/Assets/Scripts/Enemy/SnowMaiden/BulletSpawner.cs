using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;

    private float shotCooldown;
    public float startTimeOfShot;

    void Start()
    {
        shotCooldown = startTimeOfShot;
    }

    void Update()
    {
        ShotTimeCount();
    }

    void ShotTimeCount()
    {
        if (shotCooldown <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            shotCooldown = startTimeOfShot;
        }
        else
        {
            shotCooldown -= Time.deltaTime;
        }
    }
}
