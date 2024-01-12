using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardButtons : MonoBehaviour
{
    private int previousLevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        previousLevelIndex = PlayerPrefs.GetInt("PreviousLevelIndex"); // Get the previous level index
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
