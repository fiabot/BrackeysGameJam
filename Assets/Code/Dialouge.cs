using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialouge : MonoBehaviour
{
    public GameObject[] dialouges;
    public ScrollRect scroll;
    public RectTransform content;
    public Button ContinueButton;
    public GameObject BeginButton;
    public int sizeIncrease = 250; 
    int currentDialouge; 
    // Start is called before the first frame update
    void Start()
    {
        showDialouge(currentDialouge); 
    }

    public void showNext()
    {
        currentDialouge++;
        if(currentDialouge >= dialouges.Length)
        {
            ContinueButton.interactable = false;
            BeginButton.gameObject.SetActive(true);
        }
        else
        {
            showDialouge(currentDialouge);
        }
        
    }

    void showDialouge(int index)
    {
        for (int i = 0; i < dialouges.Length; i++)
        {
            if(i <= index)
            {
                dialouges[i].SetActive(true);
            }
            else
            {
                dialouges[i].SetActive(false); 
            }
        }
        content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y + sizeIncrease);
        scroll.verticalNormalizedPosition = 0; 
    }
}
