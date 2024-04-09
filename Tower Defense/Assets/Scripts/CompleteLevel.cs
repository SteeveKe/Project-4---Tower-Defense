using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    
    public string nextLevel = "level2";
    public int levelToUnlock = 2;
    
    public SceneFader sceneFader;

    private void Awake()
    {
        UnlockLevel(levelToUnlock);
    }

    private void UnlockLevel(int levelUnlock)
    {
        int current = PlayerPrefs.GetInt("levelReached", 1);
        if (levelUnlock > current)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}

