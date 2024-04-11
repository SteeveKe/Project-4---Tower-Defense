using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public CinemachineVirtualCamera lastLifeCamera;
    private bool hasTarget = false;
    

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        if (!GameIsOver)
        {
            GameIsOver = true;
            completeLevelUI.SetActive(true);
        }
    }

    public void LastLifeAnimation(Enemy enemy)
    {
        StartCoroutine(TrackEnemy(enemy));
    }

    IEnumerator TrackEnemy(Enemy enemy)
    {
        if (!hasTarget && !GameIsOver)
        {
            hasTarget = true;
            lastLifeCamera.gameObject.SetActive(true);
            lastLifeCamera.LookAt = enemy.gameObject.transform;
            Time.timeScale = 0.1f;
        
            while (!enemy.IsDestroyed())
            {
                yield return null;
            }

            Time.timeScale = 1f;
            lastLifeCamera.gameObject.SetActive(false);
            lastLifeCamera.LookAt = null;
            hasTarget = false;
        }
    }
}
