using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AfterGameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject m_MenuCanvas;
    [SerializeField] private Button m_FirstBtnGameMenu;

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
        m_MenuCanvas.gameObject.SetActive(true);
        m_FirstBtnGameMenu.Select();
    }
}
