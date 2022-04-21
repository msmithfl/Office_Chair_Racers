using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayModeCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject waitForPlayersObj;
    [SerializeField] private TMP_Text waitForPlayersText;
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private TMP_Text p1LapCounter;
    [SerializeField] private TMP_Text p2LapCounter;
    [SerializeField] private AfterGameMenuManager afterGameMenuManager;

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

    //called from LapManager
    public void UpdateLapUI(int playerIndex, PlayerMovement player)
    {
        if (playerIndex == 1)
        {
            if (player.lapNumber > 3) { return; }
            p1LapCounter.text = $"P1: Lap {player.lapNumber}/3";
        }
        else if (playerIndex == 2)
        {
            if (player.lapNumber > 3) { return; }
            p2LapCounter.text = $"P2: Lap {player.lapNumber}/3";
        }
        else
        {
            Debug.LogError("Lap Counting Error");
        }
    }

    //called from LapManager
    public void DisplayWinnerText(int playerIndex)
    {
        winnerText.text = $"P{playerIndex} Wins!";
        winnerText.gameObject.SetActive(true);
        StartCoroutine(DisableWinnerText());
    }

    public IEnumerator DisableWinnerText()
    {
        yield return new WaitForSeconds(3f);
        winnerText.gameObject.SetActive(false);
        afterGameMenuManager.SetGameMenuActive();
    }
}
