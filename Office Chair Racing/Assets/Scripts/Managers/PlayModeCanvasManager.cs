using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayModeCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject waitForPlayersObj;
    [SerializeField] private TMP_Text waitForPlayersText;

    private MultiplayerSpawn multiplayerSpawn;

    void Start()
    {
        multiplayerSpawn = FindObjectOfType<MultiplayerSpawn>();
    }

    void Update()
    {
        if (!multiplayerSpawn.waitForPlayersBool)
        {
            waitForPlayersObj.SetActive(false);
        }

        if (multiplayerSpawn.playerCount == 0)
        {
            waitForPlayersText.text = "Waiting for 2 player(s)...";
        }
        if (multiplayerSpawn.playerCount == 1)
        {
            waitForPlayersText.text = "Waiting for 1 player(s)...";
        }
    }
}
