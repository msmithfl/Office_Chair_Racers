using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float steerSpeed = 1f;
    private Vector2 steerInput;
    private bool isAccelerating = false;

    public int lapNumber;
    public int checkpointIndex;

    public bool hasBoost;
    public bool isBoosting;

    private Rigidbody myRigidbody;
    private Animator myAnimator;
    private PlayerSpawnSetup playerSpawnSetup;

    [SerializeField] private ParticleSystem smokeParticles;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        playerSpawnSetup = GetComponent<PlayerSpawnSetup>();

        lapNumber = 1;
        checkpointIndex = 0;
    }

    public void OnAccelerate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isAccelerating = true;
            smokeParticles.Play();
        }
        else if (context.canceled)
        {
            isAccelerating = false;
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
        steerInput = context.ReadValue<Vector2>();
    }

    private void PlayerBoost()
    {
        if (isBoosting && hasBoost)
        {
            hasBoost = false;
            var main = smokeParticles.main;
            main.startColor = Color.blue;
            main.simulationSpeed = 2;
            moveSpeed = 500;
            StartCoroutine(TurnOffBoost());
        }
    }

    private IEnumerator TurnOffBoost()
    {
        yield return new WaitForSeconds(4);
        isBoosting = false;
        var main = smokeParticles.main;
        main.startColor = Color.white;
        main.simulationSpeed = 1;
        moveSpeed = 300;
    }

    private void PlayerAccelerate()
    {
        if (isAccelerating && !playerSpawnSetup.isWaitingForPlayers)
        {
            myRigidbody.AddRelativeForce(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }

    private void PlayerRotate()
    {
        if (steerInput.x < -0.1)
        {
            transform.Rotate(0, -steerSpeed, 0);
        }
        else if (steerInput.x > 0.1)
        {
            transform.Rotate(0, steerSpeed, 0);
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
        PlayerBoost();
    }

    private void PlayerAnimations()
    {
        myAnimator.SetBool("isAccelerating", isAccelerating);
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
        myRigidbody.angularVelocity = Vector3.zero;
    }
}
