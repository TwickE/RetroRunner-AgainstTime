using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2Life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private ItemCollectorPlayer2 itemCollectorPlayer2;
    [SerializeField] private RollbackPlayer2 rollbackPlayer2;
    [SerializeField] private Text coinsText;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource respawnSoundEffect;

    public Vector2 spawnPosition;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        spawnPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            itemCollectorPlayer2.coinCount = 0;
            coinsText.text = "0";
            rollbackPlayer2.rollbackCount = rollbackPlayer2.rollbackCountValue;
            rollbackPlayer2.rollbackText.text = rollbackPlayer2.rollbackCount.ToString();
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Lava"))
        {
            itemCollectorPlayer2.coinCount = 0;
            coinsText.text = "0";
            rollbackPlayer2.rollbackCount = rollbackPlayer2.rollbackCountValue;
            rollbackPlayer2.rollbackText.text = rollbackPlayer2.rollbackCount.ToString();
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play(); //Plays the death sound effect
        rb.bodyType = RigidbodyType2D.Static; //Stops the player from moving
        anim.SetTrigger("death"); //Triggers the death animation
    }

    private void RestartLevel()
    {
        transform.position = spawnPosition; //Resets the position of the player
        anim.SetTrigger("respawn"); //Triggers the respawn animation
        respawnSoundEffect.Play(); //Plays the respawn sound effect
    }

    private void BlockMovement()
    {
        rb.bodyType = RigidbodyType2D.Static; //Stops the player from moving
    }

    private void UnblockMovement()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; //Allows the player to move again
    }
}
