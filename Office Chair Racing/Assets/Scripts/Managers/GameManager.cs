using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public bool soloMode;
    public bool twoPlayerMode;
    public bool timeTrialMode;
    public int testNum = 0;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this);
        }
        else if (gameManager != null)
        {
            Destroy(gameObject);
        }
    }
}
