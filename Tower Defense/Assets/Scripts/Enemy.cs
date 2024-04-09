using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    
    public float startHealth = 100;
    private float health;
    
    public int value = 50;
    
    private bool EnemyDiesOnce ;

    public GameObject deathEffect;

    [Header("Unity Stuff")] public Image healthBar;

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
        EnemyDiesOnce = false;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;
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

        WaveSpawner.EnemiesAlive--;
        
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1 - pct);
    }
}
