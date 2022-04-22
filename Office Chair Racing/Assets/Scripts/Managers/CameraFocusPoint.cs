using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusPoint : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    private Vector3 center;

    public bool isFocused;

    public float distanceBetweenPlayers;

    void Start()
    {
        center = transform.position;
    }

    void Update()
    {    
        if (object1 == null)
        {
            return;
        }
        if (object2 == null)
        {
            return;
        }

        distanceBetweenPlayers = Vector3.Distance(object1.position, object2.position);
        //try moving back the camera on its local z axis when the objects are far apart (based on distance)

        center = ((object2.position - object1.position) / 2.0f) + object1.position;

        float clampedZ = Mathf.Clamp(center.z, 0, 8);
        float clampedX = Mathf.Clamp(center.x, -7, 6);

        transform.position = new Vector3(clampedX, 0, clampedZ);
    }
}
