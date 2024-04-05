using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    
    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    public TMP_Text waveCountdownText;
    private float countDown = 2f;
    private int waveIndex = 0;

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level won!");
            this.enabled = false;
        }
    }

    void SpawnEnemy( GameObject enemy)
    {
        EnemiesAlive++;
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
