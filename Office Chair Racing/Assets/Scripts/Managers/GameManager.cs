using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    //script is now only used by other scipts for location purposes
    private void Awake()
    {
        //if (gameManager == null)
        //{
        //    gameManager = this;
        //    DontDestroyOnLoad(this);
        //}
        //else if (gameManager != null)
        //{
        //    Destroy(gameObject);
        //}
    }
}
