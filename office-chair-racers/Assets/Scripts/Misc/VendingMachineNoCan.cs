using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineNoCan : MonoBehaviour
{
    private Animator myAnim;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.relativeVelocity.magnitude > 3f)
            {
                myAnim.SetTrigger("wasHit");
            }
        }
    }
}
