using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private Transform destination = EnemyDestination.destination;
    public Enemy enemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.destination = destination.position;
        myAgent.speed = enemy.startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        myAgent.speed = enemy.speed;
        enemy.speed = enemy.startSpeed;
        
        Vector3 distance = transform.position - destination.position;
        distance.y = 0;
        if(distance.magnitude <= 1.5f)
        {
            EndPath();
        }
    }
    
    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
