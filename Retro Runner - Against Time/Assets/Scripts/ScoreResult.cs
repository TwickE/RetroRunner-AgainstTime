using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ScoreResult : MonoBehaviour
{
    [SerializeField] private Text firstCoinsText;
    [SerializeField] private Text firstDeathsText;
    [SerializeField] private Text firstTimeText;
    [SerializeField] private Text firstScoreText;
    [SerializeField] private Image firstImage;
    [SerializeField] private Text secondCoinsText;
    [SerializeField] private Text secondDeathsText;
    [SerializeField] private Text secondTimeText;
    [SerializeField] private Text secondScoreText;
    [SerializeField] private Image secondImage;
    [SerializeField] private Sprite Player1Image;
    [SerializeField] private Sprite Player2Image;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Player1Score") > PlayerPrefs.GetInt("Player2Score"))
        {
            //Fills in the Player 1 data
            firstCoinsText.text = PlayerPrefs.GetInt("Player1Coins").ToString();
            firstDeathsText.text = PlayerPrefs.GetInt("Player1Deaths").ToString();
            int player1Time = PlayerPrefs.GetInt("Player1Time");
            TimeSpan timeSpan1 = TimeSpan.FromSeconds(player1Time);
            string timeText1 = string.Format("{0:D2}:{1:D2}", timeSpan1.Minutes, timeSpan1.Seconds);
            firstTimeText.text = timeText1;
            firstScoreText.text = PlayerPrefs.GetInt("Player1Score").ToString();
            firstImage.sprite = Player1Image;

            //Fills in the Player 2 data
            secondCoinsText.text = PlayerPrefs.GetInt("Player2Coins").ToString();
            secondDeathsText.text = PlayerPrefs.GetInt("Player2Deaths").ToString();
            int player2Time = PlayerPrefs.GetInt("Player2Time");
            TimeSpan timeSpan2 = TimeSpan.FromSeconds(player2Time);
            string timeText2 = string.Format("{0:D2}:{1:D2}", timeSpan2.Minutes, timeSpan2.Seconds);
            secondTimeText.text = timeText2;
            secondScoreText.text = PlayerPrefs.GetInt("Player2Score").ToString();
            secondImage.sprite = Player2Image;
        }
        else
        {
            //Fills in the Player 2 data
            firstCoinsText.text = PlayerPrefs.GetInt("Player2Coins").ToString();
            firstDeathsText.text = PlayerPrefs.GetInt("Player2Deaths").ToString();
            int player2Time = PlayerPrefs.GetInt("Player2Time");
            TimeSpan timeSpan2 = TimeSpan.FromSeconds(player2Time);
            string timeText2 = string.Format("{0:D2}:{1:D2}", timeSpan2.Minutes, timeSpan2.Seconds);
            firstTimeText.text = timeText2;
            firstScoreText.text = PlayerPrefs.GetInt("Player2Score").ToString();
            firstImage.sprite = Player2Image;

            //Fills in the Player 1 data
            secondCoinsText.text = PlayerPrefs.GetInt("Player1Coins").ToString();
            secondDeathsText.text = PlayerPrefs.GetInt("Player1Deaths").ToString();
            int player1Time = PlayerPrefs.GetInt("Player1Time");
            TimeSpan timeSpan1 = TimeSpan.FromSeconds(player1Time);
            string timeText1 = string.Format("{0:D2}:{1:D2}", timeSpan1.Minutes, timeSpan1.Seconds);
            secondTimeText.text = timeText1;
            secondScoreText.text = PlayerPrefs.GetInt("Player1Score").ToString();
            secondImage.sprite = Player1Image;
        }
    }
}
