using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeObstacle : Obstacle
{
    public PlayerMovement playerMovement;
    //play bridge walk sound
    void OnTriggerEnter(Collider other)
    {
        playerMovement.SetWalkType("walkWood");
    }

    //play normal walk sound
    void OnTriggerExit(Collider other)
    {
        playerMovement.SetWalkType("walk");
    }

    protected override void Trigger()
    {
        
    }
}
