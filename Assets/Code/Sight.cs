using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float range;
    public LineRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.right, range);

        if (hit2D.collider != null)
        {

            Debug.DrawLine(transform.position, hit2D.point, Color.red);
            rend.SetPosition(1, hit2D.point);
            if (hit2D.collider.gameObject.tag == "Player")
            {
                StartCoroutine(sightWaitTime());
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.right, Color.green);
            rend.SetPosition(1, transform.position + transform.right * range);
        }
        rend.SetPosition(0, transform.position);
    }

    IEnumerator sightWaitTime()
    {

        yield return new WaitForSeconds(0.2f);

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.right, range);

        if (hit2D.collider != null)
        {

            Debug.DrawLine(transform.position, hit2D.point, Color.red);
            rend.SetPosition(1, hit2D.point);
            if (hit2D.collider.gameObject.tag == "Player")
            {
                SoundManager.instance.playSeen();
                God.instance.GameOver();
            }
        }
    }
}