using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdCheck : MonoBehaviour
{

    public MovementInterface movementInterface;


    void OnTriggerEnter(Collider other)
    {
        movementInterface.EnterTag(other);
    }

    void OnTriggerExit(Collider other)
    {
        movementInterface.ExitTag(other);
    }
}
