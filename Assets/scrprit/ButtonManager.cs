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
    public GameObject Playagain;
    public GameObject returntomenu;
    public GameObject continues;
    public GameObject Returntomainmenu;
    
    public void Play()
    {
        SceneManager.LoadScene("WORKING PARTSNow");
       
    }

    public void Instruction()
    {
       

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
       

        // Hide and show things
        MainMenuVisibility(true);
        InstructionVisibility(false);
    }

    public void End()
    {
        SceneManager.LoadScene("EndSence");
    }

    public void loseplayagain()
    {
        SceneManager.LoadScene("WORKING PARTSNow");
    }

    public void loseReturntomenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
    public void winContinues()
    {
        SceneManager.LoadScene("WORKING PARTSNow");
    }
    public void winReturntomainmenus()
    {
        SceneManager.LoadScene("MainMenu");
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
