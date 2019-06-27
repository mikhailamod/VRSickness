using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThresholdCheck : MonoBehaviour
{

    public MovementInterface movementInterface;


    void OnTriggerEnter(Collider other)
    {
        movementInterface.enterTag(other);
    }

    void OnTriggerExit(Collider other)
    {
        movementInterface.exitTag(other);
    }
}
