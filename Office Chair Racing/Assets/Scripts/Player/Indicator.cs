using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.parent.position.x - 0.05f, 0.05f, transform.parent.position.z);
    }
}
