using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLifeTrigerZone : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && PlayerStats.Lives == 1)
        {
            gameManager.LastLifeAnimation(other.GetComponent<Enemy>());
        }
    }
}
