using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private bool isPlayer1;

    [SerializeField] private Text coinsText;

    [SerializeField] private AudioSource deathSoundEffect;

    Vector2 startPos;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            coinsText.text = "0";
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Lava"))
        {
            if(!isPlayer1)
            {
                coinsText.text = "0";
                Die();
            }
        }
        if(collision.gameObject.CompareTag("Water"))
        {
            if(isPlayer1)
            {
                coinsText.text = "0";
                Die();
            }
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        transform.position = startPos;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
