using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] playerSkins = new GameObject[2];
    private GameObject playerManager;

    public int playerIndex = 0; //P1 or P2, set in MultiplayerSpawn script
    public bool isWaitingForPlayers = true;

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameManager");

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
