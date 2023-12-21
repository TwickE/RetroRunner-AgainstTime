using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1Life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private ItemCollectorPlayer1 itemCollectorPlayer1;
    [SerializeField] private Text coinsText;

    [SerializeField] private AudioSource deathSoundEffect;

    Vector2 startPosition;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            itemCollectorPlayer1.coinCount = 0;
            coinsText.text = "0";
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Water"))
        {
            itemCollectorPlayer1.coinCount = 0;
            coinsText.text = "0";
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play(); //Plays the death sound effect
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        transform.position = startPosition; //Resets the position of the player
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
