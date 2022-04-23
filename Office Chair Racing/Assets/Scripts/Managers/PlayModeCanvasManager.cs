using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayModeCanvasManager : MonoBehaviour
{
    [Header("Wait For Players UI")]
    [SerializeField] private GameObject waitForPlayersObj;
    [SerializeField] private TMP_Text waitForPlayersText;

    [Header("Winner UI")]
    [SerializeField] private TMP_Text winnerText;

    [Header("Player UI")]
    [SerializeField] private TMP_Text p1LapCounter;
    [SerializeField] private Image p1BoostUI;
    [SerializeField] private TMP_Text p2LapCounter;
    [SerializeField] private Image p2BoostUI;
    private Color boostUIColor;

    [Header("After Game Menu")]
    [SerializeField] private AfterGameMenuManager afterGameMenuManager;

    private MultiplayerSpawn multiplayerSpawn;
    private LapManager lapManager;

    void Start()
    {
        multiplayerSpawn = FindObjectOfType<MultiplayerSpawn>();
        lapManager = FindObjectOfType<LapManager>();

        p1LapCounter.text = $"P1: Lap 1/{lapManager.totalLaps}";
        p2LapCounter.text = $"P1: Lap 1/{lapManager.totalLaps}";

        boostUIColor = p1BoostUI.color;
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

    public void UpdateBoostUI(int playerIndex)
    {
        if(playerIndex == 1)
        {
            p1BoostUI.color = new Color(1, 1, 1, 1);
        }
        else if(playerIndex == 2)
        {
            p2BoostUI.color = new Color(1, 1, 1, 1);
        }
    }

    //called from LapManager
    public void UpdateLapUI(int playerIndex, PlayerMovement player)
    {
        if (playerIndex == 1)
        {
            if (player.lapNumber > lapManager.totalLaps) { return; }
            p1LapCounter.text = $"P1: Lap {player.lapNumber}/{lapManager.totalLaps}";
        }
        else if (playerIndex == 2)
        {
            if (player.lapNumber > lapManager.totalLaps) { return; }
            p2LapCounter.text = $"P2: Lap {player.lapNumber}/{lapManager.totalLaps}";
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
