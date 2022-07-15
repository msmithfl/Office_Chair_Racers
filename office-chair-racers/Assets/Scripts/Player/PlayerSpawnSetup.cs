using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] m_PlayerSkins = new GameObject[2];
    [SerializeField] private GameObject[] m_PlayerIndicators;
    private GameObject m_MultiplayerManager;

    public int playerIndex = 0; //P1 or P2, set in MultiplayerSpawn script
    public bool isWaitingForCountdown = true;

    void Start()
    {
        m_MultiplayerManager = GameObject.FindGameObjectWithTag("MultiplayerManager");

        if (m_MultiplayerManager.GetComponent<MultiplayerSpawn>().playerCount == 1)
        {
            m_PlayerSkins[0].SetActive(false);
            m_PlayerIndicators[0].SetActive(false);
        }
        else
        {
            m_PlayerSkins[1].SetActive(false);
            m_PlayerIndicators[1].SetActive(false);
        }
    }
}
