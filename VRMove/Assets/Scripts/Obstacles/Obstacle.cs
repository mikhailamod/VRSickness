using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;
using cakeslice;

public abstract class Obstacle : MonoBehaviour
{

    public float proximity;
    public KeyCode input;
    public GameObject billboard;

    protected Transform player;
    protected MovementInterface movementInterface;

    public List<Outline> outlines;

    public TextMeshProUGUI textMesh;

    protected bool hasTriggered = false;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        movementInterface = player.GetComponent<MovementInterface>();

        if(billboard != null)
        {
            textMesh = billboard.GetComponentInChildren<TextMeshProUGUI>();
            billboard.SetActive(false);
            DisableOutlines();
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Mathf.Abs(transform.position.z - player.position.z) < proximity)
        {
            if(billboard != null)
            {
                
                switch(movementInterface.state)
                {
                    case MovementState.KEYBOARD:
                        textMesh.text = "Press E to interact";
                        break;
                    default:
                        textMesh.text = "Press touchpad to interact";
                        break;
                }
                if (!hasTriggered)
                {
                    EnableOutlines();
                    billboard.SetActive(true);
                }
            }
            if(movementInterface.state == MovementState.KEYBOARD && Input.GetKeyDown(input))
            {
                if (billboard != null) { billboard.SetActive(false); }
                DisableOutlines();
                hasTriggered = true;
                Trigger();
            }
            else if(SteamVR_Actions._default.Interact.GetStateDown(SteamVR_Input_Sources.Any))
            {
                if (billboard != null) { billboard.SetActive(false); }
                DisableOutlines();
                hasTriggered = true;
                Trigger();
            }  
        }
        else
        {
            DisableOutlines();
        }
    }

    protected abstract void Trigger();

    void EnableOutlines()
    {
        if(outlines != null)
        {
            for (int i = 0; i < outlines.Count; i++)
            {
                outlines[i].enabled = true;
            }
        }     
    }

    void DisableOutlines()
    {
        if(outlines != null)
        {
            for (int i = 0; i < outlines.Count; i++)
            {
                outlines[i].enabled = false;
            }
        }    
    }
}
