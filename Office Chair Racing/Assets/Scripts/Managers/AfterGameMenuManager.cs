using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AfterGameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private Button firstBtnGameMenu;

    public void PlayAgain()
    {
        //StartCoroutine(HoldForControllerInput(SceneManager.GetActiveScene().buildIndex));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        //StartCoroutine(HoldForControllerInput(0));
    }

    private IEnumerator HoldForControllerInput(int buildIndex)
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(buildIndex);
    }

    public void SetGameMenuActive()
    {
        menuCanvas.gameObject.SetActive(true);
        firstBtnGameMenu.Select();
    }
}
