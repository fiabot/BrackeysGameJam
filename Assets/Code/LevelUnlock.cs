using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlock : MonoBehaviour
{
    public GameObject[] levelButtons; 
    // Start is called before the first frame update
    void Start()
    {
        int levelUnlocked = PlayerPrefs.GetInt("level", 0);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i <= levelUnlocked)
            {
                levelButtons[i].SetActive(true);
            }
            else
            {
                levelButtons[i].SetActive(false); 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
