using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapManager : MonoBehaviour
{
    //this script is placed on the finish line/lap marker

    //when a game object enters the lap collider, it checks if it is the player
    //it then grabs a reference to the player and checks if the player's checkpointIndex equals the total amount of checkpoints
    //if the check is successful, the player's lapNumber is increased and the checkpointIndex is reset to 0
    //last, it check if the players lapNumber is greater than the total lap count to determine a winner
    public List<Checkpoint> checkpoints;
    public int totalLaps;

    private bool raceIsOver = false;

    [SerializeField] private TMP_Text p1LapCounter;
    [SerializeField] private TMP_Text p2LapCounter;
    [SerializeField] private TMP_Text winnerText;

    [SerializeField] private AfterGameMenuManager afterGameMenuManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            int playerIndex = other.gameObject.GetComponent<PlayerSpawnSetup>().playerIndex;

            if(player.checkpointIndex == checkpoints.Count)
            {
                player.lapNumber++;
                player.checkpointIndex = 0;

                //check for winner
                if (player.lapNumber > totalLaps)
                {
                    if (!raceIsOver)
                    {
                        raceIsOver = true;
                        winnerText.text = $"P{playerIndex} Wins!";
                        winnerText.gameObject.SetActive(true);
                        StartCoroutine(DisableWinnerText());   
                    }
                }

                //Lap UI update
                if(playerIndex == 1)
                {
                    if (player.lapNumber > 3) { return; }
                    p1LapCounter.text = $"P1: Laps {player.lapNumber}/3";
                }
                else if (playerIndex == 2)
                {
                    if(player.lapNumber > 3) { return; }
                    p2LapCounter.text = $"P2: Laps {player.lapNumber}/3";
                }
                else
                {
                    Debug.LogError("Lap Counting Error");
                }
            }
        }
    }

    public IEnumerator DisableWinnerText()
    {
        yield return new WaitForSeconds(3f);
        winnerText.gameObject.SetActive(false);
        afterGameMenuManager.SetGameMenuActive();
    }
}
