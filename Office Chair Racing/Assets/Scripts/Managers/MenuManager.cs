using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager: MonoBehaviour
{
    [SerializeField] private GameObject mainMenuObj;
    [SerializeField] private GameObject gameMenuObj;

    [SerializeField] private Button firstBtnMainMenu;
    [SerializeField] private Button firstBtnGameMenu;

    private GameManager gameManager;

    private void Start()
    {
        mainMenuObj.SetActive(true);
        gameMenuObj.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
    }

    //main menu buttons
    public void PlayButton()
    {
        mainMenuObj.SetActive(false);
        gameMenuObj.SetActive(true);
        firstBtnGameMenu.Select();
    }

    public void QuitButton()
    {
        //Application.Quit();
        print("Quitting");
    }

    //game menu buttons
    public void SoloButton()
    {
        gameManager.soloMode = true;
        gameManager.twoPlayerMode = false;
        SceneManager.LoadScene(1);
    }

    public void TwoPlayerButton()
    {
        gameManager.twoPlayerMode = true;
        SceneManager.LoadScene(1);
    }

    public void TimeTrialButton()
    {
        gameManager.timeTrialMode = true;
        SceneManager.LoadScene(1);
    }

    public void BackButton()
    {
        mainMenuObj.SetActive(true);
        gameMenuObj.SetActive(false);
        firstBtnMainMenu.Select();
    }
}
