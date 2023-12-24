using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;

    [SerializeField] GameObject lightEffectPlayer1;
    [SerializeField] GameObject lightEffectPlayer2;

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
            lightEffectPlayer1.SetActive(true);
            anim.SetBool("CheckpointPlayer1", true);
        }
        else if(collision.gameObject.name == "Player2")
        {
            lightEffectPlayer2.SetActive(true);
            anim.SetBool("CheckpointPlayer2", true);
        }
    }
}
