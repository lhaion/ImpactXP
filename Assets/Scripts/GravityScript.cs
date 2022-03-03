using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public Transform target;
    public float speed = 3;

    void Update()
    {
        transform.RotateAround(target.position, transform.up, speed * Time.deltaTime);
    }
}
