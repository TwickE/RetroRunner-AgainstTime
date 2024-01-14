using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1Life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private RollbackPlayer1 rollbackPlayer1;
    [SerializeField] private Text coinsText;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource respawnSoundEffect;

    public Vector2 spawnPosition;

    public int deathCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        spawnPosition = transform.position; //Sets the spawn position to the player's current position
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap")) // If the player collides with a trap
        {
            rollbackPlayer1.rollbackCount = rollbackPlayer1.rollbackCountValue; //Resets the rollback count
            rollbackPlayer1.rollbackText.text = rollbackPlayer1.rollbackCount.ToString(); //Updates the rollback text
            Die(); //Calls the Die function
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Water")) // If the player collides with water
        {
            rollbackPlayer1.rollbackCount = rollbackPlayer1.rollbackCountValue; //Resets the rollback count
            rollbackPlayer1.rollbackText.text = rollbackPlayer1.rollbackCount.ToString(); //Updates the rollback text
            Die(); //Calls the Die function
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
        deathCount++; //Increments the death count
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
