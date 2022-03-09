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
    public bool isWaitingForPlayers = true;

    public int playerIndex = 0; //P1 or P2, set in MultiplayerSpawn script
    public int lapNumber;
    public int checkpointIndex;

    [SerializeField] private GameObject[] playerSkins = new GameObject[2];

    private Rigidbody myRigidbody;
    private Animator myAnimator;
    private GameObject playerManager;
    [SerializeField] private ParticleSystem smokeParticles;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();

        lapNumber = 1;
        checkpointIndex = 0;

        playerManager = GameObject.FindGameObjectWithTag("MultiplayerManager");

        //single player setup
        if (playerManager == null)
        {
            isWaitingForPlayers = false;
            return;
        }
        //multi-player setup
        else
        {
            if (playerManager.GetComponent<MultiplayerSpawn>().playerCount == 1)
            {
                playerSkins[0].SetActive(false);
            }
            else
            {
                playerSkins[1].SetActive(false);
            }
        }
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

    public void OnSteering(InputAction.CallbackContext context)
    {
        steerInput = context.ReadValue<Vector2>();
    }

    private void PlayerAccelerate()
    {
        if (isAccelerating && !isWaitingForPlayers)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            StartCoroutine(ResetAngularVelocity());
        }
    }

    //used to fix out of control spinning after collisions
    IEnumerator ResetAngularVelocity()
    {
        yield return new WaitForSeconds(0.2f);
        myRigidbody.angularVelocity = Vector3.zero;
    }

    private void PlayerAnimations()
    {
        myAnimator.SetBool("isAccelerating", isAccelerating);
    }
}
