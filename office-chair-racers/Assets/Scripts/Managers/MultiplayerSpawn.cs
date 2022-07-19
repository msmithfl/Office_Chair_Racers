using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerSpawn : MonoBehaviour
{
    private GameObject m_SpawnPointP1;
    private GameObject m_SpawnPointP2;

    public int playerCount = 0;
    public bool waitForPlayersBool = true;

    private CountdownTimer m_CountdownTimer;
    private CameraFocusPoint m_CameraFocusScript;
    private CameraManager m_CameraManager;

    private void Awake()
    {
        m_CountdownTimer = FindObjectOfType<CountdownTimer>();
        m_CameraFocusScript = FindObjectOfType<CameraFocusPoint>();
        m_CameraManager = FindObjectOfType<CameraManager>();
    }

    public void OnPlayerJoined()
    {
        if (playerCount == 0 && SceneManager.GetActiveScene().buildIndex != 0)
        {
            SpawnPlayerOne();
        }
        else if (playerCount == 1)
        {
            SpawnPlayerTwo();
        }
    }

    private void SpawnPlayerOne()
    {
        m_SpawnPointP1 = GameObject.FindGameObjectWithTag("SpawnPoint1");
        PlayerSpawnSetup player = FindObjectOfType<PlayerSpawnSetup>();
        player.transform.position = m_SpawnPointP1.transform.position;
        player.transform.rotation = m_SpawnPointP1.transform.rotation;
        player.playerIndex = 1;
        m_CameraFocusScript.object1 = player.transform;
        playerCount++;
    }

    private void SpawnPlayerTwo()
    {
        m_SpawnPointP2 = GameObject.FindGameObjectWithTag("SpawnPoint2");
        PlayerSpawnSetup player = FindObjectOfType<PlayerSpawnSetup>();
        player.transform.position = m_SpawnPointP2.transform.position;
        player.transform.rotation = m_SpawnPointP2.transform.rotation;
        player.playerIndex = 2;
        playerCount++;
        waitForPlayersBool = false;
        StartCoroutine(m_CountdownTimer.StartRaceCountdown());
        m_CameraFocusScript.object2 = player.transform;
        m_CameraFocusScript.isFocused = true;
        m_CameraManager.SwitchCameraPriority();
    }
}
