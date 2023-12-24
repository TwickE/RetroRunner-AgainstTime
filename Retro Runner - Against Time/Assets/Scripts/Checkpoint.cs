using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;

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
        if(collision.gameObject.name == "Player1")
        {
            anim.SetBool("CheckpointPlayer1", true);
            Debug.Log("Player 1 checkpoint collision detected");
        }
        else if(collision.gameObject.name == "Player2")
        {
            anim.SetBool("CheckpointPlayer2", true);
            Debug.Log("Player 2 checkpoint collision detected");
        }
    }
}
