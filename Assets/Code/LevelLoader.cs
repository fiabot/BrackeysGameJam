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
}
