using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeObstacle : Obstacle
{
    public PlayerMovement playerMovement;
    //play bridge walk sound
    void OnTriggerEnter(Collider other)
    {
        playerMovement.setWalkType("walkWood");
    }

    //play normal walk sound
    void OnTriggerExit(Collider other)
    {
        playerMovement.setWalkType("walk");
    }

    protected override void Trigger()
    {
        
    }
}
