using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform target;
    public Collider2D col; 
    public float speed;
    public float range;
    public float blowRange; 
    bool followingTarget;
    bool followingPlayer; 
    MemoryObj obj;
    public LineRenderer line;
    public float kickBack;
    Vector3 position; 
    // Start is called before the first frame update
    void Start()
    {
                target = God.instance.GetClosestObject().position; 

        if(target == null)
        {
            Destroy(gameObject);
            God.instance.ghostDestroyed();
            followingTarget = false;
        }
        else
        {
            followingTarget = true;
            followingPlayer = false; 
            obj = target.gameObject.GetComponent<MemoryObj>();
            obj.hasGhost = true; 
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, God.instance.player.position) < range && Input.GetKeyDown(KeyCode.Space))
        {
            ToggleFollowing();
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = 10;

            if (dir.magnitude <= distanceThisFrame)
            {
                //hitTarget();
            }

        }
        else if (Vector2.Distance(transform.position, God.instance.player.position) < blowRange && Input.GetMouseButtonDown(0))
        {
            SoundManager.instance.playHit();
            
            Vector3 dir = target.position - transform.position;
            God.instance.player.GetComponent<Player>().playBlow(transform.position-dir);
            transform.Translate(-dir.normalized* kickBack, Space.World);
        }
        if (followingTarget)
        {
            {
                if (target == null)
                {
                    if (God.instance.GetClosestObject() == null)
                    {
                        followingTarget = false;
                        Destroy(gameObject);
                        God.instance.ghostDestroyed();
                    }
                    else
                    {
                        target = God.instance.GetClosestObject().position;
                        obj = God.instance.GetClosestObject().memoryObject;
                        obj.hasGhost = true;
                    }


                }
                else
                {
                    
                    Vector3 dir = target.position - transform.position;
                    float distanceThisFrame = speed * Time.deltaTime;

                    line.enabled = true;
                    line.SetPosition(0, transform.position);
                    line.SetPosition(1, target.position); 
                    if (dir.magnitude <= distanceThisFrame)
                    {
                        hitTarget();
                    }
                    else
                    {
                        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

                    }
                }
            }
        }
        else
        {
            line.enabled = false;
            transform.localPosition = position; 
        }
    }

    void hitTarget()
    {
        obj.Damage(Time.deltaTime);
    }

    void ToggleFollowing()
    {
        followingTarget = !followingTarget;
        if (followingTarget)
        {
            transform.parent = God.instance.transform;
            God.instance.player.GetComponent<Player>().carryingGhost = false;
            col.enabled = true;
            followingPlayer = false;

            obj.hasGhost = false;
            target = God.instance.GetClosestObject().position;       
            obj = target.gameObject.GetComponent<MemoryObj>();
            obj.hasGhost = true;
        }
        else
        {
            transform.parent = God.instance.player;
            position = transform.localPosition;  
            God.instance.player.GetComponent<Player>().carryingGhost = true;
            col.enabled = false;
            followingPlayer = true;

            

             
        }

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            col.isTrigger = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           Debug.Log("Exit"); 
            col.isTrigger = false;
        }
    }*/


}
