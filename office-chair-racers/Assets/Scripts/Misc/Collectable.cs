using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 0.5f;
    [SerializeField] private bool canPickup;

    private Vector3 rotation;

    void Start()
    {
        rotation = new Vector3(0, 90, 0);
        transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        ObjectRotate();
        GrowOnSpawn();
    }

    private void ObjectRotate()
    {
        transform.Rotate(rotation.x, rotation.y * rotSpeed * Time.deltaTime, rotation.z);
    }

    private void GrowOnSpawn()
    {
        if (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f) * Time.deltaTime;
            canPickup = false;
        }
        else
        {
            canPickup = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            && canPickup
            && !other.gameObject.GetComponent<PlayerMovement>().isBoosting
            && !other.gameObject.GetComponent<PlayerMovement>().hasBoost)
        {
            Destroy(gameObject);
            var spawnManager = FindObjectOfType<CollectableSpawnManager>();
            spawnManager.SpawnPowerup(gameObject);
            other.gameObject.GetComponent<PlayerMovement>().hasBoost = true;

            int playerIndex = other.gameObject.GetComponent<PlayerSpawnSetup>().playerIndex;
            PlayModeCanvasManager playerModeCanvas = FindObjectOfType<PlayModeCanvasManager>();
            playerModeCanvas.UpdateBoostUI(playerIndex);
        }
    }
}
