using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 50f;
    [SerializeField] private float m_SteerSpeed = 1f;
    private Vector2 m_SteerInput;
    private bool m_IsAccelerating = false;

    [Header("Lap Counter")]
    public int lapNumber;
    public int checkpointIndex;

    [Header("Boost Indicators")]
    public bool hasBoost;
    public bool isBoosting;

    private Rigidbody m_Rigidbody;
    private Animator m_Animator;
    private PlayerSpawnSetup m_PlayerSpawnSetup;

    public ParticleSystem smokeParticles;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_PlayerSpawnSetup = GetComponent<PlayerSpawnSetup>();
    }

    void Start()
    {
        lapNumber = 1;
        checkpointIndex = 0;
    }

    public void OnAccelerate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_IsAccelerating = true;
            smokeParticles.Play();
        }
        else if (context.canceled)
        {
            m_IsAccelerating = false;
            smokeParticles.Stop();
        }
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        if (context.performed && hasBoost && !isBoosting)
        {
            isBoosting = true;
        }
    }

    public void OnSteering(InputAction.CallbackContext context)
    {
        m_SteerInput = context.ReadValue<Vector2>();
    }

    private void PlayerAccelerate()
    {
        if (m_IsAccelerating && !m_PlayerSpawnSetup.isWaitingForCountdown)
        {
            m_Rigidbody.AddRelativeForce(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }

    private void PlayerRotate()
    {
        if (m_SteerInput.x < -0.1)
        {
            transform.Rotate(0, -m_SteerSpeed, 0);
        }
        else if (m_SteerInput.x > 0.1)
        {
            transform.Rotate(0, m_SteerSpeed, 0);
        }
    }

    void FixedUpdate()
    {
        PlayerAccelerate();
        PlayerRotate();
    }

    private void Update()
    {
        PlayerAnimations();
    }

    private void PlayerAnimations()
    {
        m_Animator.SetBool("isAccelerating", m_IsAccelerating);
    }

    //used to fix out of control spinning after collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            StartCoroutine(ResetAngularVelocity());
        }
    }

    IEnumerator ResetAngularVelocity()
    {
        yield return new WaitForSeconds(0.2f);
        m_Rigidbody.angularVelocity = Vector3.zero;
    }
}
