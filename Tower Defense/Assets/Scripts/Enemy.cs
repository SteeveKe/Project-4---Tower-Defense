using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    public float health = 100;
    public int value = 50;
    
    private bool EnemyDiesOnce ;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
        EnemyDiesOnce = false;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            if (!EnemyDiesOnce)
            {
                Die();
            }
        }
    }

    void Die()
    {
        EnemyDiesOnce = true;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        PlayerStats.Money += value;
        
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1 - pct);
    }
}
