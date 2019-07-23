﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;
using Unity.Labs.SuperScience;

//temp edit
[RequireComponent(typeof(PlayerMovement))]
public class MovementInterface : MonoBehaviour
{
    [Header("General Settings")]
    public MovementState state;
    public PlayerMovement playerMovement;
    public DebugUI debugUI;
    public string walkType = "walk";
    public float soundThreshold;

    [Header("Keyboard Settings")]
    public KeyboardSettings keyboardSettings;

    [Header("Controller Settings")]
    public SteamVR_Action_Single walkAction;
    public ControllerSettings controllerSettings;

    [Header("Stepper Settings")]
    public StepperSettings stepperSettings;
    public Transform tracker;
    public SteamVR_TrackedObject trackerObject;
    public int currentDevice = 0;
    bool hasStarted = false;
    PhysicsTracker physicsTracker = new PhysicsTracker();//use tracker as param

    [Header("Tether Settings")]
    public TetherSettings tetherSettings;

    public void EnterTag(Collider other)
    {
        if (other.gameObject.CompareTag("Thresh1"))
        {
            tetherSettings.move = true;
            Debug.Log("Collide = True");
        }

    }

    public void ExitTag(Collider other)
    {
        if (other.gameObject.CompareTag("Thresh1"))
        {
            if (tetherSettings.HMD.transform.position.z < other.transform.position.z)
            {
                tetherSettings.move = false;
                Debug.Log("Collide = False");
            }
        }
    }

    void Start()
    {
        if(!playerMovement)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        currentDevice = (int)trackerObject.index;
        debugUI.UpdateHasStartedText("false");
        debugUI.UpdateControllerType(GetState());
        debugUI.UpdateTrackerDevice(currentDevice);
    }

    public string GetState()
    {
        switch (state)
        {
            case MovementState.KEYBOARD:
                return "keyboard";
            case MovementState.CONTROLLER:
                return "controller";
            case MovementState.STEPPER:
                return "stepper";
            case MovementState.TETHER:
                return "tether";
            default:
                return "keyboard";
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

        if(Input.GetKeyDown(KeyBindings.CHANGE_TO_CONTROLLER))
        {
            state = MovementState.CONTROLLER;
            debugUI.UpdateControllerType(GetState());
        }
        if (Input.GetKeyDown(KeyBindings.CHANGE_TO_STEPPER))
        {
            state = MovementState.STEPPER;
            debugUI.UpdateControllerType(GetState());
        }
        if (Input.GetKeyDown(KeyBindings.CHANGE_TO_TETHER))
        {
            state = MovementState.TETHER;
            debugUI.UpdateControllerType(GetState());
        }

        if (Input.GetKeyDown(KeyBindings.INCREASE_TRACKED_OBJECT))
        {
            currentDevice++;
            trackerObject.SetDeviceIndex(currentDevice);
            debugUI.UpdateTrackerDevice(currentDevice);
        }
        if (Input.GetKeyDown(KeyBindings.DECREASE_TRACKED_OBJECT))
        {
            currentDevice--;
            trackerObject.SetDeviceIndex(currentDevice);
            debugUI.UpdateTrackerDevice(currentDevice);
        }

        if(!hasStarted)
        {
            if (Input.GetKeyDown(KeyBindings.START_STEPPER) ||
               (SteamVR_Actions._default.Interact.GetStateDown(SteamVR_Input_Sources.Any)))
            {
                hasStarted = true;
                debugUI.UpdateHasStartedText("true");
            }
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
        string info = "";
        if(walkAction.GetAxis(SteamVR_Input_Sources.Any) != 0)
        {
            float amount = walkAction.GetAxis(SteamVR_Input_Sources.Any) * controllerSettings.speed;
            info += "walkAmount: " + amount;
            playerMovement.Move(amount * Time.deltaTime);
            if (SoundManager.Instance != null && !SoundManager.Instance.IsPlaying(walkType))
            {
                if (walkAction.GetAxis(SteamVR_Input_Sources.Any) > soundThreshold)
                {
                    SoundManager.Instance.PlaySound(walkType);
                }
            }
        }
        debugUI.UpdateInfoBox(info);
    }

    void ManageStepper()
    {
        if(hasStarted)
        {
            string info = "";
            physicsTracker.Update(tracker.position, tracker.rotation, Time.smoothDeltaTime);
            
            float amount = Mathf.Abs(stepperSettings.force  * physicsTracker.Velocity.y);
            info += "Force amount: " + amount + "\n";

            float dragAmount = Mathf.Abs(stepperSettings.dragScale * (1/physicsTracker.Velocity.y));
            info += "Drag amount: " + dragAmount + "\n";

            if (amount > stepperSettings.threshold)
            {
                stepperSettings.rigidbody.AddForce(transform.forward * amount);
                stepperSettings.rigidbody.velocity = new Vector3(0, 0, Mathf.Clamp(stepperSettings.rigidbody.velocity.z, 0, stepperSettings.maxSpeed));
                info += "rb velocity: " + stepperSettings.rigidbody.velocity + "\n";
                stepperSettings.rigidbody.drag = dragAmount;

                //Debug.Log("vel: " + stepperSettings.rigidbody.velocity.z);
            }
            debugUI.UpdateInfoBox(info);
        }
    }

    void ManageTether()
    {

        // @TODO Jethro
        string info = "canMove: false";
        if(Input.GetKey(tetherSettings.movementKeyForward))
        {
        tetherSettings.HMD.transform.position += new Vector3(0, 0, ( keyboardSettings.speed* Time.deltaTime));
        }
        if(Input.GetKey(tetherSettings.movementKeyBackward))
        {
        tetherSettings.HMD.transform.position -= new Vector3(0, 0, ( keyboardSettings.speed* Time.deltaTime));
        }
        if(tetherSettings.move == true)
        {
            info = "canMove: true\n" +
                    "tetherSpeed: " + tetherSettings.getSpeed();
            playerMovement.Move( tetherSettings.getSpeed()* Time.deltaTime);
        }
        debugUI.UpdateInfoBox(info);
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
    public KeyCode movementKey = KeyBindings.MOVE_FORWARD;
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
    public float force;
    public float dragScale;
    public float threshold =  0.1f;
    public float maxSpeed = 35f;
    public Rigidbody rigidbody;

    public float prev_velocity = 0f;
}

[System.Serializable]
public class TetherSettings
{

    // @TODO Jethro
    public KeyCode movementKeyForward;

    public KeyCode movementKeyBackward;

    public bool move = false;



    public GameObject HMD;
    public GameObject Room;


    public GameObject threshold_1;
    public GameObject threshold_2;
    public GameObject threshold_3;


    public float speed_1;
    public float speed_2;
    public float speed_3;

    public float speed = 1;
    public float getSpeed(){
        if (!move) return 0; 
        float distance = HMD.transform.position.z-threshold_1.transform.position.z;
        if (distance<0) throw new System.Exception("Distance shouldn't be negative");
        return (float)(1+distance*3.25);
        // return 2+1/(1+Mathf.Exp(distance));
    }

}




