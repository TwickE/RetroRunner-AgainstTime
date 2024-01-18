using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoardButtons : MonoBehaviour
{
    private int previousLevelIndex;

    [SerializeField] private Text nextLevelButtonText;

    // Start is called before the first frame update
    void Start()
    {
        previousLevelIndex = PlayerPrefs.GetInt("PreviousLevelIndex"); // Get the previous level index
        if(previousLevelIndex == 3)
        {
            nextLevelButtonText.text = "End Screen"; // Change the text of the next level button to "End Screen" if the previous level was the last level
        }
    }
    public void NextLevel() //Load the next level
    {
        SceneManager.LoadScene(previousLevelIndex + 1);
    }
    public void ReplayLevel() //Replays the level
    {
        SceneManager.LoadScene(previousLevelIndex);
    }
}
