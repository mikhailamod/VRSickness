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
        if(Input.GetKeyDown(KeyCode.M))
        {
            movementInterface.stepperSettings.scalingFactor += 1;
            scaleText.text = "Scaling Factor: " + movementInterface.stepperSettings.scalingFactor;
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            movementInterface.stepperSettings.scalingFactor -= 1;
            scaleText.text = "Scaling Factor: " + movementInterface.stepperSettings.scalingFactor;
        }
        speedText.text = "Speed Factor: " + movementInterface.stepperSettings.speed;
    }
}
