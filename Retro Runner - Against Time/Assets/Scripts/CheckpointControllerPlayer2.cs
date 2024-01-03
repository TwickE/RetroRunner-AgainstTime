using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControllerPlayer2 : MonoBehaviour
{
    [SerializeField] private GameObject[] checkpoints; //Array of checkpoints

    public int currentCheckpointIndex = 0; //Index of the current checkpoint

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject checkpoint in checkpoints) //For each checkpoint in the checkpoints array
        {
            if(checkpoint.GetComponent<Checkpoint>().player2Checkpoint == true) //If the player2Checkpoint variable of the checkpoint is true
            {
                currentCheckpointIndex = System.Array.IndexOf(checkpoints, checkpoint); //Set the currentCheckpointIndex to the index of the checkpoint
            }
        }
        for(int i = 0; i < currentCheckpointIndex; i++) //For each checkpoint in the checkpoints array
        {
            if(checkpoints[i].GetComponent<Checkpoint>().player2Checkpoint == true && currentCheckpointIndex != 0) //If the player2Checkpoint variable of the checkpoint is true
            {
                checkpoints[i].GetComponent<Checkpoint>().player2Checkpoint = false; //Set the player2Checkpoint variable of the checkpoint to false
            }
        }
    }
}
