using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplayerSpawn : MonoBehaviour
{
    public GameObject spawnPointP1;
    public GameObject spawnPointP2;
    public int playerCount = 0;

    [SerializeField] private GameObject waitForPlayersText;

    private GameManager gameManager;
    private CountdownTimer countdownTimer;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        countdownTimer = gameManager.GetComponent<CountdownTimer>();

        //BUG---this gameObject/script currently won't respond to game mode, set in GameManager
        //------needed to turn on/off MultiplayerManager

        //if (gameManager.twoPlayerMode == true)
        //{
        //    gameObject.SetActive(true);
        //}
        //else
        //{
        //    gameObject.SetActive(false);
        //}

        waitForPlayersText.SetActive(true);
    }

    public void OnPlayerJoined()
    {
        //code for first player joined
        if (playerCount == 0)
        {
            PlayerSpawnSetup player = FindObjectOfType<PlayerSpawnSetup>();
            player.transform.position = spawnPointP1.transform.position;
            player.transform.rotation = spawnPointP1.transform.rotation;
            player.playerIndex = 1;
            playerCount++;
            
        }
        //code for second
        else if (playerCount == 1)
        {
            PlayerSpawnSetup player = FindObjectOfType<PlayerSpawnSetup>();
            player.transform.position = spawnPointP2.transform.position;
            player.transform.rotation = spawnPointP2.transform.rotation;
            player.playerIndex = 2;
            playerCount++;
            waitForPlayersText.SetActive(false);
            StartCoroutine(countdownTimer.StartRaceCountdown());
        }
    }
}
