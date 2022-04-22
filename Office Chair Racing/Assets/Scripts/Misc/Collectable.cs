using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Vector3 rotation;
    [SerializeField] private float rotSpeed = 0.5f;

    void Start()
    {
        rotation = new Vector3(0, 90, 0);
    }

    void Update()
    {
        transform.Rotate(rotation.x, rotation.y * rotSpeed * Time.deltaTime, rotation.z);
    }
}
