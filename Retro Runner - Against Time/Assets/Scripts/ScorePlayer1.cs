/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer1 : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private ItemCollectorPlayer1 itemCollectorPlayer1;
    [SerializeField] private Player1Life player1Life;

    [SerializeField] private Text scoreText;

    private int score = 0;
    private int startingScore = 5000;
    private int coinScore = 2500; // Score per coin
    private int deathPenalty = 2000; // Score penalty per death
    private int timePenalty = 100; // Score penalty per second
    private int balancePoints = 0; // Points to be added to the score

    // Start is called before the first frame update
    private void Start()
    {
        score = startingScore;
    }

    private int lastCoinCount = 0; // The coin count from the last frame
    private int lastDeathCount = 0; // The death count from the last frame
    private float lastTime = 0; // The time from the last frame

    private float lastTimePenalty = 0; // The time when the last time penalty was applied

    void FixedUpdate()
    {
        // Calculate the score from new coins collected since the last frame
        int newCoins = itemCollectorPlayer1.coinCount - lastCoinCount;
        int coinScore = newCoins * this.coinScore;

        // Update the last coin count
        lastCoinCount = itemCollectorPlayer1.coinCount;

        // Calculate the score from new deaths since the last frame
        int newDeaths = player1Life.deathCount - lastDeathCount;
        int deathScore = newDeaths * this.deathPenalty;

        // Update the last death count
        lastDeathCount = player1Life.deathCount;

        // Calculate the score from time elapsed since the last frame
        float timeElapsed = timer.currentTime - lastTime;
        int timeScore = (int)timeElapsed * this.timePenalty;

        // Update the last time
        lastTime = timer.currentTime;

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

    private int CalculateScore(int coinCount, float currentTime, int deathCount)
    {
        int newScore = coinCount * this.coinScore - deathCount * this.deathPenalty - (int)currentTime * this.timePenalty;

        return newScore;
    }
} */

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

    private int score = 0;
    private int startingScore = 5000;
    private int coinScore = 2500; // Score per coin
    private int deathPenalty = 2000; // Score penalty per death
    private int timePenalty = 100; // Score penalty per second
    private int balancePoints = 0; // Points to be added to the score

    // Start is called before the first frame update
    private void Start()
    {
        score = startingScore;
    }

    private int lastCoinCount = 0; // The coin count from the last frame
    private int lastDeathCount = 0; // The death count from the last frame
    private float lastTime = 0; // The time from the last frame
    private float lastTimePenalty = 0; // The time when the last time penalty was applied

    void FixedUpdate()
    {
        // Calculate the score from new coins collected since the last frame
        int newCoins = itemCollectorPlayer1.coinCount - lastCoinCount;
        int coinScore = newCoins * this.coinScore;

        // Update the last coin count
        lastCoinCount = itemCollectorPlayer1.coinCount;

        // Calculate the score from new deaths since the last frame
        int newDeaths = player1Life.deathCount - lastDeathCount;
        int deathScore = newDeaths * this.deathPenalty;

        // Update the last death count
        lastDeathCount = player1Life.deathCount;

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

    private int CalculateScore(int coinCount, float currentTime, int deathCount)
    {
        int newScore = coinCount * this.coinScore - deathCount * this.deathPenalty - (int)currentTime * this.timePenalty;

        return newScore;
    }
}