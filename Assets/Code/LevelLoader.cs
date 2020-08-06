using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void loadLevel(int level)
    {
        Debug.Log("Loading: " + level);
        SceneManager.LoadScene(level); 
    }

    public void loadLevel(string level)
    {
        Debug.Log("Loading: "+ level);
        SceneManager.LoadScene(level); 
    }

    public void loadFirstScene()
    {
        LoadSwitch("Intro", "LevelSelect", "hasPlayed"); 
    }

    public void LoadSwitch(string firstTime, string secondTime, string keyWord)
    {
        if(PlayerPrefs.GetInt(keyWord,0)== 0)
        {
            PlayerPrefs.SetInt(keyWord, 1);
            SceneManager.LoadScene(firstTime); 
        }
        else
        {
            SceneManager.LoadScene(secondTime); 
        }
    }
}
