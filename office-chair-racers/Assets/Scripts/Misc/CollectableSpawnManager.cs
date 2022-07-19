using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_SpawnPoints;
    [SerializeField] private GameObject m_PowerUp;
    [SerializeField] private GameObject m_PowerupContainer;

    void Start()
    {
        for(int i = 0; i < m_SpawnPoints.Length; i++)
        {
            var newPowerUp = Instantiate(m_PowerUp, m_SpawnPoints[i].transform.position, m_SpawnPoints[i].transform.rotation);
            newPowerUp.transform.parent = m_PowerupContainer.transform;
        }
    }

    public void SpawnPowerup(GameObject spawnPos)
    {
        var newPowerUp = Instantiate(m_PowerUp, spawnPos.transform.position, spawnPos.transform.rotation);
        newPowerUp.transform.parent = m_PowerupContainer.transform;
    }
}
