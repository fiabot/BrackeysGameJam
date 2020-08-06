using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostCardFlip : MonoBehaviour
{
    public GameObject back;
    public GameObject front;
    bool showBack = false;

    private void Start()
    {
        if (showBack)
        {
            back.SetActive(true);
            front.SetActive(false);
        }
        else
        {
            back.SetActive(false);
            front.SetActive(true);
        }
    }

    public void flip()
    {
        showBack = !showBack;

        if (showBack)
        {
            back.SetActive(true);
            front.SetActive(false);
        }
        else
        {
            back.SetActive(false);
            front.SetActive(true);
        }
    }
}
