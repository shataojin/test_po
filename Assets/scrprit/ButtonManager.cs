using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public bool InstructionOn = false;
    public GameObject playButton;
    public GameObject InstructionsButton;
    public GameObject QuitButton;
    public GameObject InstructionWords;
    public GameObject BackButton;
    public void Play()
    {
        SceneManager.LoadScene("WORKING PARTSNow");
    }

    public void Instruction()
    {
        // Load the "Instruction" scene
        SceneManager.LoadScene("Instruction");

        // Set InstructionOn to true
        InstructionOn = true;

        // Hide and show things
        MainMenuVisibility(false);
        InstructionVisibility(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");

        // Hide and show things
        MainMenuVisibility(true);
        InstructionVisibility(false);
    }

    public void End()
    {
        SceneManager.LoadScene("EndSence");
    }

    void Update()
    {
        if (InstructionOn)
        {
            Debug.Log("InstructionOn is true");
        }
        if (!InstructionOn)
        {
            Debug.Log("InstructionOn is false");
        }
    }

    void MainMenuVisibility(bool isVisible)
    {
        playButton.SetActive(isVisible); 
        InstructionsButton.SetActive(isVisible); 
        QuitButton.SetActive(isVisible); 
    }
    void InstructionVisibility(bool isVisible)
    {
        InstructionWords.SetActive(isVisible); 
        BackButton.SetActive(isVisible); 
    }
}
