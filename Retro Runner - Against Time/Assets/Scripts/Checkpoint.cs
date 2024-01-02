using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;

    [SerializeField] GameObject lightEffectPlayer1;
    [SerializeField] GameObject lightEffectPlayer2;
    [SerializeField] private AudioSource checkpointSoundEffect;
    [SerializeField] private Player1Life player1Life;
    [SerializeField] private Player2Life player2Life;
    [SerializeField] private bool isPlayer1;
    [SerializeField] private CheckpointControllerPlayer1 checkpointControllerPlayer1;

    [System.NonSerialized] public bool player1Checkpoint = false;
    private bool activationCountPlayer1 = false;
    [System.NonSerialized] public bool player2Checkpoint = false;
    private bool activationCountPlayer2 = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Checkpoint == false && activationCountPlayer1 == true)
        {
            anim.SetBool("CheckpointPlayer1", false); //Set the CheckpointPlayer1 animator parameter to false
            lightEffectPlayer1.SetActive(false); //Deactivate the light effect for player 1
            anim.enabled = false; //Disable the animator
        }
        else if(player2Checkpoint == false && activationCountPlayer2 == true)
        {
            anim.SetBool("CheckpointPlayer2", false); //Set the CheckpointPlayer2 animator parameter to false
            lightEffectPlayer2.SetActive(false); //Deactivate the light effect for player 2
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player1" && isPlayer1 == true && activationCountPlayer1 == false) 
        {
            if(player1Checkpoint == false)
            {
                activationCountPlayer1 = true; //Set activationCountPlayer1 to true
                player1Checkpoint = true; //Set player1Checkpoint to true
                checkpointSoundEffect.Play(); //Play the checkpoint sound effect
                lightEffectPlayer1.SetActive(true); //Activate the light effect for player 1
                anim.SetBool("CheckpointPlayer1", true); //Set the CheckpointPlayer1 animator parameter to true
                player1Life.spawnPosition = transform.position; //Set the spawnPosition of player 1 to the position of the checkpoint
            }
            
        }
        else if(collision.gameObject.name == "Player2" && isPlayer1 == false  && activationCountPlayer2 == false)
        {
            if(player2Checkpoint == false)
            {
                activationCountPlayer2 = true; //Set activationCountPlayer2 to true
                player2Checkpoint = true; //Set player2Checkpoint to true
                checkpointSoundEffect.Play(); //Play the checkpoint sound effect
                lightEffectPlayer2.SetActive(true); //Activate the light effect for player 2
                anim.SetBool("CheckpointPlayer2", true); //Set the CheckpointPlayer2 animator parameter to true
                player2Life.spawnPosition = transform.position; //Set the spawnPosition of player 2 to the position of the checkpoint
            }
        }
    }
}
