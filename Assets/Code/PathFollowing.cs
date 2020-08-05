using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public float speed;
    public SpriteRenderer sprite;
    public Animator anim; 
    Transform target;
    public Path path;
    public Transform sight; 
    // Start is called before the first frame update
    void Start()
    {
        target = path.nextPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        anim.SetBool("isMoving", Mathf.Abs(dir.x) + Mathf.Abs(dir.y) > 0);

        if(Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if(dir.x > 0)
            {
                sight.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (dir.x < 0)
            {
                sight.eulerAngles = new Vector3(0, 0, 180);
            }

        }
        else
        {
            if (dir.y > 0)
            {
                sight.eulerAngles = new Vector3(0, 0, 90);
            }
            else if (dir.y < 0)
            {
                sight.eulerAngles = new Vector3(0, 0, -90);
            }
        }

        if (dir.x > 0)
        {
            sprite.flipX = false;
            

        }
        else if (dir.x < 0)
        {
            sprite.flipX = true;
            
        }

        if (dir.y > 0)
        {

            anim.SetBool("facingForward", false);
            

        }
        else if (dir.y < 0)
        {
            anim.SetBool("facingForward", true);
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.2)
        {
            target = path.nextPosition(); 
        }

    }
}
