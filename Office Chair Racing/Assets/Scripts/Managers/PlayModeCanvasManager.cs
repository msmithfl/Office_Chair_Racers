using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private MultiplayerSpawn multiplayerSpawn;

    [SerializeField] private GameObject waitForPlayersText;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        multiplayerSpawn = gameManager.GetComponent<MultiplayerSpawn>();
    }

    void Update()
    {
        if (!multiplayerSpawn.waitForPlayersBool)
        {
            waitForPlayersText.SetActive(false);
        }
    }
}
