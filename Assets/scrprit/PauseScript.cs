using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
   public bool isPaused = false;
    public GameObject pauseMenu;

    // Reference to the UI buttons
    public GameObject resumeButton;
    public GameObject mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        // Initially, hide the buttons
        ToggleButtonsVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // Check for spacebar to toggle button visibility
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleButtonsVisibility(!isPaused);
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // Pause the game
            pauseMenu.SetActive(true); // Show the pause menu or any UI element you want
            ToggleButtonsVisibility(true); // Show the buttons when paused
        }
        else
        {
            Time.timeScale = 1; // Resume the game
            pauseMenu.SetActive(false); // Hide the pause menu or UI element
            ToggleButtonsVisibility(false); // Hide the buttons when unpaused
        }
    }

    void ToggleButtonsVisibility(bool isVisible)
    {
        resumeButton.SetActive(isVisible);
        mainMenuButton.SetActive(isVisible);
    }

    // Function to resume the game
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Resume the game
        pauseMenu.SetActive(false); // Hide the pause menu or UI element
        ToggleButtonsVisibility(false); // Hide the buttons
    }

    // Function to return to the main menu
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1; // Resume the game in case it was paused
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the name of your main menu scene
    }
}
