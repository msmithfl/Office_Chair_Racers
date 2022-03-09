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
        SceneManager.LoadScene(1);
        gameManager.soloMode = true;
    }

    public void TwoPlayerButton()
    {
        SceneManager.LoadScene(1);
        gameManager.twoPlayerMode = true;
    }

    public void TimeTrialButton()
    {
        SceneManager.LoadScene(1);
        gameManager.timeTrialMode = true;
    }

    public void BackButton()
    {
        mainMenuObj.SetActive(true);
        gameMenuObj.SetActive(false);
        firstBtnMainMenu.Select();
    }
}
