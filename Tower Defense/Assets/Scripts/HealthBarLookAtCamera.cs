using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarLookAtCamera : MonoBehaviour
{
    private Transform target;
    public float lookSpeed = 10f;
    
    private void Start()
    {
        target = FindObjectOfType<Camera>().gameObject.transform;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
    }
}
