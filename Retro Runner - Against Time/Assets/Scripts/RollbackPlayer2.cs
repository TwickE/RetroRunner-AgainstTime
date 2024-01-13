using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollbackPlayer2 : MonoBehaviour
{
    [SerializeField] private Player2Life player2Life;
    [SerializeField] public Text rollbackText;
    [SerializeField] private AudioSource respawnSoundEffect;
    [SerializeField] public int rollbackCountValue;

    [System.NonSerialized]public int rollbackCount;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        rollbackCount = rollbackCountValue;
        rollbackText.text = rollbackCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            rollbackCount--; //Removes 1 to the rollbackCount
            rollbackText.text = rollbackCount.ToString(); //Updates the text
            if(rollbackCount == 0)
            {
                respawnSoundEffect.Play();
                transform.position = player2Life.spawnPosition; //Rollsback the player
                rollbackCount = rollbackCountValue; //Resets the rollbackCount
                rollbackText.text = rollbackCount.ToString(); //Updates the text
                anim.SetTrigger("respawn"); //Triggers the respawn animation
            }
        }
    }
}
