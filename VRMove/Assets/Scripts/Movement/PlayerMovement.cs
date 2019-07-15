using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SoundManager soundManager;
    public string walkType = "walk";
    public void Move(float delta)
    {
        transform.position += new Vector3(0, 0, delta);

        /*if(!soundManager.isPlaying(walkType))
        {
            soundManager.playSound(walkType);
        }
        */
    }

    public void setWalkType(string walkType)
    {
        this.walkType = walkType;
    }
}
