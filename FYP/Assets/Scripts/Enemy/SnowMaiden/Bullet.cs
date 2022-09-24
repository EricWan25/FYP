using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform boss;
    private Transform target;
    private Vector3 targetPos;

    public float speed;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player_Cen").transform;
        targetPos = new Vector3(target.position.x, target.position.y, target.position.z);

        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        transform.rotation = boss.rotation;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        DestroyBullet();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitBox_Player" || other.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }

    public void DestroyBullet()
    {
        if(transform.position.x == targetPos.x && transform.position.y == targetPos.y && transform.position.z == targetPos.z)
        {
            Destroy(gameObject);
        }
    }
}
