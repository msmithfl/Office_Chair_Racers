using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private PlayerInputManager playerInputManager;

    public bool soloMode;
    public bool twoPlayerMode;
    public bool timeTrialMode;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this);
        }
        else if (gameManager != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    private void Update()
    {
        if (twoPlayerMode == true)
        {
            playerInputManager.enabled = true;
        }
        if (twoPlayerMode == false)
        {
            playerInputManager.enabled = false;
        }
    }
}
