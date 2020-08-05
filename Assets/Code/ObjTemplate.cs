using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ObjTemplate
{
    public string name;
    public MemoryObj memoryObject;
    public Transform position;
    public Transform GhostPoint; 
    public bool found = false;
    public bool destroyed = false;
    public Image UIImage; 
}
