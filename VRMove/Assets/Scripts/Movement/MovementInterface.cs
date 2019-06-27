using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

[RequireComponent(typeof(PlayerMovement))]
public class MovementInterface : MonoBehaviour
{
    [Header("General Settings")]
    public MovementState state;
    public PlayerMovement playerMovement;
    public TextMeshProUGUI interactText;

    [Header("Keyboard Settings")]
    public KeyboardSettings keyboardSettings;

    [Header("Controller Settings")]
    public SteamVR_Action_Single walkAction;
    public ControllerSettings controllerSettings;

    [Header("Stepper Settings")]
    public StepperSettings stepperSettings;
    public Transform tracker;
    float prev_y;

    [Header("Tether Settings")]
    public TetherSettings tehterSettings;


    void Start()
    {
        if(!playerMovement)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        prev_y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case MovementState.KEYBOARD:
                ManageKeyboard();
                ChangeText("Press E");
                break;
            case MovementState.CONTROLLER:
                ManageController();
                ChangeText("Press X");
                break;
            case MovementState.STEPPER:
                ManageStepper();
                ChangeText("Press touchpad");
                break;
            case MovementState.TETHER:
                ChangeText("Press touchpad");
                break;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Controller now");
            state = MovementState.CONTROLLER;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Keyboard now");
            state = MovementState.KEYBOARD;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Tether now");
            state = MovementState.TETHER;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Stepper now");
            state = MovementState.STEPPER;
        }
    }

    void ChangeText(string text)
    {
        interactText.text = text + " to interact";
    }

    void ManageKeyboard()
    {
        if(Input.GetKey(keyboardSettings.movementKey))
        {
            playerMovement.Move(keyboardSettings.speed * Time.deltaTime);
        }
    }

    void ManageController()
    {
        
        if(walkAction.GetAxis(SteamVR_Input_Sources.Any) != 0)
        {
            Debug.Log("Triggered!");
            float amount = walkAction.GetAxis(SteamVR_Input_Sources.Any) * controllerSettings.speed;
            playerMovement.Move(amount * Time.deltaTime);
        }
    }

    void ManageStepper()
    {
        float current_y = tracker.position.y;
        float amount = stepperSettings.speed * Mathf.Abs(current_y - prev_y);
        prev_y = current_y;
        playerMovement.Move(amount * Time.deltaTime);        

    }

    void ManageTether()
    {
        // @TODO Jethro
    }

}

/// <summary>
/// Movement Enum
/// </summary>
public enum MovementState
{
    KEYBOARD,
    CONTROLLER,
    STEPPER,
    TETHER
}

/// <summary>
/// Keyboard Settings
/// </summary>
[System.Serializable]
public class KeyboardSettings
{
    public KeyCode movementKey;
    public float speed;
}

[System.Serializable]
public class ControllerSettings
{
    public float speed = 5f;
}

[System.Serializable]
public class StepperSettings
{
    public float speed;
}

[System.Serializable]
public class TetherSettings
{
    // @TODO Jethro
}


