using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemImage : MonoBehaviour
{
    public string keyWord;
    public GameObject colorImage;
    public Image background;
    public bool usePlayerPrefs = false; 
    // Start is called before the first frame update
    void Start()
    {
        if(usePlayerPrefs && PlayerPrefs.GetInt(keyWord,0) == 1)
        {
            colorImage.SetActive(true); 
        }
        else if(God.instance != null && God.instance.foundItem(keyWord))
        {
            colorImage.SetActive(true);
        }
        else
        {
            colorImage.SetActive(false); 
        }
    }

    public void objectDestroyed()
    {
        background.color = Color.black; 
    }


    
}
