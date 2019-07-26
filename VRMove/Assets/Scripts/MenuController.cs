using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject controllerInputs;
    public GameObject tetherInputs;
    public GameObject stepperInputs;
    
    public void EnableController()
    {
        GameController.Instance.state = MovementState.CONTROLLER;
        controllerInputs.SetActive(true);
        gameObject.SetActive(false);
    }

    public void EnableTether()
    {
        GameController.Instance.state = MovementState.TETHER;
        tetherInputs.SetActive(true);
        gameObject.SetActive(false);
    }

    public void EnableStepper()
    {
        GameController.Instance.state = MovementState.STEPPER;
        stepperInputs.SetActive(true);
        gameObject.SetActive(false);
    }

}
