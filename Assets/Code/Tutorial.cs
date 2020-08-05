using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Image[] tutorials;
    int nextIndex = 0;
    public Button nextButton;
    public Button backButton; 

    private void Start()
    {
        showNextImage();
        backButton.interactable = false; 
    }
    public void showImage(int image)
    {
        for (int i = 0; i < tutorials.Length; i++)
        {
            if(i == image)
            {
                tutorials[i].gameObject.SetActive(true);
            }
            else{
                tutorials[i].gameObject.SetActive(false);
            }
        }
    }

    public void showNextImage()
    {
        showImage(nextIndex);
        nextIndex++;
        if(nextIndex >= tutorials.Length)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }

        if(nextIndex > 1)
        {
            backButton.interactable = true; 
        }
    }

    public void showPreviousImage()
    {
         
        showImage(nextIndex - 2);
        nextIndex--;
        if (nextIndex <= 1)
        {
            backButton.interactable = false;
        }
        else
        {
            backButton.interactable = true;
        }

        if (nextIndex < tutorials.Length)
        {
            nextButton.interactable = true;
        }
    }
}
