using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //this script is placed on each checkpoint

    //when a game object enters the checkpoint collider, it checks if it is the player
    //it then grabs a reference to the player and checks if the player's checkpointIndex is one less than this checkpoint's index
    //(this ensures that the player is not skipping checkpoints)
    //if the check is successful, the player's checkpointIndex is set to this checkpoint's index
    public int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            if (player.checkpointIndex == index - 1)
            {
                player.checkpointIndex = index;
            }
        }
    }
}
