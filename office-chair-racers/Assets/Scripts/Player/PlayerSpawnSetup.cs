using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] playerSkins = new GameObject[2];
    [SerializeField] private GameObject[] playerIndicators;
    private GameObject multiplayerManager;

    public int playerIndex = 0; //P1 or P2, set in MultiplayerSpawn script
    public bool isWaitingForCountdown = true;

    void Start()
    {
        multiplayerManager = GameObject.FindGameObjectWithTag("MultiplayerManager");

        if (multiplayerManager.GetComponent<MultiplayerSpawn>().playerCount == 1)
        {
            playerSkins[0].SetActive(false);
            playerIndicators[0].SetActive(false);
        }
        else
        {
            playerSkins[1].SetActive(false);
            playerIndicators[1].SetActive(false);
        }
    }
}
