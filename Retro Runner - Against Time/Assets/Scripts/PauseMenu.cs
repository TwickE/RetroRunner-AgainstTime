using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private bool isMuted = false;

    [SerializeField] private Button targetButton;
    private Image buttonImage;
    [SerializeField] private Sprite image1;
    [SerializeField] private Sprite image2;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = targetButton.image; // Get the Image component of the button

        if(AudioListener.volume == 1) // If the volume is not muted
        {
            isMuted = false; // Set isMuted to false
            buttonImage.sprite = image1; // Set the button image to image1
        }
        else 
        {
            isMuted = true; // Set isMuted to true
            buttonImage.sprite = image2; // Set the button image to image2
        }
    }

    public void Pause() // Pause the game
    {
        pauseMenu.SetActive(true); // Set the pause menu to active
        Time.timeScale = 0f; // Set the time scale to 0
    }

    public void Resume() // Resume the game
    {
        pauseMenu.SetActive(false); // Set the pause menu to inactive
        Time.timeScale = 1f; // Set the time scale to 1
    }

    public void Replay() // Replay the level
    {
        Time.timeScale = 1f; // Set the time scale to 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void ToggleSound() // Toggle the sound on and off
    {
        isMuted = !isMuted; // Toggle isMuted

        if(isMuted) // If the volume is muted
        {
            AudioListener.volume = 0; // Set the volume to 0
            buttonImage.sprite = image2; // Set the button image to image2
        }
        else
        {
            AudioListener.volume = 1; // Set the volume to 1
            buttonImage.sprite = image1; // Set the button image to image1
        }
    }

    public void Playlevel1() // Play the level 1
    {
        Time.timeScale = 1f; // Set the time scale to 1
        SceneManager.LoadScene("Level 1"); // Load the level 1
    }

    public void Playlevel2() // Play the level 2
    {
        Time.timeScale = 1f; // Set the time scale to 2
        SceneManager.LoadScene("Level 2"); // Load the level 2
    }

    public void Playlevel3() // Play the level 3
    {
        Time.timeScale = 1f; // Set the time scale to 3
        SceneManager.LoadScene("Level 3"); // Load the level 3
    }
}
