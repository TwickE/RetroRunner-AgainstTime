using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer2 : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private ItemCollectorPlayer2 itemCollectorPlayer2;
    [SerializeField] private Player2Life player2Life;
    [SerializeField] private Finish finish;

    [SerializeField] private Text scoreText;

    [System.NonSerialized] public int score = 0;
    private int startingScore = 5000;
    private int coinScore = 1000; // Score per coin
    private int deathPenalty = 3000; // Score penalty per death
    private int timePenalty = 200; // Score penalty per second
    private int balancePoints = 0; // Points to be added to the score

    // Start is called before the first frame update
    private void Start()
    {
        score = startingScore;
    }

    private int lastCoinCount = 0; // The coin count from the last frame
    private int lastDeathCount = 0; // The death count from the last frame
    private float lastTimePenalty = 0; // The time when the last time penalty was applied

    void FixedUpdate()
    {
        if(finish.p2LevelCompleted == false)
        {
            // Calculate the score from new coins collected since the last frame
            int newCoins = itemCollectorPlayer2.coinCount - lastCoinCount;
            int coinScore = newCoins * this.coinScore;

            // Update the last coin count
            lastCoinCount = itemCollectorPlayer2.coinCount;

            // Calculate the score from new deaths since the last frame
            int newDeaths = player2Life.deathCount - lastDeathCount;
            int deathScore = newDeaths * this.deathPenalty;

            // Update the last death count
            lastDeathCount = player2Life.deathCount;

            // Calculate the score from time elapsed since the last time penalty
            int timeScore = 0;
            if (timer.currentTime - lastTimePenalty >= 1)
            {
                timeScore = this.timePenalty;
                lastTimePenalty = timer.currentTime;
            }

            // Calculate the total score
            int calculatedScore = coinScore - deathScore - timeScore;
            if (score + calculatedScore <= 0)
            {
                score = balancePoints;
            }
            else
            {
                score += calculatedScore;
            }
            scoreText.text = score.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Player2Coins", lastCoinCount); // Saves the coin count
            PlayerPrefs.SetInt("Player2Time", (int)lastTimePenalty); // Saves the time
            PlayerPrefs.SetInt("Player2Deaths", lastDeathCount); // Saves the death count
            PlayerPrefs.SetInt("Player2Score", score); // Saves the score
            PlayerPrefs.Save(); // Saves the data
        }
    }

    private int CalculateScore(int coinCount, float currentTime, int deathCount) // Calculates the score
    {
        int newScore = coinCount * this.coinScore - deathCount * this.deathPenalty - (int)currentTime * this.timePenalty;

        return newScore;
    }
}