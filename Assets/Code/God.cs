using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class God : MonoBehaviour
{
    public static God instance;
    public ObjTemplate[] objects;
    public float ghostTime;
    float ghostCountDown;

    public GameObject gameOverScreen;
    public Image timerDisplay;
    public Transform player;
    public GameObject GhostPrefab;

    public GameObject GhostTimer; 
  

    [NonSerialized]
    public int itemsRemaining;

    bool spawningGhosts;
    int ghostSpawned; 

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;

        instance = this;
        gameOverScreen.SetActive(false);
        ghostCountDown = ghostTime;
        itemsRemaining = objects.Length;
        spawningGhosts = true; 

    }
    private void Update()
    {
        if (spawningGhosts)
        {
            if(ghostSpawned >= itemsRemaining)
            {
                stopGhosts();
            }
            else
            {
                ghostCountDown -= Time.deltaTime;
                timerDisplay.fillAmount = Mathf.Clamp(ghostCountDown / ghostTime, 0, 1);
                if (ghostCountDown <= 0)
                {
                    ghostCountDown = ghostTime;
                    SpawnGhost();
                }
            }
            
        }
        
    }

    public void GameOver(){
        SoundManager.instance.playGoodGameOver(); 
        gameOverScreen.SetActive(true);
        Time.timeScale = 0; 
    }

    public void CollectItem(MemoryObj itemFound)
    {
        SoundManager.instance.playCollect();
        itemsRemaining--; 
        foreach(ObjTemplate ob in objects)
        {
            if(ob.memoryObject == itemFound)
            {
                ob.found = true;
                PlayerPrefs.SetInt(ob.name, 1);
 
            }
        }
        if(itemsRemaining <= 0)
        {
            GameOver(); 
        }
    }

    public void DestroyItem(MemoryObj itemDestroyed)
    {
        SoundManager.instance.playItemLost();
        itemsRemaining--;
        foreach (ObjTemplate ob in objects)
        {
            if (ob.memoryObject == itemDestroyed)
            {
                ob.destroyed = false;
                ob.UIImage.color = Color.black; 
                PlayerPrefs.SetFloat(ob.name, 0);
                
            }
        }
        if (itemsRemaining <= 0)
        {
            GameOver();
        }
    }

    public bool foundItem(string name)
    {
        foreach (ObjTemplate ob in objects)
        {
            if (ob.name == name)
            {
                return ob.found;
            }
        }
        return false;
    }

    public bool ItemDestroyed(string name)
    {
        foreach(ObjTemplate ob in objects)
        {
            if (ob.name == name)
            {
                return ob.destroyed;
            }
        }
        return false;
    }

    public bool ItemInGame(string name)
    {
        foreach (ObjTemplate ob in objects)
        {
            if (ob.name == name)
            {
                return !ob.destroyed && !ob.found;
            }
        }
        return false;
    }

    public ObjTemplate GetClosestObject()
    {
        float minDistance = Mathf.Infinity;
        ObjTemplate closestObject = null;
       
        foreach(ObjTemplate obj in objects)
        {
            if(obj.position != null && !obj.memoryObject.hasGhost)
            {
                float distance = Vector2.Distance(player.position, obj.position.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestObject = obj;
                }
            }
            
        }
        return closestObject; 
    }

    public void SpawnGhost()
    {
        ghostSpawned++; 
        SoundManager.instance.playGhost();
        //spawningGhosts = false; 
        if (GetClosestObject() != null)
        {
            CameraMovement.startShake(0.5f); 
            Vector3 SpawnPoint = GetClosestObject().GhostPoint.position;
            Instantiate(GhostPrefab, SpawnPoint, transform.rotation);

            StartCoroutine(stopTimerCheck()); 
        }
        else
        {
            stopGhosts();
        }
        
    }

    IEnumerator stopTimerCheck()
    {
        yield return new WaitForSeconds(0.2f);
        CameraMovement.stopShake(); 
        if(GetClosestObject() == null)
        {
            stopGhosts();
        }
        else
        {
            startGhosts();
        }

    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void stopGhosts()
    {
        Debug.Log("Stop Spawning"); 
        spawningGhosts = false;
        GhostTimer.SetActive(false); 
    }

    public void startGhosts()
    {
        spawningGhosts = true;
        GhostTimer.SetActive(true); 
    }

    public void ghostDestroyed()
    {
        ghostSpawned--; 
    }
}
