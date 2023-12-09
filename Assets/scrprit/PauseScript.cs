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

    public GameObject CDBar;
    private EnegryBar cooldownBarScript; 

    // Start is called before the first frame update
    void Start()
    {
        // Initially, hide the buttons
        ToggleButtonsVisibility(false);
        cooldownBarScript = CDBar.GetComponent<EnegryBar>();
        CDBar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }

    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // Pause the game
            pauseMenu.SetActive(true); // Show the pause menu or any UI element you want
            ToggleButtonsVisibility(true); // Show only the resume button when paused
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
        resumeButton.SetActive(isPaused && isVisible); // Show the resume button only when paused
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
