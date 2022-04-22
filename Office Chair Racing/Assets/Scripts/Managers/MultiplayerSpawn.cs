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
    private CameraFocusPoint cameraFocusScript;

    private void Awake()
    {
        countdownTimer = FindObjectOfType<CountdownTimer>();
        cameraFocusScript = FindObjectOfType<CameraFocusPoint>();
    }

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
            cameraFocusScript.object1 = player.transform;
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
            StartCoroutine(countdownTimer.StartRaceCountdown());
            cameraFocusScript.object2 = player.transform;
            cameraFocusScript.isFocused = true;
        }
    }
}
