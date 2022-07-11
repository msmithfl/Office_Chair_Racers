using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    [SerializeField] private int boostTime = 4;
    [SerializeField] private int boostSpeed = 500;

    private PlayerMovement player;
    private PlayerSpawnSetup playerSpawnSetup;
    private PlayModeCanvasManager playModeCanvas;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        playerSpawnSetup = GetComponent<PlayerSpawnSetup>();
        playModeCanvas = FindObjectOfType<PlayModeCanvasManager>();
    }

    void Update()
    {
        PlayerBoosting();
    }

    private void PlayerBoosting()
    {
        if (player.isBoosting && player.hasBoost)
        {
            playModeCanvas.TurnOffBoostUI(playerSpawnSetup.playerIndex);
            player.hasBoost = false;
            var main = player.smokeParticles.main;
            main.startColor = Color.blue;
            main.simulationSpeed = 2;
            player.moveSpeed = boostSpeed;
            StartCoroutine(TurnOffBoost());
        }
    }

    private IEnumerator TurnOffBoost()
    {
        yield return new WaitForSeconds(boostTime);
        player.isBoosting = false;
        var main = player.smokeParticles.main;
        main.startColor = Color.white;
        main.simulationSpeed = 1;
        player.moveSpeed = 300;
    }
}
