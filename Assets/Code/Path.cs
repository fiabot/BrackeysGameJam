using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Path : MonoBehaviour
{
    int nextPoint;

    private void Start()
    {
        nextPoint = 0; 
    }

    public Transform nextPosition()
    {
        Transform returnPos = transform.GetChild(nextPoint).transform;
        nextPoint++;
        if(nextPoint >= transform.childCount)
        {
            nextPoint = 0; 
        }
        return returnPos; 
    }
}
