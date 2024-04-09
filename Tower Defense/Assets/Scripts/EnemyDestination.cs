using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : MonoBehaviour
{
    public Transform enemiesDestination;
    public static Transform destination;

    private void Start()
    {
        destination = enemiesDestination;
        
    }
}
