using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;
    private Vector3 targetPosition = Vector3.zero;
    private Transform targetTransform = null;
    
    private Rigidbody aiRigidbody;

    void Awake()
    {
        aiRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //aiRigidbody.AddRelativeForce(Vector3.back * moveSpeed * Time.deltaTime);
        FollowPlayer();
        TurnTowardTarget();
    }

    void FollowPlayer()
    {
        if (targetTransform == null)
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (targetTransform != null)
        {
            targetPosition = targetTransform.position;
        }
    }

    void TurnTowardTarget()
    {
        Vector3 vectorToTarget = targetPosition - transform.position;
        vectorToTarget.Normalize();
        //print(vectorToTarget);
        aiRigidbody.AddRelativeForce(-vectorToTarget * moveSpeed * Time.deltaTime);
    }
}
