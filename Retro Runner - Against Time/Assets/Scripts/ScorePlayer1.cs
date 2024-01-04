using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer1 : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private ItemCollectorPlayer1 itemCollectorPlayer1;
    [SerializeField] private Player1Life player1Life;

    [SerializeField] private Text scoreText;

    void FixedUpdate()
    {
        scoreText.text = CalculateScore(itemCollectorPlayer1.coinCount, timer.currentTime, player1Life.deathCount).ToString(); //Updates the score text
    }

    private int CalculateScore(int coins, float time, int deaths)
    {
        // Adjust these weights based on your game's design
        int coinWeight = 1250;   // To get scores in the thousands
        float timeWeight = 0.3f; // Adjust this weight to control the influence of time on the score
        int deathWeight = -500;   // To make it less likely to get a score of 0

        // Calculate the score based on the given weights
        int score = (int)((coins * coinWeight) - (time * timeWeight) + (deaths * deathWeight));

        // Add a starting score
        int startingScore = 5000;

        return Mathf.Max(1, score + startingScore); // Ensure the score is at least 1
    }

}
