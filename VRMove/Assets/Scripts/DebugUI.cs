using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DebugUI : MonoBehaviour
{

    public MovementInterface movementInterface;
    public TextMeshProUGUI scaleText;
    public TextMeshProUGUI speedText;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyBindings.INCREASE_SCALE))
        {
            movementInterface.stepperSettings.dragScale += 0.5f;
        }
        if(Input.GetKeyDown(KeyBindings.DECREASE_SCALE))
        {
            movementInterface.stepperSettings.dragScale -= 0.5f;
        }
        if (Input.GetKeyDown(KeyBindings.STEPPER_THRESHOLD_INCREASE))
        {
            movementInterface.stepperSettings.threshold += 0.1f;
        }
        if (Input.GetKeyDown(KeyBindings.STEPPER_THRESHOLD_DECREASE))
        {
            movementInterface.stepperSettings.threshold -= 0.1f;
        }
        speedText.text = "Speed Factor: " + movementInterface.stepperSettings.speed;
        scaleText.text = "Scaling Factor: " + movementInterface.stepperSettings.dragScale +
                         "\nCurrent Device: " + movementInterface.currentDevice +
                         "\nThreshold: " + movementInterface.stepperSettings.threshold;
    }
}
