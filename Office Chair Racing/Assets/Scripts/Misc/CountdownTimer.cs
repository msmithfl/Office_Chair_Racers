using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private GameObject raceCountdownTextObj;

    [SerializeField] private int countdownTime;

    [SerializeField] private float countdownSpeed = 3f;

    private PlayerSpawnSetup[] players;


    private void Start()
    {
        if (raceCountdownTextObj == null)
        {
            return;
        }
        raceCountdownTextObj.SetActive(false);
    }

    public IEnumerator StartRaceCountdown()
    {

        //Ready!
        raceCountdownTextObj.SetActive(true);
        yield return new WaitForSeconds(countdownSpeed);

        //3, 2, 1
        while (countdownTime > 0)
        {
            raceCountdownTextObj.GetComponent<TextMeshProUGUI>().text = countdownTime.ToString();
            yield return new WaitForSeconds(countdownSpeed);
            countdownTime--;
        }

        //Go!
        UnlockControls();
        raceCountdownTextObj.GetComponent<TextMeshProUGUI>().text = "Go!";
        yield return new WaitForSeconds(countdownSpeed);
        raceCountdownTextObj.SetActive(false);
    }

    public void UnlockControls()
    {
        players = FindObjectsOfType<PlayerSpawnSetup>();
        foreach (var player in players)
        {
            player.isWaitingForPlayers = false;
        }
    }
}
