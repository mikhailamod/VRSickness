using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string walkType = "walk";
    public float soundThreshold;

    //move the player
    public void Move(float delta)
    {
        transform.position += new Vector3(0, 0, delta);

    }

    //set what type of walking is used so that footstep sounds change
    public void SetWalkType(string walkType)
    {
        this.walkType = walkType;
    }
}
