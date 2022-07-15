using System.Collections;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    [SerializeField] private int m_BoostTime = 4;
    [SerializeField] private int m_BoostSpeed = 500;

    private PlayerMovement m_Player;
    private PlayerSpawnSetup m_PlayerSpawnSetup;
    private PlayModeCanvasManager m_PlayModeCanvas;

    void Start()
    {
        m_Player = GetComponent<PlayerMovement>();
        m_PlayerSpawnSetup = GetComponent<PlayerSpawnSetup>();
        m_PlayModeCanvas = FindObjectOfType<PlayModeCanvasManager>();
    }

    void Update()
    {
        PlayerBoosting();
    }

    private void PlayerBoosting()
    {
        if (m_Player.isBoosting && m_Player.hasBoost)
        {
            m_PlayModeCanvas.TurnOffBoostUI(m_PlayerSpawnSetup.playerIndex);
            m_Player.hasBoost = false;
            var main = m_Player.smokeParticles.main;
            main.startColor = Color.blue;
            main.simulationSpeed = 2;
            m_Player.moveSpeed = m_BoostSpeed;
            StartCoroutine(TurnOffBoost());
        }
    }

    private IEnumerator TurnOffBoost()
    {
        yield return new WaitForSeconds(m_BoostTime);
        m_Player.isBoosting = false;
        var main = m_Player.smokeParticles.main;
        main.startColor = Color.white;
        main.simulationSpeed = 1;
        m_Player.moveSpeed = 300;
    }
}
