using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplayerSpawn : MonoBehaviour
{
    public GameObject spawnPointP1;
    public GameObject spawnPointP2;
    public int playerCount = 0;

    [SerializeField] private float numberCountdownTime = 1f;

    [SerializeField] private GameObject waitForPlayersText;
    [SerializeField] private GameObject raceCountdownText;

    private PlayerMovement[] players;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        if (gameManager == null)
        {
            return;
        }
        else
        {
        //checking if multiplayer mode is active
            if(gameManager.twoPlayerMode == false)
            {
                gameObject.SetActive(false);
            }
        }


        waitForPlayersText.SetActive(true);
        raceCountdownText.SetActive(false);
    }
    public void OnPlayerJoined()
    {
        //code for first player joined
        if (playerCount == 0)
        {
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.transform.position = spawnPointP1.transform.position;
            player.transform.rotation = spawnPointP1.transform.rotation;
            player.playerIndex = 1;
            playerCount++;
            
        }
        //code for second
        else if (playerCount == 1)
        {
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.transform.position = spawnPointP2.transform.position;
            player.transform.rotation = spawnPointP2.transform.rotation;
            player.playerIndex = 2;
            playerCount++;
            waitForPlayersText.SetActive(false);
            StartCoroutine(StartRaceCountdown());
        }
    }

    IEnumerator StartRaceCountdown()
    {
        raceCountdownText.SetActive(true);
        yield return new WaitForSeconds(numberCountdownTime);
        raceCountdownText.GetComponent<TextMeshProUGUI>().text = "3";
        yield return new WaitForSeconds(numberCountdownTime);
        raceCountdownText.GetComponent<TextMeshProUGUI>().text = "2";
        yield return new WaitForSeconds(numberCountdownTime);
        raceCountdownText.GetComponent<TextMeshProUGUI>().text = "1";
        yield return new WaitForSeconds(numberCountdownTime);
        raceCountdownText.GetComponent<TextMeshProUGUI>().text = "Go!";
        UnlockControls();
        yield return new WaitForSeconds(1f);
        raceCountdownText.SetActive(false);
    }

    public void UnlockControls()
    {
        players = FindObjectsOfType<PlayerMovement>();
        foreach (var player in players)
        {
            player.isWaitingForPlayers = false;
        }
    }
}
