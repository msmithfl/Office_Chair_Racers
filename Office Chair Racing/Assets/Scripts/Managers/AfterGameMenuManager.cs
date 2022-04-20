using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGameMenuManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject menuCanvas;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetGameManager();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        ResetGameManager();
    }

    private void ResetGameManager()
    {
        gameManager.GetComponent<MultiplayerSpawn>().playerCount = 0;
        gameManager.GetComponent<MultiplayerSpawn>().waitForPlayersBool = true;
    }

    public void SetGameMenuActive()
    {
        menuCanvas.gameObject.SetActive(true);
    }
}
