using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public bool carryingGhost = false;
    public Transform partToRotate; 

    
    public void playBlow(Vector3 direction)
    { 
        float AngleRad = Mathf.Atan2(direction.y - partToRotate.position.y, direction.x - partToRotate.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        partToRotate.rotation = Quaternion.Euler(0f, 0f, angle);
        Debug.Log(Quaternion.Euler(0f, 0f, angle));
        anim.SetTrigger("Blow");
    }
}
