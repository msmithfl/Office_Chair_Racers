using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject powerupContainer;

    void Start()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            var newPowerUp = Instantiate(powerUp, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            newPowerUp.transform.parent = powerupContainer.transform;
        }
    }

    public void SpawnPowerup(GameObject spawnPos)
    {
        var newPowerUp = Instantiate(powerUp, spawnPos.transform.position, spawnPos.transform.rotation);
        newPowerUp.transform.parent = powerupContainer.transform;
    }
}
