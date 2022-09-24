using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tengu : MonoBehaviour
{
    public Animator anim;
    public Transform target;
    public float tenguSpeed;
    public bool enableAct;

    public Slider tenguHP;

    void Start()
    {
        anim = GetComponent<Animator>();

        enableAct = true;
    }

    private void Update()
    {
        if (enableAct == true)
        {
            RotateTengu();
            MoveTengu();
        }
    }

    void RotateTengu()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, 
                                                   Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }
    void MoveTengu()
    {
        if((target.position - transform.position).magnitude >= 0.6)
        {
            anim.SetBool("isWalking", true);
            transform.Translate(Vector3.forward * tenguSpeed * Time.deltaTime, Space.Self);
        }

        if ((target.position - transform.position).magnitude < 0.6)
        {
            anim.SetBool("isWalking", false);
        }
    }

    public void TenguAtk()
    {
        if ((target.position - transform.position).magnitude < 0.6)
        {
            anim.Play("stomp");
        }
    }

    void FreezeTengu()
    {
        enableAct = false;
    }

    void UnFreezeTengu()
    {
        enableAct = true;
    }
}
