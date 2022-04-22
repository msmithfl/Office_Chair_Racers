using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusPoint : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    public Vector3 center;

    public bool isFocused;

    void Start()
    {
        center = transform.position;
    }

    void Update()
    {    
        if(object1 == null)
        {
            return;
        }
        if (object2 == null)
        {
            return;
        }
        center = ((object2.position - object1.position) / 2.0f) + object1.position;
        transform.position = center;  
    }
}
