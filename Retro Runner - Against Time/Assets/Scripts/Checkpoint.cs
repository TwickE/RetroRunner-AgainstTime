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

    bool player1Checkpoint = false;
    bool player2Checkpoint = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player1" && isPlayer1 == true)
        {
            if(player1Checkpoint == false)
            {
                player1Checkpoint = true;
                checkpointSoundEffect.Play();
                lightEffectPlayer1.SetActive(true);
                anim.SetBool("CheckpointPlayer1", true);
                player1Life.spawnPosition = transform.position;
            }
            
        }
        else if(collision.gameObject.name == "Player2" && isPlayer1 == false)
        {
            if(player2Checkpoint == false)
            {
                player2Checkpoint = true;
                checkpointSoundEffect.Play();
                lightEffectPlayer2.SetActive(true);
                anim.SetBool("CheckpointPlayer2", true);
                player2Life.spawnPosition = transform.position;
            }
        }
    }
}