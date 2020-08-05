using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 offSet;
    public Transform player;
    static bool shake;
    static float shakeMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - player.position;
        shake = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 initialPosition = player.position + offSet;

            if (shake)
            {

                transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            }
            else
            {
                transform.position = initialPosition;
            }

        }

    }

    public static void startShake(float magnitude)
    {
        shake = true;
        shakeMagnitude = magnitude;
    }

    public static void stopShake()
    {
        shake = false;
    }
}