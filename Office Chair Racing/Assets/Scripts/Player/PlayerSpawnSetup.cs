using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnSetup : MonoBehaviour
{
    public int playerIndex = 0; //P1 or P2, set in MultiplayerSpawn script

    public bool isWaitingForPlayers = true;

    private GameObject playerManager;

    [SerializeField] private GameObject[] playerSkins = new GameObject[2];

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameManager");

        //single player setup
        if (playerManager.GetComponent<PlayerInputManager>().enabled == false)
        {
            playerSkins[0].SetActive(false);
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
}
