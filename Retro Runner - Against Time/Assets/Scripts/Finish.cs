using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    [SerializeField] private ScorePlayer1 scorePlayer1;
    [SerializeField] private Text scoreTextPlayer1;
    [SerializeField] private ScorePlayer2 scorePlayer2;
    [SerializeField] private Text scoreTextPlayer2;

    [SerializeField] private bool isPlayer1;
    public bool p1LevelCompleted = false;
    public bool p2LevelCompleted = false;

    [SerializeField] private GameObject invisibleWallPlayer1;
    [SerializeField] private GameObject invisibleWallPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
        PlayerPrefs.SetInt("BonusPoints", 0); //Resets the bonus points tracker
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player1" && !p1LevelCompleted && isPlayer1) // If the player is player 1 and the level is not completed
        {
            finishSound.Play(); // Play the finish sound
            p1LevelCompleted = true; // Set the level to completed
            FinishTracker.Instance.PlayerGetCheckpoint(1); // Tell the FinishTracker that player 1 has completed the level
            invisibleWallPlayer1.SetActive(true); // Activate the invisible wall to prevent the player from moving
            if(PlayerPrefs.GetInt("BonusPoints") == 0) // If a player has not already gotten bonus points
            {
                scorePlayer1.score += 3000; // Add 5000 points to the player's score
                scoreTextPlayer1.text = scorePlayer1.score.ToString(); // Update the score text
                PlayerPrefs.SetInt("Player1Score", scorePlayer1.score); // Update the player's score in PlayerPrefs
                PlayerPrefs.SetInt("BonusPoints", 1); // Set the bonus points tracker to 1 to indicate that a player has gotten bonus points
            }
        }
        if(collision.gameObject.name == "Player2" && !p2LevelCompleted && !isPlayer1) // If the player is player 2 and the level is not completed
        {
            finishSound.Play(); // Play the finish sound
            p2LevelCompleted = true; // Set the level to completed
            FinishTracker.Instance.PlayerGetCheckpoint(2); // Tell the FinishTracker that player 2 has completed the level
            invisibleWallPlayer2.SetActive(true); // Activate the invisible wall to prevent the player from moving
            if(PlayerPrefs.GetInt("BonusPoints") == 0) // If a player has not already gotten bonus points
            {
                scorePlayer2.score += 3000; // Add 5000 points to the player's score
                scoreTextPlayer2.text = scorePlayer2.score.ToString(); // Update the score text
                PlayerPrefs.SetInt("Player2Score", scorePlayer2.score); // Update the player's score in PlayerPrefs
                PlayerPrefs.SetInt("BonusPoints", 1); // Set the bonus points tracker to 1 to indicate that a player has gotten bonus points
            }
        }
    }
}
