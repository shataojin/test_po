using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTankBuild : MonoBehaviour
{
  
    public PushButton[] buttons; // Array of PushButton scripts for each button
    
    public PushButton pushButton;
    public int button_1_trigger_Value;
    public int button_2_trigger_Value;
    public int button_3_trigger_Value;

    private void Start()
    {
        
        pushButton = FindObjectOfType<PushButton>();
    }

    // Check if any cube is currently spawned
    public bool IsCubeSpawned()
    {
        foreach (var button in buttons)
        {
            if (button.spawnedObject != null)
            {
                return true;
            }
        }
        return false;
    }

    // Disable all buttons
    public void DisableAllButtons()
    {
        foreach (var button in buttons)
        {
            button.enabled = false; // Disabling the script disables the button functionality
        }
    }

    // Enable all buttons
    public void EnableAllButtons()
    {
        foreach (var button in buttons)
        {
            button.enabled = true; // Enabling the script enables the button functionality
        }
    }
    //private void Update()
    //{

    //    //dumb way to do it  but it works
    //    if (timerController.EnegryValue >= button_1_trigger_Value)
    //    {
    //        buttons[0].enabled = true;
            
    //    }
    //    else { buttons[0].enabled = false; }
    //    if (timerController.EnegryValue >= button_2_trigger_Value)
    //    {
    //        buttons[1].enabled = true;
    //    }
    //    else { buttons[1].enabled = false; }
    //    if (timerController.EnegryValue >= button_3_trigger_Value)
    //    {
    //        buttons[2].enabled = true;
    //    }
    //    else { buttons[2].enabled = false; }

    //    Debug.Log("button enable : " + buttons);
    //}

}


