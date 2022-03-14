using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerSpawn : MonoBehaviour
{
    private GameObject spawnPointP1;
    private GameObject spawnPointP2;
    public int playerCount = 0;

    public bool waitForPlayersBool = true;

    private CountdownTimer countdownTimer;

    public void OnPlayerJoined()
    {
        //code for first player joined
        if (playerCount == 0 && SceneManager.GetActiveScene().buildIndex != 0)
        {
            spawnPointP1 = GameObject.FindGameObjectWithTag("SpawnPoint1");
            PlayerSpawnSetup player = FindObjectOfType<PlayerSpawnSetup>();
            player.transform.position = spawnPointP1.transform.position;
            player.transform.rotation = spawnPointP1.transform.rotation;
            player.playerIndex = 1;
            playerCount++;
        }
        //code for second
        else if (playerCount == 1)
        {
            spawnPointP2 = GameObject.FindGameObjectWithTag("SpawnPoint2");
            PlayerSpawnSetup player = FindObjectOfType<PlayerSpawnSetup>();
            player.transform.position = spawnPointP2.transform.position;
            player.transform.rotation = spawnPointP2.transform.rotation;
            player.playerIndex = 2;
            playerCount++;
            waitForPlayersBool = false;
            countdownTimer = FindObjectOfType<CountdownTimer>();
            StartCoroutine(countdownTimer.StartRaceCountdown());
        }
    }
}
