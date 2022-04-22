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

    private void Start()
    {
        mainMenuObj.SetActive(true);
        gameMenuObj.SetActive(false);
        //firstBtnMainMenu.Select();
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
    public void Track1()
    {
        SceneManager.LoadScene(1);
    }

    public void Track2()
    {
        Debug.Log("Load Track 2");
        //SceneManager.LoadScene(2);
    }

    public void Track3()
    {
        Debug.Log("Load Track 3");
        //SceneManager.LoadScene(3);
    }

    public void BackButton()
    {
        mainMenuObj.SetActive(true);
        gameMenuObj.SetActive(false);
        firstBtnMainMenu.Select();
    }
}
