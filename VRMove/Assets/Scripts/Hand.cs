using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(FixedJoint))]
[RequireComponent(typeof(SteamVR_Behaviour_Pose))]
public class Hand : MonoBehaviour
{

    public SteamVR_Action_Boolean grabAction = null;

    private SteamVR_Behaviour_Pose pose = null;
    private FixedJoint fixedJoint = null;

    public Interactable currentInteractable = null;
    public List<Interactable> interactables = new List<Interactable>();

    bool hasSomething = false;

    void Awake()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        fixedJoint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSomething && grabAction.GetStateDown(pose.inputSource))
        {
            Debug.Log(pose.inputSource + " Trigger Down");
            Pickup();
        }
        /*
        else if (hasSomething && grabAction.GetStateDown(pose.inputSource))
        {
            Debug.Log(pose.inputSource + " Trigger Up.");
            Drop();
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        interactables.Add(other.gameObject.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        interactables.Remove(other.gameObject.GetComponent<Interactable>());
    }

    public void Pickup()
    {
        currentInteractable = GetNearestInteractable();

        if (!currentInteractable)
            return;

        if (currentInteractable.activeHand)
            currentInteractable.activeHand.Drop();

        currentInteractable.transform.position = transform.position;
        currentInteractable.transform.rotation = transform.rotation;
        Rigidbody targetBody = currentInteractable.GetComponent<Rigidbody>();
        fixedJoint.connectedBody = targetBody;
        currentInteractable.activeHand = this;
        hasSomething = true;

    }

    public void Drop()
    {
        if (!currentInteractable)
            return;

        Rigidbody targetBody = currentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = pose.GetVelocity();
        targetBody.angularVelocity = pose.GetAngularVelocity();
        targetBody.transform.rotation = Quaternion.identity;

        fixedJoint.connectedBody = null;
        currentInteractable.activeHand = null;
        currentInteractable = null;
        hasSomething = false;
    }

    Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float min = float.MaxValue;
        float current = 0.0f;

        foreach (Interactable i in interactables)
        {
            current = (i.transform.position - transform.position).sqrMagnitude;
            if (current < min)
            {
                min = current;
                nearest = i;
            }
        }

        return nearest;
    }

    public void ForceRemove(Interactable i)
    {
        interactables.Remove(i);
    }
}
