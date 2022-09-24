using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowMaiden : MonoBehaviour
{
    public Transform target;
    public int icicleCount = 0;

    public Text icicleHint;

    void Update()
    {
        RotateTengu();
        HintUpdate();
    }

    void RotateTengu()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation = Quaternion.Slerp(transform.localRotation,
                                                   Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

    void HintUpdate()
    {
        icicleHint.text = "BREAK ALL icicle\n" + icicleCount + "/3";
    }
}
