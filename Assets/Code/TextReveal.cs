using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextReveal : MonoBehaviour
{
    public string intro; 
    public string[] keyWords;
    public string[] storyText;

    public Text display; 
    // Start is called before the first frame update
    void Start()
    {
        string displayText = intro;
        for (int i = 0; i < keyWords.Length; i++)
        {
            if (God.instance.foundItem(keyWords[i]))
            {
                displayText += storyText[i];
            }
        }

        display.text = displayText; 
    }

    
}
