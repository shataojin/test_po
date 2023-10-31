using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTankBuild : MonoBehaviour
{

    public PushButton[] buttons; // Array of PushButton scripts for each button

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

}


