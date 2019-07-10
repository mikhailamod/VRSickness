using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

//temp edit
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
    public Transform tracker;
    public SteamVR_TrackedObject trackerObject;
    float previous_y = 0;
    float previous_vy = 0;
    public int currentDevice = 0;
    bool hasStarted = false;

    [Header("Tether Settings")]
    public TetherSettings tetherSettings;

    public void EnterTag(Collider other)
    {
        if (other.gameObject.CompareTag("Thresh1"))
        {
            tetherSettings.move = true;
            // tetherSettings.speed = tetherSettings.speed_1;
        }

    }

    public void ExitTag(Collider other)
    {
        if (other.gameObject.CompareTag("Thresh1"))
        {
            if (tetherSettings.HMD.transform.position.z < other.transform.position.z)
            {
                tetherSettings.move = false;
            }
        }
    }

    void Start()
    {
        if(!playerMovement)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        previous_y = 0f;
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
                break;
        }

        if(Input.GetKeyDown(KeyBindings.INCREASE_TRACKED_OBJECT))
        {
            currentDevice++;
            trackerObject.SetDeviceIndex(currentDevice);
        }
        if (Input.GetKeyDown(KeyBindings.DECREASE_TRACKED_OBJECT))
        {
            currentDevice--;
            trackerObject.SetDeviceIndex(currentDevice);
        }
        if(Input.GetKeyDown(KeyBindings.START_STEPPER))
        {
            hasStarted = true;
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
            float amount = walkAction.GetAxis(SteamVR_Input_Sources.Any) * controllerSettings.speed;
            playerMovement.Move(amount * Time.deltaTime);
        }
    }

    void ManageStepper()
    {
        if(hasStarted)
        {
            float current_y = tracker.position.y;
            float current_vy = Mathf.Abs(current_y - previous_y) / Time.deltaTime;
            float accelaration = Mathf.Abs((current_vy - previous_vy) / Time.deltaTime);
            previous_y = current_y;
            previous_vy = current_vy;

            float amount = stepperSettings.speed * stepperSettings.scalingFactor * accelaration;
            if (amount > stepperSettings.threshold)
            {
                playerMovement.Move(amount * Time.deltaTime);
            }
        }
        else
        {
            previous_y = tracker.position.y;
        }
    }

    void ManageTether()
    {
        
        // @TODO Jethro
        
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
            playerMovement.Move( tetherSettings.getSpeed()* Time.deltaTime);
        }
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
    public float speed;
    public float scalingFactor;
    public float threshold =  0.1f;
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




