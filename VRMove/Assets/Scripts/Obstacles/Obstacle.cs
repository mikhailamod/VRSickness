using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public abstract class Obstacle : MonoBehaviour
{

    public float proximity;
    public KeyCode input;

    protected Transform player;
    protected MovementInterface movementInterface;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        movementInterface = player.GetComponent<MovementInterface>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Mathf.Abs(transform.position.z - player.position.z) < proximity)
        {
            if(movementInterface.state == MovementState.KEYBOARD && Input.GetKeyDown(input))
            {
                Trigger();
            }
            else if(SteamVR_Actions._default.Interact.GetStateDown(SteamVR_Input_Sources.Any))
            {
                Trigger();
            }
              
        }
    }

    protected abstract void Trigger();
}
