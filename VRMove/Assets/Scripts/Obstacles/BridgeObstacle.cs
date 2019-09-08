using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A static obstacle (no triggers) but does change sound of footsteps
/// </summary>
public class BridgeObstacle : Obstacle
{
    public MovementInterface movementInterface;
    //play bridge walk sound
    void OnTriggerEnter(Collider other)
    {
        movementInterface.SetWalkType("walkWood");
    }

    //play normal walk sound
    void OnTriggerExit(Collider other)
    {
        movementInterface.SetWalkType("walk");
    }

    protected override void Trigger()
    {
        
    }
}
