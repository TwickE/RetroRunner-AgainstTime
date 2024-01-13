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
        if(collision.gameObject.name == "Player1" && !p1LevelCompleted && isPlayer1)
        {
            finishSound.Play();
            p1LevelCompleted = true;
            FinishTracker.Instance.PlayerGetCheckpoint(1);
            invisibleWallPlayer1.SetActive(true);
            if(PlayerPrefs.GetInt("BonusPoints") == 0)
            {
                scorePlayer1.score += 5000;
                scoreTextPlayer1.text = scorePlayer1.score.ToString();
                PlayerPrefs.SetInt("Player1Score", scorePlayer1.score);
                PlayerPrefs.SetInt("BonusPoints", 1);
            }
        }
        if(collision.gameObject.name == "Player2" && !p2LevelCompleted && !isPlayer1)
        {
            finishSound.Play();
            p2LevelCompleted = true;
            FinishTracker.Instance.PlayerGetCheckpoint(2);
            invisibleWallPlayer2.SetActive(true);
            if(PlayerPrefs.GetInt("BonusPoints") == 0)
            {
                scorePlayer2.score += 5000;
                scoreTextPlayer2.text = scorePlayer2.score.ToString();
                PlayerPrefs.SetInt("Player2Score", scorePlayer2.score);
                PlayerPrefs.SetInt("BonusPoints", 1);
            }
        }
    }
}
