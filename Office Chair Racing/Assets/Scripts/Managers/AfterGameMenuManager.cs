using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void SetGameMenuActive()
    {
        menuCanvas.gameObject.SetActive(true);
    }
}
