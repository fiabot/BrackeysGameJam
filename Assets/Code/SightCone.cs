using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCone : MonoBehaviour
{
    Mesh mesh;
    public LayerMask mask;
    public Vector3 origin;
    int startingAngle;
    public int sightRange = 100; 
    int fov = 100;
    public float viewDistance;
    bool hitplayer = false;
    MeshRenderer rend; 
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        rend = GetComponent<MeshRenderer>();
        origin = Vector3.zero;
        startingAngle = 0;
        fov = sightRange;
        //viewDistance = 25f; 
        rend.sortingLayerName = "BothCams";
        rend.sortingOrder = 50;
    }
    // Start is called before the first frame update
    void LateUpdate()
    {
        Physics2D.queriesStartInColliders = false;

        //Vector3 orgin = transform.localPosition; 
        
        int rayCount = 50;
        int angle = startingAngle;
        int angleIncrease = fov / rayCount;
        //float viewDistance = 25f; 
        
        
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3]; 

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0; 
        for (int i = 0; i < rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycast = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, mask);
            if(raycast.collider == null)
            {
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            { 
                vertex = raycast.point;
                if(raycast.collider.tag == "Player" && !hitplayer)
                {
                    hitplayer = true;
                    StartCoroutine(waitUntilDeath()); 
                    
                }
            }
            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }
            

            
            angle -= angleIncrease;
            vertexIndex++; 

        }
        
        
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.RecalculateBounds(); 
    }

    public void SetOrigin(Vector3 point)
    {
        origin = point; 
    }

    public void setAimDirection(int angle)
    {
        startingAngle = angle - fov / 2 - 45; 
    }

    IEnumerator waitUntilDeath()
    {
        Color deathColor = Color.red;
        deathColor.a = 0.67f; 
        rend.material.color = deathColor; 
        yield return new WaitForSeconds(0.3f);
        SoundManager.instance.playSeen();
        God.instance.GameOver();
    }

}
