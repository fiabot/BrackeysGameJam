using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public Rigidbody2D rd;
    public SpriteRenderer sprite;

    Vector2 input;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        anim.SetBool("isMoving", Mathf.Abs(input.x) + Mathf.Abs(input.y) > 0);
        
        if(input.y > 0)
        {
            
            anim.SetBool("facingForward", false);
        }else if (input.y < 0)
        {
            anim.SetBool("facingForward", true); 
        }

        if(input.x > 0)
        {
            sprite.flipX = false; 
        }
        else if(input.x < 0)
        {
            sprite.flipX = true; 
        }

    }

    private void FixedUpdate()
    {
        //rd.MovePosition(rd.position + input * Time.deltaTime * speed);
        transform.Translate(input * speed * Time.deltaTime);
    }
}
