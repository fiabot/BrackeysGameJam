using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryObj : MonoBehaviour
{
    public Image fillBar;
    public ParticleSystem workingEffect;
    public float totalTime;
    public float maxTime;
    public bool hasGhost; 
    float time;
    bool showCanvas;
    bool touchingPlayer;
    bool active;
    Player player; 
    private void Start()
    {
        
        touchingPlayer = false;
        time = totalTime;
        workingEffect.Stop();
        active = true;
        maxTime = totalTime + 0.5f;
        player = God.instance.player.GetComponent<Player>(); 
    }

    public void Damage(float amount)
    {
        time += amount;
        fillBar.fillAmount = Mathf.Clamp(1 - (time / totalTime), 0, 1);
        
        if(time > maxTime)
        {
            God.instance.DestroyItem(this);
            Destroy(gameObject); 
        }
    }
    private void Update()
    {
        if (touchingPlayer && !player.carryingGhost)
        {
            time -= Time.deltaTime;
            fillBar.fillAmount = Mathf.Clamp(1 -(time / totalTime), 0, 1);
            if (time <= 0)
            {
                CollectObject();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !player.carryingGhost)
        {
            touchingPlayer = true;
            workingEffect.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchingPlayer = false;
            workingEffect.Stop();
        }
    }

    void CollectObject()
    {
        if (active)
        {
            God.instance.CollectItem(this);
            active = false; 
            Destroy(gameObject);
        }
        
    }

}
