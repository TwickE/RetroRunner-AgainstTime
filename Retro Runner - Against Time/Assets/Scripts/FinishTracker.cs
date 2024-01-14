using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTracker : MonoBehaviour
{

    public static FinishTracker Instance; // Singleton instance

    private bool player1Checkpoint = false; // Number of checkpoints Player 1 has collided with
    private bool player2Checkpoint = false; // Number of checkpoints Player 2 has collided with


    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this; // Set the singleton instance
        }
        else
        {
            Destroy(gameObject); // Destroy the duplicate
        }
    }

    public void PlayerGetCheckpoint(int playerIndex)
    {
        if(playerIndex == 1) // If player 1 has finished the level
        {
            player1Checkpoint = true; // Set player 1 checkpoint to true
        }
        else if(playerIndex == 2) // If player 2 has finished the level
        {
            player2Checkpoint = true; // Set player 2 checkpoint to true
        }

        if(player1Checkpoint == true && player2Checkpoint == true) // If both players have finished the level
        {
            player1Checkpoint = false; // Reset player 1 checkpoint
            player2Checkpoint = false; // Reset player 2 checkpoint
            Invoke("CompleteLevel", 2f); // Calls CompleteLevel after 2 seconds
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene("Levels Score"); // Load the Levels Score scene
    }
}
