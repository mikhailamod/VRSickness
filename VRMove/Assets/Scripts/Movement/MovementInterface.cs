using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(PlayerMovement))]
public class MovementInterface : MonoBehaviour
{
    [Header("General Settings")]
    public MovementState state;
    public PlayerMovement playerMovement;

    [Header("Keyboard Settings")]
    public KeyboardSettings keyboardSettings;

    [Header("Controller Settings")]
    public SteamVR_Action_Single walkAction;
    public ControllerSettings controllerSettings;

    [Header("Stepper Settings")]
    public StepperSettings stepperSettings;
    [Header("Tether Settings")]
    public TetherSettings tehterSettings;


    void Start()
    {
        if(!playerMovement)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case MovementState.KEYBOARD:
                ManageKeyboard();
                break;
            case MovementState.CONTROLLER:
                ManageController();
                break;
            case MovementState.STEPPER:
                ManageStepper();
                break;
            case MovementState.TETHER:
                ManageTether();
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
        // @TODO Mikhail
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
    // @TODO Mikhail
}

[System.Serializable]
public class TetherSettings
{
    // @TODO Jethro
}


